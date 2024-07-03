using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// using api.Dtos.Comment;
using api.Dtos.Stock;
using api.Models;

namespace api.Mappers
{
    public static class StockMappers
    {
        public static StockDto ToStockDto(this Stock stockModel)
        {
            //return what you want the users to see
            //this is to reshape the data
            return new StockDto {
                //StockDto variable = Models.Stock Variables
                    Id = stockModel.Id,
                     Symbol = stockModel.Symbol,
                CompanyName = stockModel.CompanyName,
                Purchase = stockModel.Purchase,
                LastDiv = stockModel.LastDiv,
                Industry = stockModel.Industry,
                MarketCap = stockModel.MarketCap
            };
        }
        //reason why we need to make these bc our DTO mappers is bc EF 
        public static Stock ToStockFromCreateDto(this CreateStockRequestDto stockDto)
        {
            //we need to do this bc our DTO is in the DTO type
            //when we submit a data into our _context.Stocks.Add method, it has to be in the form of a stock model
            //this method that EF provides for us, whenever you pass any data into it to be saved it cant be in the form of a DTO, why we need to make these mappers
            return new Stock{
                Symbol = stockDto.Symbol,
                CompanyName = stockDto.CompanyName,
                Purchase = stockDto.Purchase,
                LastDiv = stockDto.LastDiv,
                Industry = stockDto.Industry,
                MarketCap = stockDto.MarketCap

            };
        }
        

    }

}