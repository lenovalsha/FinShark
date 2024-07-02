using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController :ControllerBase
    {
        private readonly ApplicationDBContext _context; //this provides more security when its private and readonly
        public StockController(ApplicationDBContext context)
        {
            _context = context;
        }
        //READ
        [HttpGet]
        public IActionResult Getll()
        {
            var stocks = _context.Stocks.ToList().Select(s=> s.ToStockDto());//defered execution - this is so that it selects certain information you want to show
            //==> Select(s=> s.ToStockDto()) ==> This is from the Mappers Method  -
            //Make the DTo first then the mapper
            return Ok(stocks);
        }
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var stock = _context.Stocks.Find(id); //find the stock by id

            if(stock ==null) //if cant find it then return not found
            {
                return NotFound();
            }
            return Ok(stock.ToStockDto()); //else return the stock by Id
        }
    }
}