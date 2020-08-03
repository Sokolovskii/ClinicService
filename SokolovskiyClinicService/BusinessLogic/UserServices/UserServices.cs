using System;
using System.Linq;
using SokolovskiyClinicService.Entity.Repository.ScheduleRepository;
using SokolovskiyClinicService.Entity.Repository.SessionRepository;
using SokolovskiyClinicService.Entity.Repository.WorkDayRepository;
using SokolovskiyClinicService.Exceptions;
using SokolovskiyClinicService.Lockers;
using SokolovskiyClinicService.Models.DomainModels;

namespace SokolovskiyClinicService.BusinessLogic.UserServices
{
    /// <summary>
    /// Класс сервисов пользователя
    /// </summary>
    /// <inheritdoc cref="IUserServices"/>
    public class UserServices : IUserServices
    {

        private readonly ISessionRepository _sessionRepository;
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IWorkDayRepository _workDayRepository;
        private readonly Locker _locker;

        public UserServices(ISessionRepository sessionRepository,
            IScheduleRepository scheduleRepository, Locker locker, IWorkDayRepository workDayRepository)
        {
            _sessionRepository = sessionRepository;
            _scheduleRepository = scheduleRepository;
            _locker = locker;
            _workDayRepository = workDayRepository;
        }

        public int ReserveSession(DateTime dateTime, TimeSpan timeOfBegin, int doctorId, int userId)
        {
            if (!IsInDoctorWorkDay(doctorId, dateTime, timeOfBegin))
                throw new Exceptions.WarningException(ExceptionMessages.SessionOutSideTiming);
            
            lock (_locker.GetOrAdd(doctorId))
            {
                if (!IsTimeSlotFree(doctorId, dateTime, timeOfBegin))
                    throw new Exceptions.WarningException(ExceptionMessages.SessionWasReserved);
                
                var timeOfEnd = timeOfBegin.Add(TimeSpan.FromMinutes(30));

                return (_sessionRepository.AddNewSession(new Session
                {
                    Date = dateTime,
                    DoctorId = doctorId,
                    UserId = userId,
                    TimeOfBeginSession = timeOfBegin,
                    TimeOfEndSession = timeOfEnd
                }));
            }
        }

        public void CancelSession(int sessionId, int userId)
        {
            if(_sessionRepository.GetSessionById(sessionId).UserId == userId)
                _sessionRepository.DeleteSession(sessionId);
            else
                throw new WarningException(ExceptionMessages.IsNotCurrentUser);
            
        }
        
        /// <summary>
        /// Проверка на наличие сессии на дату, время и врача
        /// </summary>
        private bool IsTimeSlotFree(int doctorId, DateTime dateTime, TimeSpan timeOfBegin)
        {
            var sessionsTest = _sessionRepository.GetSessionsByDoctorId(doctorId);
            return !sessionsTest.Any(s =>
                s.Date == dateTime && s.TimeOfBeginSession == timeOfBegin &&
                s.DoctorId == doctorId);
        }

        /// <summary>
        /// Проверка на попадание сеанса в рабочий день врача с учетом возможной смены графика
        /// </summary>
        private bool IsInDoctorWorkDay(int doctorId, DateTime dateTime, TimeSpan timeOfBegin)
        {
            var workDay = GetDayOfWeekInSchedule(_scheduleRepository
                .GetSchedulesByDoctorId(doctorId)
                .OrderByDescending(s => s.ActualisationDate)
                .First(s => s.ActualisationDate <= dateTime), dateTime);
            return timeOfBegin >= workDay.BeginOfDay && timeOfBegin <=
                   workDay.EndOfDay.Add(TimeSpan.FromMinutes(-30));
        }

        /// <summary>
        /// Возвращает расписание на конкретный день исходя из актуального расписания врача
        /// </summary>
        private WorkDay GetDayOfWeekInSchedule(Schedule schedule, DateTime dateForSearching)
        {
            switch (dateForSearching.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    return _workDayRepository.GetById(schedule.MondayId);
                case DayOfWeek.Tuesday:
                    return _workDayRepository.GetById(schedule.TuesdayId);
                case DayOfWeek.Wednesday:
                    return _workDayRepository.GetById(schedule.WednesdayId);
                case DayOfWeek.Thursday:
                    return _workDayRepository.GetById(schedule.ThursdayId);
                case DayOfWeek.Friday:
                    return _workDayRepository.GetById(schedule.FridayId);
                case DayOfWeek.Saturday:
                    return _workDayRepository.GetById(schedule.SaturdayId);
                case DayOfWeek.Sunday:
                    return _workDayRepository.GetById(schedule.SundayId);
            }
            return null;
        }
    }
}