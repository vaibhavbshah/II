using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Enums;

namespace Entities
{
    public class Customer : User
    {
        public CustomerType CustomerType { get; set; }
    }
}
