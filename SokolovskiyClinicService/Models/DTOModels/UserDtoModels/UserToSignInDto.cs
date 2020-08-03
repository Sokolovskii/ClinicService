using System.Runtime.Serialization;

namespace SokolovskiyClinicService.Models.DTOModels.UserDtoModels
{
    /// <summary>
    /// DTO модель пользователя для регистрации
    /// </summary>
    [DataContract]
    public class UserToSignInDto
    {
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
        /// Пароль клиента
        /// </summary>
        [DataMember(Name = "password")]
        public string Password { get; set; }
        
        /// <summary>
        /// Флаг статуса клиента на регистрацию: пользователь или врач
        /// </summary>
        [DataMember(Name = "isDoctor")]
        public bool IsDoctor { get; set; }
    }
}