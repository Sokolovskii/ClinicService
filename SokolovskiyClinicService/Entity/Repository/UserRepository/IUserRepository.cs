using System.Collections.Generic;
using SokolovskiyClinicService.Models.DTOModels;
using SokolovskiyClinicService.Models.DomainModels;

namespace SokolovskiyClinicService.Entity.Repository.UserRepository
{
    /// <summary>
    /// Интерфейс репозитория пользователей
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Возвращает пользователя по Id
        /// </summary>
        User GetUserById(int userId);

        /// <summary>
        /// Возвращает пользователя по логину
        /// </summary>
        User GetUserByLogin(string login);

        /// <summary>
        /// Добавляет пользователя в базу
        /// </summary>
        void AddNewUser(User user);

        /// <summary>
        /// Возвращает всех пользователей
        /// </summary>
        IEnumerable<User> GetAllUsers();

        /// <summary>
        /// Удаляет пользователя из базы
        /// </summary>
        void DeleteUser(int userId);
    }
}