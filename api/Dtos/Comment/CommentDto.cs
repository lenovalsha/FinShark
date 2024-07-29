using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Comment
{
    public class CommentDto
    {
        //We coppied these from the Comment Model
          public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string  Content { get; set; } =string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now; 
        public int? StockId {get;set;}
      
      //we dont want the navigation property bc thats going to inject a whole intire object
      //makes our comment dto look bad
    }
}