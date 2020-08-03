using System.Runtime.Serialization;

namespace SokolovskiyClinicService.Models.DTOModels.UserDtoModels
{
    /// <summary>
    /// DTO модель пользователя для входа в систему
    /// </summary>
    [DataContract]
    public class UserToLogInDto
    {
        /// <summary>
        /// Логин клиента
        /// </summary>
        [DataMember(Name = "login")]
        public string Login { get; set; }
        
        /// <summary>
        /// Пароль клиента
        /// </summary>
        [DataMember(Name = "password")]
        public string Password { get; set; }
    }
}