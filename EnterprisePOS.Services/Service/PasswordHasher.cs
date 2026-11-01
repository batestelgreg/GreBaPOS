using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace EnterprisePOS.Services.Service
{
    public static class PasswordHasher
    {
        public static string GenerateSalt()
        {
            byte[] saltBytes = new byte[16];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }

            return BitConverter.ToString(saltBytes)
                .Replace("-", "");
        }

        public static string ComputeHash(string salt, string password)
        {
            if (string.IsNullOrWhiteSpace(salt))
                throw new ArgumentException("Salt is required.", nameof(salt));

            if (string.IsNullOrEmpty(password))
                throw new ArgumentException("Password is required.", nameof(password));

            using (var sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(salt + password);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);

                return BitConverter.ToString(hashBytes)
                    .Replace("-", "");
            }
        }
    }
}