using ConsoleBankApp.Domain.Interfaces.IRepository;
using ConsoleBankApp.Domain.Interfaces.IServices;
using ConsoleBankApp.Domain.Services;
using ConsoleBankApp.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBankApp
{
    public class DI
    {
        public IAccountRepository _accountRepository;
        public IUserRepository _userRepository;
        public ITransactionRepository _transactionRepository;
        public IAccountService _accountService;
        public ITransactionService _transactionService;
        public IUserService _userService;

        public DI()
        {
            _accountRepository = new AccoountRepository();
            _userRepository = new UserRepository();
            _transactionRepository = new TransactionRepository();
            _accountService = new AccountService(_accountRepository, _transactionRepository);
            _transactionService = new TransactionService(_transactionRepository);
            _userService = new UserService(_userRepository);
        }
    }
}
