using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTO;
using api.DTO.Stock;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace api.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class Stockcontroller : ControllerBase
    {
        private readonly ApplicationDBContext _context;// adding security and protection to the data
        public Stockcontroller(ApplicationDBContext context)
        {
            _context = context;
        }


        [HttpGet] // read func    
        public async Task<IActionResult> GetAll(){

            var stocks = await _context.Stocks.ToListAsync();
            var stockDTO= stocks.Select(s=>s.ToStockDto()); // convert the stocks to a list of stockDto using the toStockDto method from the mappers folder


            return Ok(stocks); // return the stocks in a json format
        }   



        [HttpGet("{id}")] // This attribute maps HTTP GET requests with an 'id' parameter to this method
        public  async Task<IActionResult> GetById([FromRoute]int id){
            var stock = await _context.Stocks.FindAsync(id);// find the stock by id from the database

            if(stock == null){
                return NotFound(); // if not found return 404 error
            }
        
            return Ok(stock.ToStockDto()); // return the stocks in a json format
 }  

        [HttpPost] // create func
        public async Task<IActionResult> Create([FromBody] CreateStockRequest stockDto){
            var stockModel= stockDto.ToStockFromCreateDto(); // convert the stockDto to a stock model using the toStockFromCreateDto method from the mappers folder posting from web page to BE
            await _context.Stocks.AddAsync(stockModel); // add the stock model to the database
            await _context.SaveChangesAsync(); // save the changes to the database
            return CreatedAtAction(nameof(GetById), new { id = stockModel.ID }, stockModel.ToStockDto()); // get byid is above return the stock model in a json format and return the id of the stock model this will return a new object to get by id as 3well
        }

        [HttpPut("{id}")] // update func
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto){
            var stockModel =await _context.Stocks.FirstOrDefaultAsync(s=>s.ID == id); // find the stock by id from the database
            if (stockModel == null){
                return NotFound(); // if not found return 404 error
            }

            stockModel.Symbol = updateDto.Symbol;
            stockModel.CompanyName = updateDto.CompanyName;     
            stockModel.Purchase = updateDto.Purchase; 
            stockModel.LastDiv = updateDto.LastDiv;
            stockModel.Industry = updateDto.Industry; 
            stockModel.MarketCap = updateDto.MarketCap;
            await _context.SaveChangesAsync();
            return Ok(stockModel.ToStockDto()); // return the stocks in a json format
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id){
            var stockModel = await _context.Stocks.FirstOrDefaultAsync(x=> x.ID== id);
            if (stockModel == null){
                return NotFound(); 
            }

            _context.Stocks.Remove(stockModel); 
           await _context.SaveChangesAsync(); 
           return NoContent();
            }


            // [HttpGet("{symbol}")]
// public async Task<IActionResult> GetBySymbol([FromRoute] string symbol)
// {
//     var stock = await _context.Stocks.FirstOrDefaultAsync(s => s.Symbol == symbol);
//     if (stock == null)
//     {
//         return NotFound();
//     }
//     return Ok(stock.ToStockDto());
// //The issue with your GetBySymbol method lies in the use of FindAsync. The FindAsync method is typically used with primary keys, and it won't work correctly for non-primary key fields like symbol. Instead, you should use FirstOrDefaultAsync to query the Stocks table by the symbol field.
// }
    
} 
}