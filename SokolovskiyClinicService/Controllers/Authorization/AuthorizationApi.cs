using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using SokolovskiyClinicService.DataHandler;
using SokolovskiyClinicService.BusinessLogic.AuthorizationServices;
using SokolovskiyClinicService.DataHandler.Response;
using SokolovskiyClinicService.DataHandler.Validators;
using SokolovskiyClinicService.Models.DTOModels.UserDtoModels;

namespace SokolovskiyClinicService.Controllers.Authorization
{
    /// <summary>
    /// API контроллер авторизации
    /// </summary>
    [Route("Home/api/authorization")]
    [Route("api/authorization")]
    public class AuthorizationApi : ControllerBase
    {
        private readonly IAuthorizationServices _authorizationServices;

        /// <summary>
        /// .ctor
        /// </summary>
        public AuthorizationApi(IAuthorizationServices authorizationServices)
        {
            _authorizationServices = authorizationServices;
        }

        /// <summary>
        /// Вход в систему
        /// </summary>
        /// <param name="userDto">Пользователь для входа в систему</param>
        /// <returns>Авторизированный пользователь</returns>
        [HttpPost("LogIn")]
        public async Task<ControllerResponse> LogIn([FromBody] UserToLogInDto userDto)
        {
            if (!AuthorisationValidator.ValidateUserToLogIn(userDto))
                return ControllerResponse.Warning(
                    "Данные не введены полностью. Уточните данные запроса и повторите попытку");

            var user = _authorizationServices.LogIn(userDto.Login, userDto.Password.GetPasswordHash());
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Name),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };
            var id = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(id);
            await HttpContext.SignInAsync(principal);
            return ControllerResponse.Ok();
        }

        /// <summary>
        /// Создание нового аккаунта в системе
        /// </summary>
        /// <param name="userDto">Пользователь для добавления</param>
        /// <returns>Авторизованный пользователь</returns>
        [HttpPost("SignIn")]
        public async Task<ControllerResponse> SignInUser([FromBody] UserToSignInDto userDto)
        {
            if (!AuthorisationValidator.ValidateUserToSignIn(userDto))
                return ControllerResponse.Warning(
                    "Введенные данные некорректны, введите все данные и повторите запрос");

            var user = userDto.IsDoctor
                ? _authorizationServices.SignInDoctor(userDto.Name, userDto.Login, userDto.Password.GetPasswordHash())
                : _authorizationServices.SignInUser(userDto.Name, userDto.Login, userDto.Password.GetPasswordHash());

            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Name),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };
            var id = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(id);
            await HttpContext.SignInAsync(principal);
            return ControllerResponse.Ok();
        }

        /// <summary>
        /// Разлогинивает пользователя
        /// </summary>
        [HttpGet("LogOut")]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}