using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Stock;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Microsoft.JSInterop.Infrastructure;

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


        #region POST
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDto createStockDto)
        {
            var stockModel = createStockDto.ToStockFromCreateDto(); //making based on the dto
            _context.Stocks.Add(stockModel);
            _context.SaveChanges();
            //it is going to execute the GetById method
            //it is going to pass in this new object into the id
            //after that it is going to return in a form of ToStockDto
            return CreatedAtAction(nameof(GetById), new {id = stockModel.Id}, stockModel.ToStockDto());
        }
        #endregion
        #region UPDATE 

        //in order to make an update, a data must exist already

        [HttpPut]
        [Route("{id}")] //specify our search based on id
        public IActionResult Update([FromRoute]int id, [FromBody]UpdateStockRequestDto updateStockDto )
        {
            var stockModel = _context.Stocks.FirstOrDefault(x => x.Id == id);
            if(stockModel == null)
                return NotFound();

                stockModel.Symbol = updateStockDto.Symbol;
                stockModel.CompanyName = updateStockDto.CompanyName;

            _context.SaveChanges(); //this is whats actually going to send to the database

            return Ok(stockModel.ToStockDto());

        }
        

        #endregion
        #region DELETE
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute]int id)
        {
            var stockModel = _context.Stocks.FirstOrDefault(x=>x.Id == id);

            if(stockModel == null)
            return NotFound();

            _context.Stocks.Remove(stockModel);
            _context.SaveChanges();
                
            return Ok(stockModel.ToStockDto());
        }
        #endregion
    }
}