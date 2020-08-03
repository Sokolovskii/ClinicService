using System.Runtime.Serialization;
using SokolovskiyClinicService.Models.DomainModels;

namespace SokolovskiyClinicService.Models.DTOModels
{
    /// <summary>
    /// Модель DTO профессии
    /// </summary>
    [DataContract]
    public class ProfessionDto
    {
        /// <summary>
        /// Id профессии
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }
        
        /// <summary>
        /// название профессии
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        public ProfessionDto(Profession profession)
        {
            Id = profession.Id;
            Name = profession.Name;
        }
        
        public ProfessionDto(){}
    }
}