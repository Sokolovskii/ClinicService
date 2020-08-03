using System;
using System.Collections.Generic;
using SokolovskiyClinicService.Models.DomainModels;

namespace SokolovskiyClinicService.Entity.Repository.SessionRepository
{
    /// <summary>
    /// Интерфейс репозитория сессии
    /// </summary>
    public interface ISessionRepository
    {
        /// <summary>
        /// Возвращает сессию по Id
        /// </summary>
        Session GetSessionById(int sessionId);

        /// <summary>
        /// Возвращает список сессий по Id врача
        /// </summary>
        IEnumerable<Session> GetSessionsByDoctorId(int doctorId);

        /// <summary>
        /// Возвращает список сессий по Id врача и даты
        /// </summary>
        IEnumerable<Session> GetSessionsByDoctorIdAndDate(int doctorId, DateTime date);

        /// <summary>
        /// Добавляет сессию в базу
        /// </summary>
        int AddNewSession(Session session);

        /// <summary>
        /// Удаляет сессию из базы
        /// </summary>
        void DeleteSession(int sessionId);
    }
}