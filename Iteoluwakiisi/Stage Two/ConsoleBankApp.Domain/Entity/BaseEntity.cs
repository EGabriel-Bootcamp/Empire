﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBankApp.Domain.Entity
{
    public class BaseEntity
    {
        public DateTime CreatedAt   { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
