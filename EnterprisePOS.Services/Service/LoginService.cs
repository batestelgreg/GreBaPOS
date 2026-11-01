using EnterprisePOS.Data.Repositories;
using EnterprisePOS.Domain;
using EnterprisePOS.Domain.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EnterprisePOS.Services
{
    public class LoginService
    {
        private readonly LoginRepository _loginRepository;

        public LoginService()
        {
            _loginRepository = new LoginRepository();
        }

        public Task<UserSession> LoginAsync(
            string username,
            string password)
        {
            return Task.Run(() =>
                _loginRepository.Login(username, password));
        }
    }
}