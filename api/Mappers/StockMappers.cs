using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Comment;
using api.Models;

namespace api.Mappers
{
    public static class StockMappers
    {
        public static StockDto ToStockDto(this Stock stockModel)
        {
            //return what you want the users to see
            return new StockDto {
                    Id = stockModel.Id,
                    Symbol = stockModel.Symbol,
            };
        }
    }
}