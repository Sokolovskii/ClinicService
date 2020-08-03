using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SokolovskiyClinicService.Models;
using SokolovskiyClinicService.Models.ModelView;
using SokolovskiyClinicService.BusinessLogic.UserServices;
using SokolovskiyClinicService.DataHandler.Response;
using SokolovskiyClinicService.DataHandler.Validators;
using SokolovskiyClinicService.Models.DTOModels;
using SokolovskiyClinicService.Models.DTOModels.SessionDtoModels;

namespace SokolovskiyClinicService.Controllers.User
{
    /// <summary>
    /// API контроллер пользователя
    /// </summary>
    [Route("Home/api/user")]
    public class UserControllerApi : ControllerBase
    {
        private readonly IUserServices _userServices;

        public UserControllerApi(IUserServices userServices)
        {
            _userServices = userServices;
        }

        /// <summary>
        /// Запись к врачу
        /// </summary>
        /// <param name="sessionDto">Сессия с указанием Id врача и пациента</param> 
        [HttpPost("ReserveSession")]
        [Authorize(Roles = "User")]
        public ControllerResponse<int> ReserveSession([FromBody] SessionForReservingDto sessionDto)
        {
            var userId = 0;
            if (User.Identity.IsAuthenticated)
            {
                userId = int.Parse(User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
            }
            if (!UserValidator.ValidateSessionToReserve(sessionDto, userId))
            {
                return ControllerResponse<int>.Warning(
                    "Произошел сбой. Проверьте корректность введенных данных и повторите запрос");
            }

            if (!UserValidator.ValidateTimeForReserving(sessionDto))
            {
                return ControllerResponse<int>.Warning(
                    "Время для записи некорректно, выберете корректную дату для записи");
            }

            return ControllerResponse<int>.Ok(_userServices.ReserveSession(sessionDto.Date,
                TimeSpan.Parse(sessionDto.TimeOfBeginSession), sessionDto.DoctorId, userId));
        }

        /// <summary>
        /// Отменяет запись к врачу
        /// </summary>
        /// <param name="sessionId">Id сессии</param>
        [HttpPost("UnreserveSession")]
        [Authorize(Roles = "User")]
        public ControllerResponse UnreserveSession([FromBody] int sessionId)
        {
            var userId = 0;
            if (User.Identity.IsAuthenticated)
            {
                userId = int.Parse(User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
            }
            if (!UserValidator.ValidateSessionToCancel(sessionId, userId))
            {
                return ControllerResponse.Warning(
                    "Произошел сбой. Проверьте корректность введенных данных и повторите запрос");
            }

            _userServices.CancelSession(sessionId, userId);
            return ControllerResponse.Ok();
        }
    }
}