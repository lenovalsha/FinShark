using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace api.Models
{
    [Table("Comments")]
    public class Comment
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string  Content { get; set; } =string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now; 
        public int? StockId {get;set;}

        //navigation property - this is what allows us to access this part or navigate within this relationship
        public Stock? Stock { get; set; } //this is how we will connect the two tables
    }
}