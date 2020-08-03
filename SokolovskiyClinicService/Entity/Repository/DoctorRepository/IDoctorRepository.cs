using System;
using System.Collections.Generic;
using SokolovskiyClinicService.Models.DomainModels;

namespace SokolovskiyClinicService.Entity.Repository.DoctorRepository
{
    /// <summary>
    /// Интерфейс репозитория докторов
    /// </summary>
    public interface IDoctorRepository
    {
        /// <summary>
        /// Возвращает врача по его Id
        /// </summary>
        Doctor GetDoctorById(int doctorId);

        /// <summary>
        /// Возвращает список всех врачей, которые не являются уволенными
        /// </summary>
        /// <returns></returns>
        IEnumerable<Doctor> GetAllDoctors();

        /// <summary>
        /// Возвращает список всех врачей по id специализации
        /// </summary>
        IEnumerable<Doctor> GetDoctorsByProfession(int professionId);

        /// <summary>
        /// Вносит врача в базу и возвращает его Id
        /// </summary>
        void AddNewDoctor(string doctorName, int doctorId);

        /// <summary>
        /// Удаляет врача из базы
        /// </summary>
        DateTime DeleteDoctor(int doctorId, DateTime dateOfDismissal);

        /// <summary>
        /// Добавляет доктору профессию
        /// </summary>
        void AddProfession(int doctorId, int professionId);

        /// <summary>
        /// Изменяет статус врача
        /// </summary>
        /// <param name="doctorId"></param>
        void UpdateDoctorStatus(int doctorId);

        /// <summary>
        /// Одобряет заявку врача
        /// </summary>
        void ApproveDoctor(int doctorId);

        /// <summary>
        /// Отклоняет заявку врача
        /// </summary>
        /// <param name="doctorId"></param>
        void DisapproveDoctor(int doctorId);
    }
}