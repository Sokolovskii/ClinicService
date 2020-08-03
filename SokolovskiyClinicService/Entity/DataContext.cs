using System;
using Microsoft.EntityFrameworkCore;
using SokolovskiyClinicService.Models;
using SokolovskiyClinicService.Models.DomainModels;

namespace SokolovskiyClinicService.Entity
{
    /// <summary>
    /// Класс контекста данных
    /// </summary>
    public sealed class DataContext : DbContext
    {
        /// <summary>
        /// Сет пользователей
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Сет докторов
        /// </summary>
        public DbSet<Doctor> Doctors { get; set; }

        /// <summary>
        /// Сет сеансов
        /// </summary>
        public DbSet<Session> Sessions { get; set; }

        /// <summary>
        /// Сет расписаний
        /// </summary>
        public DbSet<Schedule> Schedules { get; set; }

        /// <summary>
        /// Сет профессий
        /// </summary>
        public DbSet<Profession> Professions { get; set; }

        /// <summary>
        /// Сет рабочих дней
        /// </summary>
        public DbSet<WorkDay> workDays { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DataContext()
        {
        }
    }
}