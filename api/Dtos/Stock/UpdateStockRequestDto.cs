using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Stock
{
    public class UpdateStockRequestDto
    {
         public string Symbol { get; set; } = string.Empty; //if you dont put empty it will give you a null error
        public string CompanyName { get; set; } = string.Empty;
        //make sure that it is monetory amount
        public decimal Purchase { get; set; }
        public decimal LastDiv { get; set; }
        public string Industry { get; set; } = string.Empty;
        public long MarketCap { get; set; }
    }
}