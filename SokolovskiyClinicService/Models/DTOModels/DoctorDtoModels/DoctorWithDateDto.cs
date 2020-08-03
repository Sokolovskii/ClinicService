using System;

namespace SokolovskiyClinicService.Models.DTOModels.DoctorDtoModels
{
    /// <summary>
    /// ДТО модель доктора и даты для просмотра всех сессий
    /// </summary>
    public class DoctorWithDateDto
    {
        /// <summary>
        /// Id доктора
        /// </summary>
        public int DoctorId { get; set;}
        
        /// <summary>
        /// Дата, на которую пользователь хочет посмотреть записи
        /// </summary>
        public DateTime DateTime { get; set; }
    }
}