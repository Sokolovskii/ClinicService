using System.ComponentModel.DataAnnotations;
using SokolovskiyClinicService.Models.DTOModels;

namespace SokolovskiyClinicService.Models.DomainModels
{
    /// <summary>
    /// Модель сущности клиента
    /// </summary>
    public class User
    {
        /// <summary>
        /// Id пользователя
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Имя клиента
        /// </summary>
        [Required]
        public string Name { get; set; }
        
        /// <summary>
        /// Логин клиента
        /// </summary>
        [Required]
        public string Login { get; set; }
        
        /// <summary>
        /// Пароль клиента
        /// </summary>
        [Required]
        public string PassHash { get; set; }
        
        /// <summary>
        /// Роль клиента в ролевой модели
        /// </summary>
        public UserRole Role { get; set; }
        
    }
}