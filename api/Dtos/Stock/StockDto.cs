using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Comment
{
    //this dto just makes it so when we get responses back
    public class StockDto
    {
         public int Id { get; set; }
        public string Symbol { get; set; } = string.Empty; //if you dont put empty it will give you a null error
        public string CompanyName { get; set; } = string.Empty;

        //make sure that it is monetory amount
        [Column(TypeName = "decimal(18,2)")]
        public decimal Purchase { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal LastDiv { get; set; }
        public string Industry { get; set; } = string.Empty;

        public long MarketCap { get; set; }
    }
}