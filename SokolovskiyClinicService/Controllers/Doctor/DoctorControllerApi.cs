using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SokolovskiyClinicService.BusinessLogic.DoctorServices;
using SokolovskiyClinicService.DataHandler.Response;
using SokolovskiyClinicService.DataHandler.Validators;
using SokolovskiyClinicService.Models.DTOModels.ScheduleDtoModels;
using SokolovskiyClinicService.Models.TransferModels;

namespace SokolovskiyClinicService.Controllers.Doctor
{
    /// <summary>
    /// API доктора
    /// </summary>
    [Route("Home/api/doctor")]
    public class DoctorControllerApi : ControllerBase
    {
        private readonly IDoctorServices _doctorServices;

        public DoctorControllerApi(IDoctorServices doctorServices)
        {
            _doctorServices = doctorServices;
        }

        [HttpPost("AddNewSchedule")]
        [Authorize(Roles = "Doctor")]
        public ControllerResponse AddNewSchedule([FromBody]ScheduleToAddingDto scheduleToAddingDto)
        {
            var doctorId = 0;
            if (User.Identity.IsAuthenticated)
            {
                doctorId = int.Parse(User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
            }

            if (!scheduleToAddingDto.ValidateScheduleForAdd())
            {
                return ControllerResponse.Warning("Данные были не введены или введены не полностью, повторите запрос");
            }
            _doctorServices.AddNewSchedule(new ScheduleTransfer(scheduleToAddingDto, doctorId));
            return ControllerResponse.Ok();
        }

        [Authorize(Roles = "Doctor")]
        [HttpPost("AddOrUpdateSchedule")]
        public ControllerResponse AddOrUpdateSchedule([FromBody] ScheduleDto scheduleToRender)
        {
            var doctorId = 0;
            if (User.Identity.IsAuthenticated)
            {
                doctorId = int.Parse(User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
            }
            
            if (!scheduleToRender.ValidateScheduleToUpdating())
            {
                return ControllerResponse.Warning("Данные были не введены или введены не полностью, повторите запрос");
            }
            _doctorServices.UpdateSchedule(new ScheduleWithDateTransfer(scheduleToRender, doctorId));
            return ControllerResponse.Ok();
        }

        [HttpPost("AddProfession")]
        [Authorize(Roles = "Doctor")]
        public ControllerResponse AddProfession([FromBody] int professionId)
        {
            var doctorId = 0;
            if (User.Identity.IsAuthenticated)
            {
                doctorId = int.Parse(User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
            }
            
            if (!professionId.ValidationId())
            {
                return ControllerResponse.Warning("Данные не были введены, повторите запрос");
            }
            _doctorServices.AddProfession(doctorId, professionId);
            return ControllerResponse.Ok();
        }
    }
}