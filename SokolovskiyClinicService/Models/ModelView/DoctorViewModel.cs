using System;
using SokolovskiyClinicService.Models.DomainModels;

namespace SokolovskiyClinicService.Models.ModelView
{
    public class DoctorViewModel
    {
        /// <summary>
        /// Id доктора
        /// </summary>
        public int Id { get;}
        
        /// <summary>
        /// Имя доктора
        /// </summary>
        public string Name { get;}

        /// <summary>
        /// Дата удаления сотрудника
        /// </summary>
        public DateTime DateOfDismissal { get; }
        
        /// <summary>
        /// Флаг увольнения врача
        /// </summary>
        public bool IsRemoved { get; }
        
        /// <summary>
        /// Флаг одобренности заявки
        /// </summary>
        public bool IsApproved { get; }

        public DoctorViewModel(Doctor doctor)
        {
            Id = doctor.Id;
            Name = doctor.Name;
            DateOfDismissal = doctor.DateOfDismissal;
            IsRemoved = doctor.IsRemoved;
            IsApproved = doctor.IsApproved;
        }
        
        public DoctorViewModel(){}
    }
}