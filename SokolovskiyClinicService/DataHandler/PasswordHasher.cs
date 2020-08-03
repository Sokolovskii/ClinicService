using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SokolovskiyClinicService.DataHandler
{
    /// <summary>
    /// Класс, хеширователя паролей
    /// </summary>
    public static class PasswordHasher
    {
        /// <summary>
        /// Возвращение хеша пароля
        /// </summary>
        public static string GetPasswordHash(this string password)
        { 
            var bytes = Encoding.Unicode.GetBytes(password);
            using (var csp = new MD5CryptoServiceProvider())
            {
                var byteHash = csp.ComputeHash(bytes);
                return byteHash.Aggregate(string.Empty, (current, b) => current + $"{b:x2}");
            }
        }
    }
}