using System;
using SokolovskiyClinicService.Entity.Repository.DoctorRepository;
using SokolovskiyClinicService.Entity.Repository.ScheduleRepository;
using SokolovskiyClinicService.Entity.Repository.WorkDayRepository;
using SokolovskiyClinicService.Exceptions;
using SokolovskiyClinicService.Lockers;
using SokolovskiyClinicService.Models.DomainModels;
using SokolovskiyClinicService.Models.TransferModels;

namespace SokolovskiyClinicService.BusinessLogic.DoctorServices
{
    public class DoctorServices : IDoctorServices
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IWorkDayRepository _workDayRepository;
        private readonly Locker _locker;

        public DoctorServices(IDoctorRepository doctorRepository, IScheduleRepository scheduleRepository, Locker locker, IWorkDayRepository workDayRepository)
        {
            _doctorRepository = doctorRepository;
            _scheduleRepository = scheduleRepository;
            _locker = locker;
            _workDayRepository = workDayRepository;
        }

        public void AddNewSchedule(ScheduleTransfer scheduleTransfer)
        {
            if (!IsCorrectScheduleTimesOfWorkDay(scheduleTransfer))
                throw new WarningException(ExceptionMessages.TimeOfWorkDayIsNonCorrect);
            if (!IsCorrectScheduleTimes(scheduleTransfer))
                throw new WarningException(ExceptionMessages.WorkDayIsNotCorrect);
            SetWorkDaysId(scheduleTransfer);
            _scheduleRepository.AddFirstSchedule(new Schedule
            {
                DoctorId = scheduleTransfer.DoctorId,
                MondayId = scheduleTransfer.Monday?.Id ?? 0,
                TuesdayId = scheduleTransfer.Tuesday?.Id ?? 0,
                WednesdayId = scheduleTransfer.Wednesday?.Id ?? 0,
                ThursdayId = scheduleTransfer.Thursday?.Id ?? 0,
                FridayId = scheduleTransfer.Friday?.Id ?? 0,
                SaturdayId = scheduleTransfer.Saturday?.Id ?? 0,
                SundayId = scheduleTransfer.Sunday?.Id ?? 0,
                IsApproved = false
                
            });
            UpdateDoctorStatus(scheduleTransfer.DoctorId);
        }

        public void UpdateSchedule(ScheduleWithDateTransfer scheduleWithDateTransfer)
        {
            SetWorkDaysId(scheduleWithDateTransfer);
            lock (_locker.GetOrAdd(scheduleWithDateTransfer.DoctorId))
            {
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
                    IsApproved = scheduleWithDateTransfer.IsApproved
                });
                UpdateDoctorStatus(scheduleWithDateTransfer.DoctorId);
            }
        }

        public void AddProfession(int doctorId, int professionId)
        {
            _doctorRepository.AddProfession(doctorId, professionId);
            UpdateDoctorStatus(doctorId);
        }

        private void UpdateDoctorStatus(int doctorId)
        {
            _doctorRepository.UpdateDoctorStatus(doctorId);
        }

        private void SetWorkDaysId(ScheduleTransfer transfer)
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
        
        private static bool IsCorrectTime(WorkDay workDay)
        {
            if (workDay == null)
                return true;
            return workDay.BeginOfDay < workDay.EndOfDay;
        }

        private static bool IsCorrectScheduleTimes(ScheduleTransfer scheduleTransfer)
        {
            return IsCorrectTime(scheduleTransfer.Monday)
                   && IsCorrectTime(scheduleTransfer.Tuesday)
                   && IsCorrectTime(scheduleTransfer.Wednesday)
                   && IsCorrectTime(scheduleTransfer.Thursday)
                   && IsCorrectTime(scheduleTransfer.Friday)
                   && IsCorrectTime(scheduleTransfer.Saturday)
                   && IsCorrectTime(scheduleTransfer.Sunday);
        }
        
        private static bool IsCorrectScheduleTimesOfWorkDay(ScheduleTransfer scheduleTransfer)
        {
            return IsCorrectTimeOfWorkDay(scheduleTransfer.Monday)
                   && IsCorrectTimeOfWorkDay(scheduleTransfer.Tuesday)
                   && IsCorrectTimeOfWorkDay(scheduleTransfer.Wednesday)
                   && IsCorrectTimeOfWorkDay(scheduleTransfer.Thursday)
                   && IsCorrectTimeOfWorkDay(scheduleTransfer.Friday)
                   && IsCorrectTime(scheduleTransfer.Saturday)
                   && IsCorrectTime(scheduleTransfer.Sunday);
        }
        
        private static bool IsCorrectTimeOfWorkDay(WorkDay workDay)
        {
            if (workDay == null)
                return true;
            return workDay.BeginOfDay >= new TimeSpan(8, 0, 0) &&
                   workDay.EndOfDay <= new TimeSpan(21, 0, 0);
        }
    }
}