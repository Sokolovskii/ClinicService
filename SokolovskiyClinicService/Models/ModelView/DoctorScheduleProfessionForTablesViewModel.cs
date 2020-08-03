using SokolovskiyClinicService.Models.DomainModels;

namespace SokolovskiyClinicService.Models.ModelView
{
    public class DoctorScheduleProfessionForTablesViewModel
    {
        /// <summary>
        /// Данные о враче
        /// </summary>
        public DoctorViewModel Doctor { get;}
        
        /// <summary>
        /// Данные о профессии
        /// </summary>
        public ProfessionViewModel Profession { get;}

        /// <summary>
        /// Конструктор
        /// </summary>
        public DoctorScheduleProfessionForTablesViewModel(Doctor doctor, Profession profession)
        {
            Doctor = new DoctorViewModel(doctor);
            Profession = new ProfessionViewModel(profession);
        }
    }
}