using System;
using SokolovskiyClinicService.Models.TransferModels;

namespace SokolovskiyClinicService.BusinessLogic.AdminServices
{
    /// <summary>
    /// Интерфейс сервисов администратора
    /// </summary>
    public interface IAdminServices
    {
        /// <summary>
        /// Удаляет врача из базы
        /// </summary>
        DateTime DismissDoctor(int doctorId, DateTime dateOfDismissal);

        /// <summary>
        /// Меняет общий график работы врача
        /// </summary>
        void UpdateSchedule(ScheduleWithDateTransfer scheduleWithDateTransfer);

        /// <summary>
        /// Одобряет заявку доктора на зачисление в штат
        /// </summary>
        void ApproveDoctor(int doctorId);

        /// <summary>
        /// Отклоняет заявку врача
        /// </summary>
        void DisapproveDoctor(int doctorId);

        /// <summary>
        /// Добавляет в базу новую профессию
        /// </summary>
        void AddNewProfession(string professionName);
    }
}