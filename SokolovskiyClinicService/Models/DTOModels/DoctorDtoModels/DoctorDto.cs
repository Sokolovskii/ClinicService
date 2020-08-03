using System.Runtime.Serialization;
using SokolovskiyClinicService.Models.DomainModels;

namespace SokolovskiyClinicService.Models.DTOModels.DoctorDtoModels
{
    /// <summary>
    /// Модель DTO врача
    /// </summary>
    [DataContract]
    public class DoctorDto
    {
        /// <summary>
        /// Id доктора
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }
        
        /// <summary>
        /// Имя доктора
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }
        
        /// <summary>
        /// Профессия доктора
        /// </summary>
        [DataMember(Name = "professionId")]
        public int ProfessionId { get; set; }
        
        public DoctorDto(Doctor doctor)
        {
            Id = doctor.Id;
            Name = doctor.Name;
            ProfessionId = doctor.ProfessionId;
        }
        
        public DoctorDto(){}
    }
}