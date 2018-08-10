using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Model
{
    public class Trade
    {
        public int CustomerId { get; set; }
        public TradeType TradeType { get; set; }

        public int AssetId { get; set; }

    }
}
