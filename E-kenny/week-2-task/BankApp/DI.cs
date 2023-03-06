
using BankApp.Core.Services;
using BankApp.Domain.Interfaces.Repositories;
using BankApp.Domain.Interfaces.Services;
using BankApp.Infrastructure.Repositories;

namespace BankApp.Api
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
        _accountService= new AccountService(_accountRepository, _transactionRepository);
        _transactionService = new TransactionService(_transactionRepository);
        _userService = new UserService(_userRepository);
    }
    }
}
