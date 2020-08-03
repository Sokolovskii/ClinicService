using System;
using System.Linq;
using SokolovskiyClinicService.Entity.Repository.DoctorRepository;
using SokolovskiyClinicService.Entity.Repository.ProfessionRepository;
using SokolovskiyClinicService.Entity.Repository.ScheduleRepository;
using SokolovskiyClinicService.Entity.Repository.SessionRepository;
using SokolovskiyClinicService.Entity.Repository.UserRepository;
using SokolovskiyClinicService.Entity.Repository.WorkDayRepository;
using SokolovskiyClinicService.Exceptions;
using SokolovskiyClinicService.Lockers;
using SokolovskiyClinicService.Models.DomainModels;
using SokolovskiyClinicService.Models.TransferModels;

namespace SokolovskiyClinicService.BusinessLogic.AdminServices
{
    /// <summary>
    /// Класс сервисов администрации
    /// </summary>
    /// <inheritdoc cref="IAdminServices"/>
    public class AdminServices : IAdminServices
    {
        private readonly ISessionRepository _sessionRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IProfessionRepository _professionRepository;
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IWorkDayRepository _workDayRepository;
        private readonly IUserRepository _userRepository;
        private readonly Locker _locker;

        public AdminServices(ISessionRepository sessionRepository, IDoctorRepository doctorRepository,
            IProfessionRepository professionRepository, IScheduleRepository scheduleRepository, Locker locker, IWorkDayRepository workDayRepository, IUserRepository userRepository)
        {
            _sessionRepository = sessionRepository;
            _doctorRepository = doctorRepository;
            _professionRepository = professionRepository;
            _scheduleRepository = scheduleRepository;
            _locker = locker;
            _workDayRepository = workDayRepository;
            _userRepository = userRepository;
        }

        public DateTime DismissDoctor(int doctorId, DateTime dateOfDismissal)
        {
            lock (_locker.GetOrAdd(doctorId))
            {
                if(HasConflictSession(doctorId, dateOfDismissal))
                    throw new WarningException(ExceptionMessages.HasConflictSessions);
                return(_doctorRepository.DeleteDoctor(doctorId, dateOfDismissal));
            }
        }
        
        public void UpdateSchedule(ScheduleWithDateTransfer scheduleWithDateTransfer)
        {
            if (!IsCorrectScheduleTimesOfWorkDay(scheduleWithDateTransfer))
                throw new WarningException(ExceptionMessages.TimeOfWorkDayIsNonCorrect);
            if (!IsCorrectScheduleTimes(scheduleWithDateTransfer))
                throw new WarningException(ExceptionMessages.WorkDayIsNotCorrect);
            lock (_locker.GetOrAdd(scheduleWithDateTransfer.DoctorId))
            {
                if (HasConflictSession(scheduleWithDateTransfer))
                    throw new WarningException(ExceptionMessages.DateOfChangeWorkDayNotOptimal);
                SetWorkDaysId(scheduleWithDateTransfer);
                _scheduleRepository.AddOrUpdateSchedule(new Schedule
                {
                    ActualisationDate = scheduleWithDateTransfer.ActualisationDate,
                    DoctorId = scheduleWithDateTransfer.DoctorId,
                    MondayId = scheduleWithDateTransfer.Monday?.Id ?? 0,
                    TuesdayId = scheduleWithDateTransfer.Tuesday?.Id ?? 0,
                    WednesdayId = scheduleWithDateTransfer.Wednesday?.Id ?? 0,
                    ThursdayId = scheduleWithDateTransfer.Thursday?.Id ?? 0,
                    FridayId = scheduleWithDateTransfer.Friday?.Id ?? 0,
                    SaturdayId = scheduleWithDateTransfer.Saturday?.Id ?? 0,
                    SundayId = scheduleWithDateTransfer.Sunday?.Id ?? 0,
                    IsApproved = true
                });
            }
        }

        public void ApproveDoctor(int doctorId)
        {
            _doctorRepository.ApproveDoctor(doctorId);
        }

        public void DisapproveDoctor(int doctorId)
        {
            _userRepository.DeleteUser(doctorId);
            _scheduleRepository.DeleteScheduleByDoctorId(doctorId);
            _doctorRepository.DisapproveDoctor(doctorId);
        }

        public void AddNewProfession(string professionName)
        {
            _professionRepository.AddNewProfession(professionName);
        }

        private bool HasConflictSession(ScheduleWithDateTransfer scheduleWithDateTransfer)
        {
            var nextSchedule = _scheduleRepository.GetSchedulesByDoctorId(scheduleWithDateTransfer.DoctorId)
                .OrderByDescending(s => s.ActualisationDate)
                .FirstOrDefault(s => s.ActualisationDate > scheduleWithDateTransfer.ActualisationDate);

            var sessionsInNewSchedule = _sessionRepository.GetSessionsByDoctorId(scheduleWithDateTransfer.DoctorId)
                .Where(s => s.Date >= scheduleWithDateTransfer.ActualisationDate);

            if (nextSchedule != null)
                sessionsInNewSchedule = sessionsInNewSchedule.Where(s => s.Date < nextSchedule.ActualisationDate);

            if (sessionsInNewSchedule.Equals(default)) return false;
            foreach (var session in sessionsInNewSchedule)
            {
                switch (session.Date.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                        return (IsNonCorrectSession(session, scheduleWithDateTransfer.Monday));
                    case DayOfWeek.Tuesday:
                        return (IsNonCorrectSession(session, scheduleWithDateTransfer.Tuesday));
                    case DayOfWeek.Wednesday:
                        return (IsNonCorrectSession(session, scheduleWithDateTransfer.Wednesday));
                    case DayOfWeek.Thursday:
                        return (IsNonCorrectSession(session, scheduleWithDateTransfer.Thursday));
                    case DayOfWeek.Friday:
                        return (IsNonCorrectSession(session, scheduleWithDateTransfer.Friday));
                    case DayOfWeek.Saturday:
                        return (IsNonCorrectSession(session, scheduleWithDateTransfer.Saturday));
                    case DayOfWeek.Sunday:
                        return (IsNonCorrectSession(session, scheduleWithDateTransfer.Sunday));
                }
            }
            return false;
        }
        private static bool IsCorrectTimeOfWorkDay(WorkDay workDay)
        {
            if (workDay == null)
                return true;
            return workDay.BeginOfDay >= new TimeSpan(8, 0, 0) &&
                   workDay.EndOfDay <= new TimeSpan(21, 0, 0);
        }

        private static bool IsCorrectScheduleTimesOfWorkDay(ScheduleWithDateTransfer scheduleWithDateTransfer)
        {
            return IsCorrectTimeOfWorkDay(scheduleWithDateTransfer.Monday)
                   && IsCorrectTimeOfWorkDay(scheduleWithDateTransfer.Tuesday)
                   && IsCorrectTimeOfWorkDay(scheduleWithDateTransfer.Wednesday)
                   && IsCorrectTimeOfWorkDay(scheduleWithDateTransfer.Thursday)
                   && IsCorrectTimeOfWorkDay(scheduleWithDateTransfer.Friday)
                   && IsCorrectTime(scheduleWithDateTransfer.Saturday)
                   && IsCorrectTime(scheduleWithDateTransfer.Sunday);
        }
        
        private static bool IsCorrectTime(WorkDay workDay)
        {
            if (workDay == null)
                return true;
            return workDay.BeginOfDay < workDay.EndOfDay;
        }

        private static bool IsCorrectScheduleTimes(ScheduleWithDateTransfer scheduleWithDateTransfer)
        {
            return IsCorrectTime(scheduleWithDateTransfer.Monday)
                   && IsCorrectTime(scheduleWithDateTransfer.Tuesday)
                   && IsCorrectTime(scheduleWithDateTransfer.Wednesday)
                   && IsCorrectTime(scheduleWithDateTransfer.Thursday)
                   && IsCorrectTime(scheduleWithDateTransfer.Friday)
                   && IsCorrectTime(scheduleWithDateTransfer.Saturday)
                   && IsCorrectTime(scheduleWithDateTransfer.Sunday);
        }

        private bool HasConflictSession(int doctorId, DateTime dateOfDismissal)
        {
            return _sessionRepository.GetSessionsByDoctorId(doctorId)
                .Any(s => s.Date >= dateOfDismissal.Date.Add(TimeSpan.FromDays(14)));
        }

        private bool IsNonCorrectSession(Session session, WorkDay workDay)
        {
            if (workDay == null)
                return false;
            return workDay.BeginOfDay < session.TimeOfBeginSession 
                   || workDay.EndOfDay > session.TimeOfEndSession;
        }
        
        private void SetWorkDaysId(ScheduleWithDateTransfer transfer)
        {
            if (transfer.Monday != null)
            {
                transfer.Monday.Id = _workDayRepository.GetOrAddNewWorkDay(transfer.Monday.BeginOfDay, transfer.Monday.EndOfDay);
            }

            if (transfer.Tuesday != null)
            {
                transfer.Tuesday.Id =
                    _workDayRepository.GetOrAddNewWorkDay(transfer.Tuesday.BeginOfDay, transfer.Tuesday.EndOfDay);
            }

            if (transfer.Wednesday != null)
            {
                transfer.Wednesday.Id =
                    _workDayRepository.GetOrAddNewWorkDay(transfer.Wednesday.BeginOfDay, transfer.Wednesday.EndOfDay);
            }

            if (transfer.Thursday != null)
            {
                transfer.Thursday.Id =_workDayRepository.GetOrAddNewWorkDay(transfer.Thursday.BeginOfDay, transfer.Thursday.EndOfDay);
            }

            if (transfer.Friday != null)
            {
                transfer.Friday.Id =_workDayRepository.GetOrAddNewWorkDay(transfer.Friday.BeginOfDay, transfer.Friday.EndOfDay);
            }

            if (transfer.Saturday != null)
            {
                transfer.Saturday.Id =
                    _workDayRepository.GetOrAddNewWorkDay(transfer.Saturday.BeginOfDay, transfer.Saturday.EndOfDay);
            }

            if (transfer.Sunday != null)
            {
                transfer.Sunday.Id =
                    _workDayRepository.GetOrAddNewWorkDay(transfer.Sunday.BeginOfDay, transfer.Sunday.EndOfDay);
            }
        }
    }
}