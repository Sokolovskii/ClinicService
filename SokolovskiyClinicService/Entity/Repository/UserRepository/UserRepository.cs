using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SokolovskiyClinicService.Exceptions;
using SokolovskiyClinicService.Models.DomainModels;

namespace SokolovskiyClinicService.Entity.Repository.UserRepository
{
    /// <summary>
    /// Класс репозитория пользователя
    /// </summary>
    /// <inheritdoc cref="IUserRepository"/>
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// Контекст данных
        /// </summary>
        private readonly DataContext _context;

        /// <summary>
        /// .ctor
        /// </summary>
        public UserRepository(DataContext context)
        {
            _context = context;
        }
        
        public User GetUserById(int userId)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == userId)
                ?? throw new WarningException(ExceptionMessages.UserNotFound);
            return user;
        }

        public User GetUserByLogin(string login)
        {
            return _context.Users.SingleOrDefault(u => u.Login == login);
        }

        public void AddNewUser(User user)
        {
            _context.Entry(user).State = EntityState.Added;
            _context.SaveChanges();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public void DeleteUser(int userId)
        {
            _context.Entry(GetUserById(userId)).State = EntityState.Deleted;
            _context.SaveChanges();
        }
    }
}