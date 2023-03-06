using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pegasus_BankApp.Domain.Entity
{
    public  class BaseEntity
    {
        public DateTime Created_At { get; set; }

        public DateTime Updated_At { get; set; }

    }
}
