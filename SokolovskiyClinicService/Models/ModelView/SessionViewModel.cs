#nullable enable
using System;
using System.Runtime.Serialization;
using SokolovskiyClinicService.Models.DomainModels;

namespace SokolovskiyClinicService.Models.ModelView
{
    /// <summary>
    /// Модель DTO сеанса
    /// </summary>
    public class SessionViewModel
    {
        /// <summary>
        /// Id сессии
        /// </summary>
        public int Id { get; }
        
        /// <summary>
        /// Дата сеанса
        /// </summary>
        public DateTime Date { get; }
        
        /// <summary>
        /// Начало сеанса
        /// </summary>
        public string TimeOfBeginSession { get; }
        
        /// <summary>
        /// Конец сеанса
        /// </summary>
        public string TimeOfEndSession { get; }

        /// <summary>
        /// Id врача, осуществляющего прием
        /// </summary>
        public int DoctorId { get; }

        /// <summary>
        /// Id пациента
        /// </summary>
        public int UserId { get; }

        public SessionViewModel(Session session)
        {
            Id = session.Id;
            Date = session.Date;
            TimeOfBeginSession = session.TimeOfBeginSession.ToString();
            TimeOfEndSession = session.TimeOfEndSession.ToString();
            DoctorId = session.DoctorId;
            UserId = session.UserId;
        }

        /// <summary>
        /// Конвертирует доменную модель либо в SessionViewModel, либо в null
        /// </summary>
        public static SessionViewModel? ConvertToSessionViewModel(Session session)
        {
            return session == null ? null : new SessionViewModel(session);
        }
    }
}
