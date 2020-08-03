using SokolovskiyClinicService.Models.TransferModels;

namespace SokolovskiyClinicService.BusinessLogic.DoctorServices
{
    public interface IDoctorServices
    {
        /// <summary>
        /// Добавляет первое расписание для врача
        /// </summary>
        /// <param name="scheduleTransfer">Переходной объект расписания</param>
        void AddNewSchedule(ScheduleTransfer scheduleTransfer);

        /// <summary>
        /// Обновляет или добавляет расписание для врача, имеющего расписание
        /// </summary>
        /// <param name="scheduleWithDateTransfer">Переходной объект расписания с датой актуализации</param>
        void UpdateSchedule(ScheduleWithDateTransfer scheduleWithDateTransfer);

        /// <summary>
        /// Добавляет врачу профессию
        /// </summary>
        /// <param name="doctorId"></param>
        /// <param name="professionId">Id профессии</param>
        void AddProfession(int doctorId, int professionId);
    }
}