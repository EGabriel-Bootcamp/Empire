using Pegasus_BankApp.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pegasus_BankApp.Domain.Interfaces.IServices
{
    public interface IUserService
    {
        public Task<User> GetUser(string id);

        public Task<User> Login(string email, string password);

        public Task<User> Register(User user);

    }
}
