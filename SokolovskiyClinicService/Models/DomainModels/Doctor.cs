using System;
using System.ComponentModel.DataAnnotations;
using SokolovskiyClinicService.Models.DTOModels;

namespace SokolovskiyClinicService.Models.DomainModels
{
    /// <summary>
    /// Модель, описывающая сущность доктора в клинике
    /// </summary>
    public class Doctor
    {
        /// <summary>
        /// Id доктора
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Имя доктора
        /// </summary>
        [Required]
        public string Name { get; set; }
        
        /// <summary>
        /// Профессия доктора
        /// </summary>
        public int ProfessionId { get; set; }
        
        /// <summary>
        /// Дата увольнения врача, не дефолтная, если доктор будет уволен
        /// </summary>
        public DateTime DateOfDismissal { get; set; }

        /// <summary>
        /// Флаг удаления врача
        /// </summary>
        public bool IsRemoved { get; set; }
        
        /// <summary>
        /// Флаг одобренности врача администратором
        /// </summary>
        public bool IsApproved { get; set; }
    }
}