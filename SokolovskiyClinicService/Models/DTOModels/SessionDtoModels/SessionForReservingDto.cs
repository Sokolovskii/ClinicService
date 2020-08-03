using System;
using System.Runtime.Serialization;

namespace SokolovskiyClinicService.Models.DTOModels.SessionDtoModels
{
    /// <summary>
    /// Dto модуль сессии для резервирования
    /// </summary>
    [DataContract]
    public class SessionForReservingDto
    {
        /// <summary>
        /// Дата сеанса
        /// </summary>
        [DataMember(Name = "date")]
        public DateTime Date { get; set; }
        
        /// <summary>
        /// Начало сеанса
        /// </summary>
        [DataMember(Name = "timeOfBeginSession")]
        public string TimeOfBeginSession { get; set; }
        
        /// <summary>
        /// Id врача, осуществляющего прием
        /// </summary>
        [DataMember(Name = "doctorId")]

        public int DoctorId { get; set; }
    }
}