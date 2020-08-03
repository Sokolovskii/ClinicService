using System;

namespace SokolovskiyClinicService.Models.DomainModels
{
    /// <summary>
    /// Модель расписания доктора
    /// </summary>
    public class Schedule
    {
        /// <summary>
        /// Id расписания
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Id врача
        /// </summary>
        public int DoctorId { get; set; }

        /// <summary>
        /// Дата вступления графика в силу
        /// </summary>
        public DateTime ActualisationDate { get; set; }

        /// <summary>
        /// Рабочий день в понедельник
        /// </summary>
        public int MondayId { get; set; }
        
        /// <summary>
        /// Рабочий день во вторник
        /// </summary>
        public int TuesdayId { get; set; }
        
        /// <summary>
        /// Рабочий день в среду
        /// </summary>
        public int WednesdayId { get; set; }
        
        /// <summary>
        /// Рабочий день в четверг
        /// </summary>
        public int ThursdayId { get; set; }
        
        /// <summary>
        /// Рабочий день в пятницу
        /// </summary>
        public int FridayId { get; set; }

        /// <summary>
        /// рабочий день в субботу
        /// </summary>
        public int SaturdayId { get; set; }
        
        /// <summary>
        /// Рабочий день в воскресенье
        /// </summary>
        public int SundayId { get; set; }

        /// <summary>
        /// Флаг одобренности расписания администратором
        /// </summary>
        public bool IsApproved { get; set; }
    }
}