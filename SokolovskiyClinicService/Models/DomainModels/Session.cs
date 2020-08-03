using System;
using System.ComponentModel.DataAnnotations;
using SokolovskiyClinicService.Models.DTOModels;

namespace SokolovskiyClinicService.Models.DomainModels
{
    /// <summary>
    /// Модель, описывающая сеанс у доктора
    /// </summary>
    public class Session
    {
        /// <summary>
        /// Id сессии
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Дата сеанса
        /// </summary>
        public DateTime Date { get; set; }
        
        /// <summary>
        /// Начало сеанса
        /// </summary>
        public TimeSpan TimeOfBeginSession { get; set; }
        
        /// <summary>
        /// Конец сеанса
        /// </summary>
        public TimeSpan TimeOfEndSession { get; set; }

        /// <summary>
        /// Id врача, осуществляющего прием
        /// </summary>
        public int DoctorId { get; set; }

        /// <summary>
        /// Id пациента
        /// </summary>
        public int UserId { get; set; }
    }
}