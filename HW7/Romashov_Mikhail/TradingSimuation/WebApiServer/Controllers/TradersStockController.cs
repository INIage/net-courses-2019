using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using TradingSimulator.Core.Dto;
using TradingSimulator.Core.Interfaces;
using TradingSimulator.Core.Models;
using WebApiServer.Interfaces;

namespace WebApiServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TradersStockController : ControllerBase
    {
        private readonly ITraderStocksService traderStocksService;
        private readonly ITraderService tradersService;
        private readonly IStockService stockService;
        private readonly IValidator validator;

        public TradersStockController(ITraderStocksService traderStocksService, ITraderService tradersService, IStockService stockService, IValidator validator)
        {
            this.traderStocksService = traderStocksService;
            this.tradersService = tradersService;
            this.stockService = stockService;
            this.validator = validator;
        }

        // GET TradersStock/count
        [HttpGet("count")]
        public string Get()
        {
            return JsonConvert.SerializeObject(traderStocksService.GetCountIds());
        }

        // GET TradersStock?id=3
        [HttpGet]
        public string GetAll(int id)
        {
            return JsonConvert.SerializeObject((traderStocksService.GetTraderStockById(id)));
        }
        

        // POST: /stocks/add?traderName=_&stockName=_&count=_&
        [HttpPost("add")]
        public ActionResult AddStock(string traderName, string stockName, string count)
        {
            if (!validator.StockToTraderValidate(traderName, stockName))
            {
                return StatusCode(400, $"Can`t add stock {stockName} to trader {traderName}");
            }

            var trader = tradersService.GetTraderByName(traderName);
            var stock = stockService.GetStockByName(stockName);


            bool validCount = Int32.TryParse(count, out int countStock);

            if (!validCount)
            {
                return StatusCode(400, "Bad count value. Operation cancel");
            }


            TraderInfo traderInfo = new TraderInfo
            {
                Id = trader.Id,
                Name = trader.Name,
            };
            StockInfo stockInfo = new StockInfo
            {
                Id = stock.Id,
                Name = stock.Name,
                Count = countStock,
                PricePerItem = stock.PricePerItem

            };

            try
            {
                traderStocksService.AddNewStockToTrader(traderInfo, stockInfo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("Stock to trader added succesfully");
        }
    }
}