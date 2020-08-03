using SokolovskiyClinicService.Models.DomainModels;
using SokolovskiyClinicService.Models.DTOModels.ScheduleDtoModels;

namespace SokolovskiyClinicService.Models.TransferModels
{
    /// <summary>
    /// Переходная модель между ДТО и доменной для расписания
    /// </summary>
    public class ScheduleTransfer
    {
        /// <summary>
        /// Id доктора
        /// </summary>
        public int DoctorId { get; set; }

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
        public WorkDay Saturday { get; set; }
        
        /// <summary>
        /// Рабочий день в воскресенье
        /// </summary>
        public WorkDay Sunday { get; set; }

        /// <summary>
        /// Флаг одобренности администратором
        /// </summary>
        public bool IsApproved { get; set; }

        public ScheduleTransfer(ScheduleToAddingDto scheduleDto, int doctorId)
        {
            DoctorId = doctorId;
            Monday = scheduleDto.Monday == null ? null : new WorkDay(scheduleDto.Monday);
            Tuesday = scheduleDto.Tuesday == null ? null : new WorkDay(scheduleDto.Tuesday);
            Wednesday = scheduleDto.Wednesday == null ? null : new WorkDay(scheduleDto.Wednesday);
            Thursday = scheduleDto.Thursday == null ? null : new WorkDay(scheduleDto.Thursday);
            Friday = scheduleDto.Friday == null ? null : new WorkDay(scheduleDto.Friday);
            Saturday = scheduleDto.Saturday == null ? null : new WorkDay(scheduleDto.Saturday);
            Sunday = scheduleDto.Sunday == null ? null : new WorkDay(scheduleDto.Sunday);
            IsApproved = false;
        }
        
        public ScheduleTransfer(){}
    }
}