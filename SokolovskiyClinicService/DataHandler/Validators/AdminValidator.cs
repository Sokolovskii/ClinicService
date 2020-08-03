using SokolovskiyClinicService.Models.DTOModels.ScheduleDtoModels;

namespace SokolovskiyClinicService.DataHandler.Validators
{
    /// <summary>
    /// Класс технической валидации для сервисов администратора
    /// </summary>
    public static class AdminValidator
    {
        /// <summary>
        /// Техническая валидация данных графика работы
        /// </summary>
        public static bool ValidateScheduleForUpdating(ScheduleFullDto scheduleToRender)
        {
            return scheduleToRender.ValidationOnNull()
                   && scheduleToRender.ActualisationDate != default;
        }
    }
}