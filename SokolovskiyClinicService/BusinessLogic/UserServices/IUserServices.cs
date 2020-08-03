using System;
using System.Collections.Generic;
using SokolovskiyClinicService.Models.DomainModels;
using SokolovskiyClinicService.Models.DTOModels;

namespace SokolovskiyClinicService.BusinessLogic.UserServices
{
    /// <summary>
    /// Интерфейс сервисов пользователя
    /// </summary>
    public interface IUserServices
    {
        /// <summary>
        /// Записаться к врачу
        /// </summary>
        int ReserveSession(DateTime dateTime, TimeSpan timeOfBegin, int doctorId, int userId);

        /// <summary>
        /// Отменить запись
        /// </summary>
        void CancelSession(int sessionId, int userId);
    }
}