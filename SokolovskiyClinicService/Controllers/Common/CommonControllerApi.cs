using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SokolovskiyClinicService.BusinessLogic.CommonServices;
using SokolovskiyClinicService.DataHandler.Response;
using SokolovskiyClinicService.DataHandler.Validators;
using SokolovskiyClinicService.Models.DTOModels;
using SokolovskiyClinicService.Models.DTOModels.DoctorDtoModels;
using SokolovskiyClinicService.Models.DTOModels.ScheduleDtoModels;
using SokolovskiyClinicService.Models.ModelView;

namespace SokolovskiyClinicService.Controllers.Common
{
    /// <summary>
    /// Класс общего контроллера
    /// </summary>
    [Route("Home/api/common")]
    [Route("api/common")]
    public class CommonControllerApi : ControllerBase
    {
        private readonly ICommonServices _commonServices;

        public CommonControllerApi(ICommonServices commonServices)
        {
            _commonServices = commonServices;
        }
        
        [HttpGet("GetAllActualSchedules")]
        public ControllerResponse<IEnumerable<ScheduleFullDto>> GetAllActualSchedules(DateTime dateNow)
        {
            return ControllerResponse<IEnumerable<ScheduleFullDto>>.Ok(_commonServices
                .GetAllActualSchedules(dateNow).Select(s =>new ScheduleFullDto
            {
                DoctorId = s.DoctorId,
                ActualisationDate = s.ActualisationDate,
                Monday = new WorkDayDto(_commonServices.GetWorkDayById(s.MondayId)),
                Tuesday = new WorkDayDto(_commonServices.GetWorkDayById(s.TuesdayId)),
                Wednesday = new WorkDayDto(_commonServices.GetWorkDayById(s.WednesdayId)),
                Thursday = new WorkDayDto(_commonServices.GetWorkDayById(s.ThursdayId)),
                Friday = new WorkDayDto(_commonServices.GetWorkDayById(s.FridayId))
            }));
        }
        
        /// <summary>
        /// Возвращает список всех специальностей в клинике
        /// </summary>
        /// <returns>Список всех специальностей</returns>
        [HttpGet("getAllProfessions")]
        public ControllerResponse<IEnumerable<ProfessionDto>> GetAllProfessions()
        {
            return ControllerResponse<IEnumerable<ProfessionDto>>.Ok(_commonServices.GetAllProfessions()
                .Select(p => new ProfessionDto(p)));
        }
        
        /// <summary>
        /// Возвращает список сессий на определенного врача и дату
        /// </summary>
        /// <param name="doctorId">Id доктора</param>
        /// <param name="dateTime">Дата, на которую нужно найти сессии</param>
        /// <returns>Список сессий</returns>
        [HttpGet("getSessionsOnDoctorAndDate")]
        public ControllerResponse<IEnumerable<KeyValuePair<TimeSpan,SessionViewModel>>> GetSessionsByDoctorAndDate(int doctorId, DateTime dateTime)
        {
            if (!UserValidator.ValidateDoctorAndDateToGetting(doctorId,
                dateTime))

                return ControllerResponse<IEnumerable<KeyValuePair<TimeSpan,SessionViewModel>>>.Warning(
                    "Доктор или дата приема не указаны или указаны неверно, повторите запрос");

            return ControllerResponse<IEnumerable<KeyValuePair<TimeSpan,SessionViewModel>>>.Ok(_commonServices
                .GetSessionsByDoctorIdAndDate(doctorId,
                    dateTime)
                .Select(kvp => new KeyValuePair<TimeSpan, SessionViewModel>(kvp.Key, SessionViewModel.ConvertToSessionViewModel(kvp.Value))));
        }
        
        /// <summary>
        /// Возвращает список всех врачей по специальности
        /// </summary>
        /// <param name="professionId">Id профессии</param>
        /// <returns>Список врачей</returns>
        [HttpGet("GetAllDoctorsByProfession")]
        public ControllerResponse<IEnumerable<DoctorDto>> GetAllDoctorsByProfession(int professionId)
        {
            if (!professionId.ValidationId())

                return ControllerResponse<IEnumerable<DoctorDto>>.Warning(
                    "Профессия врача указана некорректно или произошел сбой, повторите запрос");

            return ControllerResponse<IEnumerable<DoctorDto>>.Ok(_commonServices
                .GetDoctorsByProfession(professionId).Select(d => new DoctorDto(d)));
        }
        
        
        /// <summary>
        /// Возвращает актуальное расписание доктора на конкретную дату
        /// </summary>
        /// <param name="doctorId">Id врача</param>
        [HttpGet("getDoctorSchedule")]
        public ControllerResponse<ScheduleFullDto> GetDoctorSchedule(int doctorId)
        {
            if (!doctorId.ValidationId())
            {
                return ControllerResponse<ScheduleFullDto>.Warning(
                    "Произошел сбой. Проверьте правильность введенных данных и повторите запрос");
            }

            var schedule = _commonServices.GetScheduleOnDate(doctorId, DateTime.Today);
            return ControllerResponse<ScheduleFullDto>.Ok(
                new ScheduleFullDto
                {
                    ActualisationDate = schedule.ActualisationDate,
                    Monday = WorkDayDto.GetWorkDayDto(_commonServices.GetWorkDayById(schedule.MondayId)),
                    Tuesday = WorkDayDto.GetWorkDayDto(_commonServices.GetWorkDayById(schedule.TuesdayId)),
                    Wednesday = WorkDayDto.GetWorkDayDto(_commonServices.GetWorkDayById(schedule.WednesdayId)),
                    Thursday = WorkDayDto.GetWorkDayDto(_commonServices.GetWorkDayById(schedule.ThursdayId)),
                    Friday = WorkDayDto.GetWorkDayDto(_commonServices.GetWorkDayById(schedule.FridayId)),
                    Saturday = WorkDayDto.GetWorkDayDto(_commonServices.GetWorkDayById(schedule.SaturdayId)),
                    Sunday = WorkDayDto.GetWorkDayDto(_commonServices.GetWorkDayById(schedule.SundayId))
                });
        }

        /// <summary>
        /// Возвращает профессию по Id доктора
        /// </summary>
        /// <param name="doctorId"></param>
        /// <returns></returns>
        [HttpGet("getProfessionByDoctorId")]
        public ControllerResponse<ProfessionDto> GetProfessionByDoctorId(int doctorId)
        {
            if (!doctorId.ValidationId())
            {
                return ControllerResponse<ProfessionDto>.Warning(
                    "Произошел сбой. Проверьте правильность введенных данных и повторите запрос");
            }

            return ControllerResponse<ProfessionDto>.Ok(new ProfessionDto(_commonServices.GetProfessionByDoctorId(doctorId)));
        }
    }
}