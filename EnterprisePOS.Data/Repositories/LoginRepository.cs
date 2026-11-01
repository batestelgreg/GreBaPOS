using EnterprisePOS.Domain;
using EnterprisePOS.Domain.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterprisePOS.Data.Repositories
{
    public class LoginRepository : DatabaseRepository
    {
        public UserSession Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password))
            {
                return null;
            }

            using (var db = CreateContext())
            {
                var user = db.usp_Login(username.Trim()).FirstOrDefault();

                if (user == null || !user.IsActive)
                {
                    return null;
                }

                string calculatedHash =
                    ComputePasswordHash(user.Salt, password);

                if (!string.Equals(
                    calculatedHash,
                    user.PasswordHash,
                    StringComparison.OrdinalIgnoreCase))
                {
                    return null;
                }

                db.usp_User_TouchLogin(user.UserId);

                return new UserSession
                {
                    UserId = user.UserId,
                    Username = user.Username,
                    FullName = user.FullName,
                    RoleName = user.RoleName
                };
            }
        }

        private string ComputePasswordHash(string salt, string password)
        {
            using (var sha256 =
                System.Security.Cryptography.SHA256.Create())
            {
                byte[] inputBytes =
                    System.Text.Encoding.UTF8.GetBytes(salt + password);

                byte[] hashBytes = sha256.ComputeHash(inputBytes);

                return BitConverter.ToString(hashBytes)
                    .Replace("-", "");
            }
        }
    }
}