using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using SokolovskiyClinicService.Entity.Repository.DoctorRepository;
using SokolovskiyClinicService.Entity.Repository.ProfessionRepository;
using SokolovskiyClinicService.Entity.Repository.ScheduleRepository;
using SokolovskiyClinicService.Entity.Repository.SessionRepository;
using SokolovskiyClinicService.Entity.Repository.WorkDayRepository;
using SokolovskiyClinicService.Exceptions;
using SokolovskiyClinicService.Models.DomainModels;

namespace SokolovskiyClinicService.BusinessLogic.CommonServices
{
    public class CommonServices : ICommonServices

    {
        private readonly ISessionRepository _sessionRepository;
        private readonly IProfessionRepository _professionRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IWorkDayRepository _workDayRepository;

        public CommonServices(ISessionRepository sessionRepository,
            IProfessionRepository professionRepository, IDoctorRepository doctorRepository,
            IScheduleRepository scheduleRepository, IWorkDayRepository workDayRepository)
        {
            _sessionRepository = sessionRepository;
            _professionRepository = professionRepository;
            _doctorRepository = doctorRepository;
            _scheduleRepository = scheduleRepository;
            _workDayRepository = workDayRepository;
        }

        public Schedule GetScheduleOnDate(int doctorId, DateTime dateTime)
        {
            return _scheduleRepository.GetSchedulesByDoctorId(doctorId)
                .OrderByDescending(s => s.ActualisationDate)
                .FirstOrDefault(s => s.ActualisationDate <= dateTime.Date);
        }

        public IEnumerable<Profession> GetAllProfessions()
        {
            return _professionRepository.GetAllProfessions();
        }

        public IEnumerable<Doctor> GetDoctorsByProfession(int professionId)
        {
            return _doctorRepository.GetDoctorsByProfession(professionId).Where(d=>!d.IsRemoved || (d.IsRemoved && d.DateOfDismissal > DateTime.Today));
        }

        public Dictionary<TimeSpan,Session> GetSessionsByDoctorIdAndDate(int doctorId, DateTime date)
        {
            if (_doctorRepository.GetDoctorById(doctorId) == null)
                throw new WarningException(ExceptionMessages.DoctorNotFound);
            var sessionsToReturn = new Dictionary<TimeSpan, Session>(); 
            var sessionsFromBase = _sessionRepository.GetSessionsByDoctorIdAndDate(doctorId, date.Date).ToList();
            for (var i = 0; i < 26; i++)
            {
                var currentTime = new TimeSpan(8+i/2,0,0);
                if(i%2!=0)
                    currentTime = new TimeSpan(8+i/2,30,0);
                
                sessionsToReturn.Add(currentTime, sessionsFromBase.FirstOrDefault(s => s.TimeOfBeginSession == currentTime));
            }
            return sessionsToReturn;
        }

        public Doctor GetDoctorById(int doctorId)
        {
            return _doctorRepository.GetDoctorById(doctorId);
        }

        public IEnumerable<Schedule> GetAllActualSchedules(DateTime dateNow)
        {
            var doctorSchedules = _scheduleRepository.GetAllSchedules()
                .Where(s => s.ActualisationDate <= dateNow)
                .GroupBy(s => s.DoctorId)
                .ToArray();
            return doctorSchedules.Select(schedules => schedules.Aggregate((first, second) => first.ActualisationDate > second.ActualisationDate ? first : second)).ToList();
        }


        public IEnumerable<Doctor> GetAllDoctors()
        {
            return _doctorRepository.GetAllDoctors();
        }

        public Profession GetProfessionByDoctorId(int doctorId)
        {
            return _professionRepository.GetProfessionById(_doctorRepository.GetDoctorById(doctorId).ProfessionId);
        }

        public WorkDay GetWorkDayById(int workDayId)
        {
            return _workDayRepository.GetById(workDayId);
        }

        public WorkDay ExtractWorkDayFromSchedule(Schedule schedule, DateTime dateTime)
        {
            if (schedule == null) return null;
            return dateTime.DayOfWeek switch
            {
                DayOfWeek.Monday => _workDayRepository.GetById(schedule.MondayId),
                DayOfWeek.Tuesday => _workDayRepository.GetById(schedule.TuesdayId),
                DayOfWeek.Wednesday => _workDayRepository.GetById(schedule.WednesdayId),
                DayOfWeek.Thursday => _workDayRepository.GetById(schedule.ThursdayId),
                DayOfWeek.Friday => _workDayRepository.GetById(schedule.FridayId),
                DayOfWeek.Saturday => _workDayRepository.GetById(schedule.SaturdayId),
                DayOfWeek.Sunday => _workDayRepository.GetById(schedule.SundayId),
                _ => null
            };
        }
    }
}