using SokolovskiyClinicService.Models.DTOModels;
using SokolovskiyClinicService.Models.DTOModels.UserDtoModels;

namespace SokolovskiyClinicService.DataHandler.Validators
{
    /// <summary>
    /// Класс технической валидации для сервисов авторизации
    /// </summary>
    public static class AuthorisationValidator
    {
        /// <summary>
        /// Техническая валидация данных для метода SignIn
        /// </summary>
        public static bool ValidateUserToSignIn(UserToSignInDto user)
        {
            return user.ValidationOnNull() && !string.IsNullOrWhiteSpace(user.Name) &&  !string.IsNullOrWhiteSpace(user.Login) &&  !string.IsNullOrWhiteSpace(user.Password);
        }

        /// <summary>
        /// Техническая валидация данных для метода LogIn
        /// </summary>
        public static bool ValidateUserToLogIn(UserToLogInDto user)
        {
            return user.ValidationOnNull() && !string.IsNullOrWhiteSpace(user.Login) && !string.IsNullOrWhiteSpace(user.Password);
        }
    }
}