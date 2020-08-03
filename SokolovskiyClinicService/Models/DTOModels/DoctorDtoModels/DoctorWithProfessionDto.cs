namespace SokolovskiyClinicService.Models.DTOModels.DoctorDtoModels
{
    /// <summary>
    /// DTO модель для регистрации профессии у врача
    /// </summary>
    public class DoctorWithProfessionDto
    {
        /// <summary>
        /// Id врача
        /// </summary>
        public int DoctorId { get; set; }
        
        /// <summary>
        /// Id профессии
        /// </summary>
        public int ProfessionId { get; set; }
    }
}