using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SokolovskiyClinicService.Models.DomainModels;
using SokolovskiyClinicService.Models.TransferModels;

namespace SokolovskiyClinicService.Entity.Repository.ScheduleRepository
{
    /// <summary>
    /// Репозиторий графиков работы
    /// </summary>
    /// <inheritdoc cref="IScheduleRepository"/>
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly DataContext _context;

        public ScheduleRepository(DataContext context)
        {
            _context = context;
        }

        
        public void AddOrUpdateSchedule(Schedule schedule)
        {
            schedule.ActualisationDate = schedule.ActualisationDate.Date;
            var scheduleInBase = _context.Schedules.FirstOrDefault(s =>
                s.ActualisationDate == schedule.ActualisationDate && s.DoctorId == schedule.DoctorId);
            if (scheduleInBase != null)
            {
                _context.Entry(scheduleInBase).State = EntityState.Modified;
            }
            else
                _context.Entry(schedule).State = EntityState.Added;

            _context.SaveChanges();
        }

        public void AddFirstSchedule(Schedule schedule)
        {
            _context.Entry(schedule).State = EntityState.Added;
            _context.SaveChanges();
        }

        public IEnumerable<Schedule> GetSchedulesByDoctorId(int doctorId)
        {
            return _context.Schedules.Where(s => s.DoctorId == doctorId).ToList();
        }

        public IEnumerable<Schedule> GetAllSchedules()
        {
            return _context.Schedules.ToList();
        }

        public void DeleteScheduleByDoctorId(int doctorId)
        {
            _context.Entry(_context.Schedules.Where(s => s.DoctorId == doctorId)).State = EntityState.Deleted;
            _context.SaveChanges();
        }
    }
}