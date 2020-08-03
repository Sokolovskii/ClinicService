using System;
using System.Collections.Generic;
using SokolovskiyClinicService.Models.DomainModels;
using SokolovskiyClinicService.Models.TransferModels;

namespace SokolovskiyClinicService.Entity.Repository.ScheduleRepository
{
    /// <summary>
    /// Интерфейс репозитория графиков работы
    /// </summary>
    public interface IScheduleRepository
    {
        /// <summary>
        /// Добавляет новый график работы
        /// </summary>
        void AddOrUpdateSchedule(Schedule schedule);

        /// <summary>
        /// Добавляет первый график работы для врача
        /// </summary>
        void AddFirstSchedule(Schedule schedule);

        /// <summary>
        /// Возвращает список всех графиков работы для врача по его Id
        /// </summary>
        IEnumerable<Schedule> GetSchedulesByDoctorId(int doctorId);

        /// <summary>
        /// Возвращает все актуальные расписания
        /// </summary>
        IEnumerable<Schedule> GetAllSchedules();

        /// <summary>
        /// Удаляет все расписания, которые закреплены на врача
        /// </summary>
        void DeleteScheduleByDoctorId(int doctorId);
    }
}