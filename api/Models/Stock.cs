using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    [Table("Stocks")]
    public class Stock
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

        public long MarketCap { get; set; } //marketcaps can be in trillions - long is the perfect type for this

        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}