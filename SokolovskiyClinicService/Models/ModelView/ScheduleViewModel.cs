using SokolovskiyClinicService.Models.DomainModels;

namespace SokolovskiyClinicService.Models.ModelView
{
    public class ScheduleViewModel
    {
        /// <summary>
        /// Рабочий день в понедельник
        /// </summary>
        public WorkDay Monday { get; set; }
        
        /// <summary>
        /// Рабочий день в понедельник
        /// </summary>
        public WorkDay Tuesday { get; set; }
        
        /// <summary>
        /// Рабочий день в понедельник
        /// </summary>
        public WorkDay Wednesday { get; set; }
        
        /// <summary>
        /// Рабочий день в понедельник
        /// </summary>
        public WorkDay Thursday { get; set; }
        
        /// <summary>
        /// Рабочий день в понедельник
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
    }
}