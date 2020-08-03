using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SokolovskiyClinicService.Models.DomainModels;

namespace SokolovskiyClinicService.Entity.Repository.WorkDayRepository
{
    public class WorkDayRepository : IWorkDayRepository
    {
        private readonly DataContext _context;

        public WorkDayRepository(DataContext context)
        {
            _context = context;
        }

        public int GetOrAddNewWorkDay(TimeSpan beginOfDay, TimeSpan endOfDay)
        {
            var workDayInBase = _context.workDays.FirstOrDefault(w =>
                w.BeginOfDay == beginOfDay && w.EndOfDay == endOfDay);
            if (workDayInBase != null)
            {
                return workDayInBase.Id;
            }
            var newWorkDay = new WorkDay
            {
                BeginOfDay = beginOfDay,
                EndOfDay = endOfDay
            };
            _context.Entry(newWorkDay).State = EntityState.Added;
            _context.SaveChanges();
            return newWorkDay.Id;
        }

        public WorkDay GetById(int workDayId)
        {
            return _context.workDays.FirstOrDefault(w => w.Id == workDayId);
        }
    }
}