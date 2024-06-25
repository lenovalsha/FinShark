using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public string Symbol { get; set; } = string.Empty; //if you dont put empty it will give you a null error
        public string CompanyName { get; set; } = string.Empty;
    }
}