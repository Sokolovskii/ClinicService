using SokolovskiyClinicService.Models.DTOModels.DoctorDtoModels;
using SokolovskiyClinicService.Models.DTOModels.ScheduleDtoModels;

namespace SokolovskiyClinicService.Models.DTOModels
{
    /// <summary>
    /// DTO модель доктора с расписанием
    /// </summary>
    public class DoctorWithScheduleDto
    {
        /// <summary>
        /// DTO модель доктора
        /// </summary>
        public DoctorToAddingDto DoctorDto { get; set; }
        
        /// <summary>
        /// DTO модель расписания
        /// </summary>
        public ScheduleToAddingDto ScheduleDto { get; set; }
    }
}