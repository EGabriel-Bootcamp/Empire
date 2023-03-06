using ConsoleBankApp.Domain.Entity;
using ConsoleBankApp.Domain.Interfaces.IRepository;
using ConsoleBankApp.Domain.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBankApp.Domain.Services
{
    public class UserService :IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> GetUser(string id)
        {
            var result = await _userRepository.GetUser(id);
            return result;
        }
        public async Task<User> Login(string email, string password)
        {
            var result = await _userRepository.Login(email, password);    
            return result;
        }
        public async Task<User> Register(User user)
        {
            var result = await _userRepository.Register(user);
            return result;
        }
    }
}
