using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SokolovskiyClinicService.Exceptions;
using SokolovskiyClinicService.Models.DomainModels;

namespace SokolovskiyClinicService.Entity.Repository.DoctorRepository
{
    /// <summary>
    /// Класс репозитория врачей
    /// </summary>
    /// <inheritdoc cref="IDoctorRepository"/>
    public class DoctorRepository : IDoctorRepository
    {
        /// <summary>
        /// Контекст данных
        /// </summary>
        private readonly DataContext _context;

        /// <summary>
        /// .ctor
        /// </summary>
        public DoctorRepository(DataContext context)
        {
            _context = context;
        }
        
        public Doctor GetDoctorById(int doctorId)
        {
            return _context.Doctors.SingleOrDefault(d => d.Id == doctorId)
                    ?? throw new WarningException(ExceptionMessages.DoctorNotFound);
        }

        public IEnumerable<Doctor> GetAllDoctors()
        {
            return _context.Doctors.ToList().Where(d=>!d.IsRemoved || (d.IsRemoved && d.DateOfDismissal > DateTime.Today)).ToList();
        }

        public IEnumerable<Doctor> GetDoctorsByProfession(int professionId)
        {
            
            return GetAllDoctors().Where(d => d.ProfessionId == professionId).ToList();
        }

        public void AddNewDoctor(string doctorName, int doctorId)
        {
            var doctor = new Doctor
            {
                Id = doctorId, 
                Name = doctorName,
                IsRemoved = false,
                IsApproved = false
            };

            _context.Entry(doctor).State = EntityState.Added;
            _context.Database.OpenConnection();
            try
            {
                _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Doctors ON");
                _context.SaveChanges();
                _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Doctors OFF");
            }
            finally
            {
                _context.Database.CloseConnection();
            }
        }

        public DateTime DeleteDoctor(int doctorId, DateTime dateOfDismissal)
        {
            var doctor = _context.Doctors.SingleOrDefault(d => d.Id == doctorId)
                         ?? throw new WarningException(ExceptionMessages.DoctorHasntInBase);
            doctor.IsRemoved = true;
            doctor.DateOfDismissal = dateOfDismissal.Add(TimeSpan.FromDays(14));
            UpdateDoctor(doctor);
            return doctor.DateOfDismissal;
        }

        public void UpdateDoctor(Doctor doctor)
        {
            _context.Entry(doctor).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void AddProfession(int doctorId, int professionId)
        {
            _context.Doctors.First(d => d.Id == doctorId).ProfessionId = professionId;
            _context.SaveChanges();
        }

        public void UpdateDoctorStatus(int doctorId)
        {
            _context.Doctors.First(d => d.Id == doctorId).IsApproved = false;
            _context.SaveChanges();
        }

        public void ApproveDoctor(int doctorId)
        {
            _context.Doctors.First(d => d.Id == doctorId).IsApproved = true;
            _context.SaveChanges();
        }

        public void DisapproveDoctor(int doctorId)
        {
            _context.Entry(_context.Doctors.First(d => d.Id == doctorId)).State = EntityState.Deleted;
            _context.SaveChanges();
        }
    }
}