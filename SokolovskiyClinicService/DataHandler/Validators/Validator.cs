using SokolovskiyClinicService.Models.DTOModels;

namespace SokolovskiyClinicService.DataHandler.Validators
{
    /// <summary>
    /// Проводит техническую валидацию объектов и целочисленных идентификаторов
    /// </summary>
    public static class Validator
    {
        /// <summary>
        /// Проводит техническую валидацию объектов
        /// </summary>
        public static bool ValidationOnNull(this object o)
        {
            return o != null;
        }

        /// <summary>
        /// Проводит техническую валидацию целочисленных идентификаторов
        /// </summary>
        public static bool ValidationId(this int id)
        {
            return id > 0;
        }
        
        /// <summary>
        /// Валидация рабочего дня
        /// </summary>
        public static bool IsValidWorkDay(this WorkDayDto workDay)
        {
            return workDay.ValidationOnNull() && workDay.BeginOfDay != default && workDay.EndOfDay != default;
        }
    }
}