using System;
using System.Runtime.Serialization;

namespace SokolovskiyClinicService.Models.DTOModels.DoctorDtoModels
{
    /// <summary>
    /// DTO модель врача для удаления
    /// </summary>
    [DataContract]
    public class DoctorForDeletingDto
    {
        /// <summary>
        /// Id врача
        /// </summary>
        [DataMember(Name="doctorId")]
        public int DoctorId { get; set; }
        
        /// <summary>
        /// Дата удаления врача, врач перестает отображаться через 2 недели после указанной даты
        /// </summary>
        [DataMember(Name = "dateOfDismissal")]
        public DateTime DateOfDismissal { get; set; }
    }
}