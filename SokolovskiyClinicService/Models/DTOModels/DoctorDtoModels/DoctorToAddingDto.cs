using System.Runtime.Serialization;

namespace SokolovskiyClinicService.Models.DTOModels.DoctorDtoModels
{
    /// <summary>
    /// ТО модель доктора для добавления в базу
    /// </summary>
    [DataContract]
    public class DoctorToAddingDto
    {
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

        /// <summary>
        /// Специализация врача в случае добавления новой специальности
        /// </summary>
        [DataMember(Name = "specialisation")]
        public string Specialisation { get; set; }
    }
}