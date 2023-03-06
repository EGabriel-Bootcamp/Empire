using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pegasus_BankApp.Domain.Entity
{
    public class Transaction : BaseEntity
    {
        public string Id { get; set; }

        public decimal Amount { get; set; }

        public string Description { get; set; }


        public string Account_Id { get; set; }



    }
}
