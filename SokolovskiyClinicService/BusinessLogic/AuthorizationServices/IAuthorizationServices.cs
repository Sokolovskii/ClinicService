using SokolovskiyClinicService.Models.DomainModels;

namespace SokolovskiyClinicService.BusinessLogic.AuthorizationServices
{
    /// <summary>
    /// Интерфейс сервисов авторизации
    /// </summary>
    public interface IAuthorizationServices
    {
        /// <summary>
        /// Проверяет пользователя на совпадение логина и пароля и возвращает его с Id, в случае совпадения
        /// </summary>
        User LogIn(string login, string passHash);

        /// <summary>
        /// Вносит нового пользователя в базу и возвращает его с Id
        /// </summary>
        User SignInUser(string name, string login, string passHash);

        /// <summary>
        /// носит нового врача в базу
        /// </summary>
        User SignInDoctor(string name, string login, string passHash);
    }
}