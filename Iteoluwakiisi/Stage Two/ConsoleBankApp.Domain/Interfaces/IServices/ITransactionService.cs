using ConsoleBankApp.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBankApp.Domain.Interfaces.IServices
{
    public interface ITransactionService
    {
        public Task<bool> Transaction(Transaction transaction);
    }
}
