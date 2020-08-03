using SokolovskiyClinicService.Models.DTOModels.DoctorDtoModels;
using SokolovskiyClinicService.Models.DTOModels.ScheduleDtoModels;

namespace SokolovskiyClinicService.DataHandler.Validators
{
    public static class DoctorValidator
    {
        /// <summary>
        /// Техническая валидация данных графика работы
        /// </summary>
        public static bool ValidateScheduleForAdd(this ScheduleToAddingDto scheduleDto)
        {
            return scheduleDto.ValidationOnNull();
        }

        public static bool ValidateScheduleToUpdating(this ScheduleDto schedule)
        {
            return schedule.ValidationOnNull()
                   && schedule.ActualisationDate != default;
        }

        public static bool ValidateDoctorWithProfession(this DoctorWithProfessionDto doctorWithProfessionDto)
        {
            return doctorWithProfessionDto.ValidationOnNull()
                   && doctorWithProfessionDto.DoctorId.ValidationId()
                   && doctorWithProfessionDto.ProfessionId.ValidationId();
        }
    }
}