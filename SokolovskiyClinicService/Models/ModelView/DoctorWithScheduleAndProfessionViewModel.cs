using SokolovskiyClinicService.Models.DomainModels;

namespace SokolovskiyClinicService.Models.ModelView
{
    /// <summary>
    /// ViewModel для доктора
    /// </summary>
    public class DoctorWithScheduleAndProfessionViewModel
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
        /// Данные о расписании
        /// </summary>
        public WorkDay Schedule { get;}

        /// <summary>
        /// Конструктор
        /// </summary>
        public DoctorWithScheduleAndProfessionViewModel(Doctor doctor, Profession profession, WorkDay workDay)
        {
            Doctor = new DoctorViewModel(doctor);
            Profession = new ProfessionViewModel(profession);
            Schedule = workDay;
        }
        
    }
}