using DataAccess.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stock_API.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stock_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class StocksController : ControllerBase
    {
        private readonly IStockRepository stockRepository;

        public StocksController(IStockRepository StockRepository)
        {
            stockRepository = StockRepository;
        }


        [HttpPut("{VariantCode}/{Quantity}")]
        public async Task<ActionResult<Stock>> UpdateVariant(string VariantCode, int Quantity)
        {
            var Result =  await stockRepository.Update(VariantCode, Quantity);
            if (Result == null)
                return BadRequest("No data found with given VariantCode");
            return Ok(Result);
        }
        [HttpPost]
        public async Task<ActionResult<Stock>> AddVariant(StockDto Stock)
        {
            Stock StockEntity = new Stock()
            {
                VariantCode = Stock.VariantCode,
                ProductCode = Stock.ProductCode,
                Quantity = Stock.Quantity,
                CreateTime = DateTime.Now
            };
          return await stockRepository.Add(StockEntity);
           
        }

        [HttpGet("{ProductCode}/product")]
        public async Task<ActionResult<List<Stock>>> GetByProductCode(string ProductCode)
        {
            var Result = await stockRepository.GetByProductCode(ProductCode);
            return Result;
        }

        [HttpGet("{VariantCode}/variant")]
        public async Task<Stock> GetByVariantCode(string VariantCode)
        {
            var Result = await stockRepository.GetByVariantCode(VariantCode);
            return Result;
        }
    }
}
