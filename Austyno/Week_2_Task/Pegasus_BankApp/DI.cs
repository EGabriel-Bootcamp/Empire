using Pegasus_BankApp.Domain.Interfaces.IRepository;
using Pegasus_BankApp.Domain.Interfaces.IServices;
using Pegasus_BankApp.Domain.Services;
using Pegasus_BankApp.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pegasus_BankApp
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
            _accountRepository = new AccountRepository();
            _userRepository = new UserRepository();
            _transactionRepository = new TransactionRepository();
            _accountService = new AccountService(_accountRepository, _transactionRepository);
            _transactionService = new TransactionService(_transactionRepository);
            _userService = new UserService(_userRepository);
        }


    }
}
