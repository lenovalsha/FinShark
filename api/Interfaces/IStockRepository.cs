using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    //What interfaces really does is it allows us to plug in this code to other places
    //& allow us to abstract our code away    
    public interface IStockRepository
    {
         Task<List<Stock>> GetAllAsync();
    }
}