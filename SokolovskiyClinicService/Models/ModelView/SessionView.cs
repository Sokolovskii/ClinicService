using System;
using System.Collections.Generic;

namespace SokolovskiyClinicService.Models.ModelView
{
    /// <summary>
    /// ViewModel для рендера страницы списка сеансов у врача
    /// </summary>
    public class SessionView
    {
        /// <summary>
        /// Сессии
        /// </summary>
        public Dictionary<TimeSpan, SessionViewModel> Sessions { get; set; }
        
        /// <summary>
        /// Доктор с расписанием и профессией
        /// </summary>
        public DoctorWithScheduleAndProfessionViewModel Doctor { get; set; }
        
        /// <summary>
        /// Дата требуемая к просмотру
        /// </summary>
        public DateTime DateTime { get; set; }
        
        /// <summary>
        /// Id действующего пользователя
        /// </summary>
        public int UserId { get; set; }
    }
}