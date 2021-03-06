namespace TradingApp.WebApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using TradingApp.Core.DTO;
    using TradingApp.Core.Models;
    using TradingApp.Core.Repositories;
    using TradingApp.Core.Services;

    [ApiController]
    public class TransactionController : ControllerBase

    {
        private readonly IRepository<TransactionEntity> transactionRepository;
        private readonly TransactionService transactionService;

        public TransactionController(IRepository<TransactionEntity> transactionRepository, TransactionService transactionService)
        {
            this.transactionRepository = transactionRepository;
            this.transactionService = transactionService;
        }
        [Route("deal/make")]
        [HttpPost]
        public ActionResult MakeTransaction([FromBody] TransactionInfo transactionInfo)
        {
            try
            {
                transactionService.MakeShareTransaction(
                    transactionInfo.SellerId,
                    transactionInfo.BuyerId,
                    transactionInfo.ShareId);
                return Ok("Made a transaction");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("transactions")]
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetTopTransactionsByUser(int clientId, int top)
        {
            try
            {
                return Ok(transactionService.GetTopTransactionsByUser(clientId, top));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
