using System.Runtime.Serialization;

namespace SokolovskiyClinicService.Models.DTOModels.UserDtoModels
{
    /// <summary>
    /// DTO модель авторизированного юзера
    /// </summary>
    [DataContract]
    public class AuthorizedUserDto
    {
        /// <summary>
        /// jwt токен доступа
        /// </summary>
        [DataMember(Name = "jwtToken")]
        public string JwtToken { get; set; }
        
        /// <summary>
        /// Пользователь
        /// </summary>
        [DataMember(Name = "user")]
        public UserDto User { get; set; }
    }
}