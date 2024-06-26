using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
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
            var stocks = _context.Stocks.ToList();//defered execution
            return Ok(stocks);
        }
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var stock = _context.Stocks.Find(id);

            if(stock ==null)
            {
                return NotFound();
            }
            return Ok(stock);
        }
    }
}