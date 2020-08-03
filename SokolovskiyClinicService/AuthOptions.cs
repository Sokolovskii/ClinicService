using System;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace SokolovskiyClinicService
{
    public class AuthOptions
    {
        public const string ISSUER = "CLINICServer";
        public const string AUDIENCE = "CLINICClient";
        private const string KEY = "superSecretKey1984";
        public static readonly TimeSpan LIFETIME = TimeSpan.FromDays(1);
        public static readonly SymmetricSecurityKey SymmetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));

    }
}