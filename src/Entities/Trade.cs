using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities
{
    public class Trade : Service
    {
        public Customer Customer { get; set; }
      
        public Asset Asset { get; set; }

        public TradeType TradeType { get; set; }
    }
}
