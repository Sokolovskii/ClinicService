using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SokolovskiyClinicService.Exceptions;
using SokolovskiyClinicService.Models.DomainModels;

namespace SokolovskiyClinicService.Entity.Repository.SessionRepository
{
    /// <summary>
    /// Класс репозитория сессии
    /// </summary>
    /// <inheritdoc cref="ISessionRepository"/>
    public class SessionRepository : ISessionRepository
    {
        /// <summary>
        /// Контекст данных
        /// </summary>
        private readonly DataContext _context;

        /// <summary>
        /// .ctor
        /// </summary>
        public SessionRepository(DataContext context)
        {
            _context = context;
        }
        
        public Session GetSessionById(int sessionId)
        {
            return _context.Sessions.SingleOrDefault(s => s.Id == sessionId)
                ?? throw new WarningException(ExceptionMessages.SessionNotFound);
        }

        public IEnumerable<Session> GetSessionsByDoctorId(int doctorId)
        {
            return _context.Sessions.Where(s => s.DoctorId == doctorId).ToList();
        }

        public IEnumerable<Session> GetSessionsByDoctorIdAndDate(int doctorId, DateTime date)
        {
            return _context.Sessions.Where(s => s.DoctorId == doctorId & s.Date==date).ToList();
        }

        public int AddNewSession(Session session)
        {
            _context.Entry(session).State = EntityState.Added;
            _context.SaveChanges();
            return session.Id;
        }

        public void DeleteSession(int sessionId)
        {
            var session = _context.Sessions.SingleOrDefault(s => s.Id == sessionId)
                ?? throw new WarningException(ExceptionMessages.SessionHasntInBase);
            _context.Entry(session).State = EntityState.Deleted;
            _context.SaveChanges();
        }
    }
}