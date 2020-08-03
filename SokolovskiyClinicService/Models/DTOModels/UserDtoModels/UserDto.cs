using System.Runtime.Serialization;
using SokolovskiyClinicService.Models.DomainModels;

namespace SokolovskiyClinicService.Models.DTOModels.UserDtoModels
{
    /// <summary>
    /// Модель DTO пользователя 
    /// </summary>
    [DataContract]
    public class UserDto
    {
        /// <summary>
        /// Id пользователя
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }
        
        /// <summary>
        /// Имя клиента
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }
        
        /// <summary>
        /// Логин клиента
        /// </summary>
        [DataMember(Name = "login")]
        public string Login { get; set; }

        /// <summary>
        /// Роль клиента в ролевой модели
        /// </summary>
        [DataMember(Name = "role")]
        public string Role { get; set; }

        public UserDto(User user)
        {
            Id = user.Id;
            Login = user.Login;
            Name = user.Name;
            Role = user.Role.ToString();
        }
        
        public UserDto(){}
    }
}