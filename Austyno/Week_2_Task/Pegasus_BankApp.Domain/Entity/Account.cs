using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pegasus_BankApp.Domain.Entity
{
    public class Account : BaseEntity
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int AccountNumber { get; set; }

        public string User_Id { get; set; }

    }
}
