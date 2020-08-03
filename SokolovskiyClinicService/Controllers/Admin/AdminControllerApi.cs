using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SokolovskiyClinicService.BusinessLogic.AdminServices;
using SokolovskiyClinicService.DataHandler.Response;
using SokolovskiyClinicService.DataHandler.Validators;
using SokolovskiyClinicService.Models.DTOModels.DoctorDtoModels;
using SokolovskiyClinicService.Models.DTOModels.ScheduleDtoModels;
using SokolovskiyClinicService.Models.TransferModels;

namespace SokolovskiyClinicService.Controllers.Admin
{
    /// <summary>
    /// API контроллер авторизации
    /// </summary>
    [Route("Home/api/admin")]
    public class AdminControllerApi : ControllerBase
    {
        private readonly IAdminServices _adminServices;

        public AdminControllerApi(IAdminServices adminServices)
        {
            _adminServices = adminServices;
        }

        /// <summary>
        /// Удаляет врача
        /// </summary>
        /// <param name="doctorForDeletingDto">Id врача и дата удаления</param>
        [HttpPost("DeleteDoctor")]
        [Authorize(Roles = "Admin")]
        public ControllerResponse<string> DeleteDoctor([FromBody] DoctorForDeletingDto doctorForDeletingDto)
        {
            if (!doctorForDeletingDto.DoctorId.ValidationId() && doctorForDeletingDto.DateOfDismissal == default)
            {
                return ControllerResponse<string>.Warning("Запрос не был правильно сформирован, повторите попытку");
            }
            
            return ControllerResponse<string>.Ok(_adminServices.DismissDoctor(doctorForDeletingDto.DoctorId, doctorForDeletingDto.DateOfDismissal).ToString("D"));
        }

        /// <summary>
        /// Изменяет расписание врача
        /// </summary>
        /// <param name="scheduleToRender">расписание для конкретного врача</param>
        [HttpPost("ChangeDoctorSchedule")]
        [Authorize(Roles = "Admin")]
        public ControllerResponse ChangeDoctorSchedule([FromBody] ScheduleFullDto scheduleToRender)
        {
            if (!AdminValidator.ValidateScheduleForUpdating(scheduleToRender))
            {
                return ControllerResponse.Warning("Данные были не введены или введены не полностью, повторите запрос");
            }

            _adminServices.UpdateSchedule(new ScheduleWithDateTransfer(scheduleToRender));
            return ControllerResponse.Ok();
        }

        /// <summary>
        /// Одобряет заявку врача
        /// </summary>
        [HttpPost("ApproveDoctor")]
        [Authorize(Roles = "Admin")]
        public ControllerResponse ApproveDoctor([FromBody] int doctorId)
        {
            if (!doctorId.ValidationId())
            {
                return ControllerResponse.Warning("Запрос не был правильно сформирован, повторите попытку");
            }
            _adminServices.ApproveDoctor(doctorId);
            return ControllerResponse.Ok();
        }

        [HttpPost("DisapproveDoctor")]
        [Authorize(Roles = "Admin")]
        public ControllerResponse DisapproveDoctor([FromBody] int doctorId)
        {
            if (!doctorId.ValidationId())
            {
                return ControllerResponse.Warning("Запрос не был правильно сформирован, повторите попытку");
            }
            _adminServices.DisapproveDoctor(doctorId);
            return ControllerResponse.Ok();
        }

        /// <summary>
        /// Вносит новую профессию в базу
        /// </summary>
        [HttpPost("AddNewProfession")]
        [Authorize(Roles = "Admin")]
        public ControllerResponse AddNewProfession([FromBody] string professionName)
        {
            if (string.IsNullOrWhiteSpace(professionName))
            {
                return ControllerResponse.Warning("");
            }
            _adminServices.AddNewProfession(professionName);
            return ControllerResponse.Ok();
        }
    }
}