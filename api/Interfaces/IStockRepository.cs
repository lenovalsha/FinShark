using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;
using api.Dtos.Stock;
using api.Models;

namespace api.Interfaces
{
    //What interfaces really does is it allows us to plug in this code to other places
    //& allow us to abstract our code away    
    public interface IStockRepository
    {
        //remember Task == object return type
         Task<List<Stock>> GetAllAsync();
         Task<Stock?> GetByIdAsync(int id);//FirstOrDefault CAN BE NULL - so we need this ? in our Stock
         Task<Stock> CreateAsync(Stock stockModel);// this will create our entity model - Stock
         Task <Stock?> UpdateAsync(int id, UpdateStockRequestDto stockDto);
         Task<Stock?> DeleteAsync(int id);
    }
}