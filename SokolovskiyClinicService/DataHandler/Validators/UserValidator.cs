using System;
using SokolovskiyClinicService.Models.ModelView;
using SokolovskiyClinicService.Models.DTOModels;
using SokolovskiyClinicService.Models.DTOModels.SessionDtoModels;

namespace SokolovskiyClinicService.DataHandler.Validators
{
    /// <summary>
    /// Класс технической валидации для сервисов пользователя
    /// </summary>
    public static class UserValidator
    {
        /// <summary>
        /// Техническая валидация данных для метода ReserveSession 
        /// </summary>
        public static bool ValidateSessionToReserve(SessionForReservingDto sessionDto, int userId)
        {
            return sessionDto.ValidationOnNull() && sessionDto.DoctorId.ValidationId() &&
                   userId.ValidationId() &&
                   sessionDto.Date != default && !string.IsNullOrWhiteSpace(sessionDto.TimeOfBeginSession);
        }

        public static bool ValidateTimeForReserving(SessionForReservingDto sessionDto)
        {
            return sessionDto.Date >= DateTime.Today && sessionDto.Date < DateTime.Today.Add(TimeSpan.FromDays(30));
        }
        

        /// <summary>
        /// Техническая валидация данных для метода CancelSession
        /// </summary>
        public static bool ValidateSessionToCancel(int sessionId, int userId)
        {
            return sessionId.ValidationId() && userId.ValidationId();
        }
        

        /// <summary>
        /// Техническая валидация данных для метода GetSessionsByDoctorIdAndDate
        /// </summary>
        public static bool ValidateDoctorAndDateToGetting(int doctorId, DateTime dateTime)
        {
            return doctorId.ValidationId() && dateTime != default;
        }
    }
}