using System;
using System.Collections.Generic;
using SokolovskiyClinicService.Models.DomainModels;

namespace SokolovskiyClinicService.BusinessLogic.CommonServices
{
    /// <summary>
    /// Интерфейс общих сервисов, которыми пользуются все пользователи
    /// </summary>
    public interface ICommonServices
    {
        /// <summary>
        /// Возвращает список всех актуальных расписаний на докторов
        /// </summary>
        IEnumerable<Schedule> GetAllActualSchedules(DateTime dateNow);
        
        /// <summary>
        /// Возвращает актуальное расписание доктора на дату
        /// </summary>
        Schedule GetScheduleOnDate(int doctorId, DateTime dateTime);
        
        /// <summary>
        /// Возвращает список всех профессий
        /// </summary>
        IEnumerable<Profession> GetAllProfessions();

        /// <summary>
        /// Возвращает список врачей по специальности
        /// </summary>
        IEnumerable<Doctor> GetDoctorsByProfession(int professionId);

        /// <summary>
        /// Запрашивает список сессий для определенного врача и даты
        /// </summary>
        Dictionary<TimeSpan, Session> GetSessionsByDoctorIdAndDate(int doctorId, DateTime date);

        /// <summary>
        /// Возвращает врача по его Id
        /// </summary>
        Doctor GetDoctorById(int doctorId);
        
        /// <summary>
        /// Возвращает список всех врачей
        /// </summary>
        /// <returns></returns>
        IEnumerable<Doctor> GetAllDoctors();

        /// <summary>
        /// Возвращает профессию по Id врача
        /// </summary>
        Profession GetProfessionByDoctorId(int doctorId);

        /// <summary>
        /// Возвращает рабочий день по его Id 
        /// </summary>
        WorkDay GetWorkDayById(int workDayId);

        /// <summary>
        /// Возвращает рабочий день из расписания по дате
        /// </summary>
        WorkDay ExtractWorkDayFromSchedule(Schedule schedule, DateTime dateTime);
    }
}