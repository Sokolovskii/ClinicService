using System;
using System.Runtime.Serialization;
using SokolovskiyClinicService.Models.DomainModels;

namespace SokolovskiyClinicService.Models.DTOModels.ScheduleDtoModels
{
    /// <summary>
    /// DTO модель расписания врача
    /// </summary>
    [DataContract]
    public class ScheduleFullDto
    {
        
        /// <summary>
        /// Id врача
        /// </summary>
        public int DoctorId { get; set; }
        
        /// <summary>
        /// Дата вступления графика в силу
        /// </summary>
        [DataMember(Name = "actualisationDate")]
        public DateTime ActualisationDate { get; set; }

        /// <summary>
        /// Рабочий день в понедельник
        /// </summary>
        [DataMember(Name = "monday")]
        public WorkDayDto Monday { get; set; }
        
        /// <summary>
        /// Рабочий день во вторник
        /// </summary>
        [DataMember(Name = "tuesday")]
        public WorkDayDto Tuesday { get; set; }
        
        /// <summary>
        /// Рабочий день в понедельник
        /// </summary>
        [DataMember(Name = "wednesday")]
        public WorkDayDto Wednesday { get; set; }
        
        /// <summary>
        /// Рабочий день в понедельник
        /// </summary>
        [DataMember(Name = "thursday")]
        public WorkDayDto Thursday { get; set; }
        
        /// <summary>
        /// Рабочий день в понедельник
        /// </summary>
        [DataMember(Name = "friday")]
        public WorkDayDto Friday { get; set; }
        
        /// <summary>
        /// Рабочий день в субботу
        /// </summary>
        [DataMember(Name = "saturday")]
        public WorkDayDto Saturday { get; set; }
        
        /// <summary>
        /// Рабочий день в воскресенье
        /// </summary>
        [DataMember(Name="sunday")]
        public WorkDayDto Sunday { get; set; }
    }
}