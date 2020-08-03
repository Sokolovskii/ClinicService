using System;
using SokolovskiyClinicService.Models.DomainModels;
using SokolovskiyClinicService.Models.DTOModels.ScheduleDtoModels;

namespace SokolovskiyClinicService.Models.TransferModels
{
    public class ScheduleWithDateTransfer
    {
        /// <summary>
        /// Id доктора
        /// </summary>
        public int DoctorId { get; set; }
        
        /// <summary>
        /// Дата актуализации расписания
        /// </summary>
        public DateTime ActualisationDate { get; set; }

        /// <summary>
        /// Рабочий день понедельника
        /// </summary>
        public WorkDay Monday { get; set; }
        
        /// <summary>
        /// Рабочий день вторника
        /// </summary>
        public WorkDay Tuesday { get; set; }
        
        /// <summary>
        /// Рабочий день среды
        /// </summary>
        public WorkDay Wednesday { get; set; }
        
        /// <summary>
        /// Рабочий день четверга
        /// </summary>
        public WorkDay Thursday { get; set; }
        
        /// <summary>
        /// Рабочий день пятницы
        /// </summary>
        public WorkDay Friday { get; set; }
        
        /// <summary>
        /// Рабочий день в субботу
        /// </summary>
        public WorkDay Saturday { get;}
        
        /// <summary>
        /// Рабочий день в воскресенье
        /// </summary>
        public WorkDay Sunday { get;}

        /// <summary>
        /// Флаг одобренности администратором
        /// </summary>
        public bool IsApproved { get; }
        
        public ScheduleWithDateTransfer(ScheduleDto schedule, int doctorId)
        {
            DoctorId = doctorId;
            ActualisationDate = schedule.ActualisationDate;
            Monday = schedule.Monday == null ? null : new WorkDay(schedule.Monday);
            Tuesday = schedule.Tuesday == null ? null : new WorkDay(schedule.Tuesday);
            Wednesday = schedule.Wednesday == null ? null : new WorkDay(schedule.Wednesday);
            Thursday = schedule.Thursday == null ? null : new WorkDay(schedule.Thursday);
            Friday = schedule.Friday == null ? null : new WorkDay(schedule.Friday);
            Saturday = schedule.Saturday == null ? null : new WorkDay(schedule.Saturday);
            Sunday = schedule.Sunday == null ? null : new WorkDay(schedule.Sunday);
            IsApproved = false;
        }

        public ScheduleWithDateTransfer(ScheduleFullDto scheduleDto)
        {
            DoctorId = scheduleDto.DoctorId;
            ActualisationDate = scheduleDto.ActualisationDate;
            Monday = scheduleDto.Monday == null ? null : new WorkDay(scheduleDto.Monday);
            Tuesday = scheduleDto.Tuesday == null ? null : new WorkDay(scheduleDto.Tuesday);
            Wednesday = scheduleDto.Wednesday == null ? null : new WorkDay(scheduleDto.Wednesday);
            Thursday = scheduleDto.Thursday == null ? null : new WorkDay(scheduleDto.Thursday);
            Friday = scheduleDto.Friday == null ? null : new WorkDay(scheduleDto.Friday);
            Saturday = scheduleDto.Saturday == null ? null : new WorkDay(scheduleDto.Saturday);
            Sunday = scheduleDto.Sunday == null ? null : new WorkDay(scheduleDto.Sunday);
        }
        
        public ScheduleWithDateTransfer(){}
    }
}