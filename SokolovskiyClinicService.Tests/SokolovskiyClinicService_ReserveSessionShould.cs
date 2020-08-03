using System;
using System.Collections.Generic;
using NUnit.Framework;
using SokolovskiyClinicService.BusinessLogic.UserServices;
using Moq;
using SokolovskiyClinicService.BusinessLogic.DoctorServices;
using SokolovskiyClinicService.Entity;
using SokolovskiyClinicService.Entity.Repository.DoctorRepository;
using SokolovskiyClinicService.Entity.Repository.ScheduleRepository;
using SokolovskiyClinicService.Entity.Repository.SessionRepository;
using SokolovskiyClinicService.Entity.Repository.WorkDayRepository;
using SokolovskiyClinicService.Lockers;
using SokolovskiyClinicService.Models.DomainModels;
using SokolovskiyClinicService.Models.TransferModels;

namespace SokolovskiyClinicService.Tests
{
    [TestFixture]
    public class SokolovskiyClinicService_ReserveSessionShould
    {
        private UserServices _userServices;
        private readonly Mock<ISessionRepository> _sessionRepository = new Mock<ISessionRepository>();
        private readonly Mock<IScheduleRepository> _scheduleRepository = new Mock<IScheduleRepository>();
        private readonly Mock<IWorkDayRepository> _workDayRepository = new Mock<IWorkDayRepository>();
        private readonly Mock<Locker> _locker = new Mock<Locker>();
        
        [SetUp]
        public void Setup()
        {
            _userServices = new UserServices(_sessionRepository.Object, _scheduleRepository.Object, _locker.Object, _workDayRepository.Object);
        }

        /// <summary>
        /// Проверка штатной работы
        /// </summary>
        [Test]
        public void ReserveSessionCorrect()
        {
            var userId = 1;
            var doctorId = 1;
            var dateTime = DateTime.Today;
            var timeOfBegin = new TimeSpan(13, 0, 0);
            
            var workDay = new WorkDay{
                Id = 1,
                BeginOfDay = new TimeSpan(8,0,0),
                EndOfDay = new TimeSpan(19,0,0)
            };
            
            var schedules = new List<Schedule>();
            schedules.Add(new Schedule
            {
                Id = 1,
                ActualisationDate = new DateTime(0001,01,01),
                DoctorId = 1,
                IsApproved = true,
                MondayId = 1,
                TuesdayId = 1,
                WednesdayId = 1,
                ThursdayId = 1,
                FridayId = 1,
                SaturdayId = 1,
                SundayId = 1
            });
            
            var sessions = new List<Session>();
            var session = new Session
            {
                Id = 1,
                Date = DateTime.Today,
                DoctorId = 1,
                UserId = 2,
                TimeOfBeginSession = new TimeSpan(10,0,0),
                TimeOfEndSession = new TimeSpan(10,30,0)
            };
            sessions.Add(session);

            var sessionToReserving = new Session
            {
                Date = DateTime.Today,
                DoctorId = 1,
                UserId = 2,
                TimeOfBeginSession = new TimeSpan(10, 0, 0),
                TimeOfEndSession = new TimeSpan(10, 30, 0)
            };
            var reservedSession = 2; 
            
            _scheduleRepository.Setup(rep => rep.GetSchedulesByDoctorId(doctorId)).Returns(schedules);
            _sessionRepository.Setup(rep => rep.GetSessionsByDoctorId(doctorId)).Returns(sessions);
            _sessionRepository.Setup(rep => rep.AddNewSession(sessionToReserving)).Returns(reservedSession);
            _workDayRepository.Setup(rep => rep.GetById(1)).Returns(workDay);
            Assert.DoesNotThrow(()=>_userServices.ReserveSession(dateTime, timeOfBegin, doctorId, userId));
        }
    }

    [TestFixture]
    public class SokolovskiyClinicService_AddNewScheduleShould
    {
        private DoctorServices _doctorServices;
        private readonly Mock<IDoctorRepository> _doctorRepository = new Mock<IDoctorRepository>();
        private readonly Mock<IScheduleRepository> _scheduleRepository = new Mock<IScheduleRepository>();
        private readonly Mock<IWorkDayRepository> _workDayRepository = new Mock<IWorkDayRepository>();
        private readonly Mock<Locker> _locker = new Mock<Locker>();
        
        [SetUp]
        public void Setup()
        {
            _doctorServices = new DoctorServices(_doctorRepository.Object, _scheduleRepository.Object, _locker.Object, _workDayRepository.Object);
        }

        [Test]
        public void AddNewScheduleCorrect()
        {
            var doctorId = 1;
            var workDay = new WorkDay
            {
                BeginOfDay = new TimeSpan(9,0,0),
                EndOfDay = new TimeSpan(18,0,0)
            };
            var schedule = new ScheduleTransfer
            {
                DoctorId = doctorId,
                Monday = workDay,
                Tuesday = workDay,
                Wednesday = workDay,
                Thursday = workDay,
                Friday = workDay,
                Saturday = workDay,
                Sunday = workDay,
                IsApproved = false,
            };

            _workDayRepository.Setup(rep => rep.GetOrAddNewWorkDay(workDay.BeginOfDay, workDay.EndOfDay))
                .Returns(1);
            
            Assert.DoesNotThrow(()=>_doctorServices.AddNewSchedule(schedule));
        }
    }
}