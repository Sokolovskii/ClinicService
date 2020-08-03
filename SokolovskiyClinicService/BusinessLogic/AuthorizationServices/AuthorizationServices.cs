using System.Linq;
using SokolovskiyClinicService.Entity.Repository.DoctorRepository;
using SokolovskiyClinicService.Entity.Repository.UserRepository;
using SokolovskiyClinicService.Exceptions;
using SokolovskiyClinicService.Models;
using SokolovskiyClinicService.Models.DomainModels;

namespace SokolovskiyClinicService.BusinessLogic.AuthorizationServices
{
    /// <summary>
    /// Класс сервисов авторизации
    /// </summary>
    /// <inheritdoc cref="IAuthorizationServices"/>
    public class AuthorizationServices : IAuthorizationServices
    {

        private readonly IUserRepository _userRepository;
        private readonly IDoctorRepository _doctorRepository;

        public AuthorizationServices(IUserRepository userRepository, IDoctorRepository doctorRepository)
        {
            _userRepository = userRepository;
            _doctorRepository = doctorRepository;
        }

        public User LogIn(string login, string passHash)
        {
            var user = _userRepository.GetUserByLogin(login);
            if (user == null || user.PassHash != passHash )
            {
                throw new WarningException(ExceptionMessages.LoginOrPasswordUncorrect);
            }

            return user;
        }

        public User SignInUser(string name, string login, string passHash)
        {
            var users = _userRepository.GetAllUsers();
            if (users.Any(checkUser => login == checkUser.Login))
            {
                throw new WarningException(ExceptionMessages.UserWithThisLoginHasInBase);
            }

            var newUser = new User
            {
                Name = name,
                Login = login,
                PassHash = passHash,
                Role = UserRole.User
            };
            _userRepository.AddNewUser(newUser);
            return _userRepository.GetUserByLogin(login); 
        }

        public User SignInDoctor(string name, string login, string passHash)
        {
            var users = _userRepository.GetAllUsers();
            if (users.Any(checkUser => login == checkUser.Login))
            {
                throw new WarningException(ExceptionMessages.UserWithThisLoginHasInBase);
            }

            var newUser = new User
            {
                Name = name,
                Login = login,
                PassHash = passHash,
                Role = UserRole.Doctor
            };
            _userRepository.AddNewUser(newUser);
            var userToReturned = _userRepository.GetUserByLogin(login);
            _doctorRepository.AddNewDoctor(name, userToReturned.Id);
            return userToReturned; 
        }
    }
}