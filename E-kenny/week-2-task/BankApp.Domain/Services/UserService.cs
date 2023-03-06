using BankApp.Domain.Entity;
using BankApp.Domain.Interfaces.Repositories;
using BankApp.Domain.Interfaces.Services;


namespace BankApp.Core.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepo;
        public UserService(IUserRepository userRepository) 
        { 
            _userRepo = userRepository;
        }
        public async Task<User> GetUser(string id)
        {
            var result = await _userRepo.GetUser(id);
            return result;
        }

        public async Task<User> Login(string email, string password)
        {
            var result = await _userRepo.Login(email, password);
            return result;
        }

        public async Task<User> Register(User user)
        {
            var result = await _userRepo.Register(user);
            return result;
        }

    }
}
