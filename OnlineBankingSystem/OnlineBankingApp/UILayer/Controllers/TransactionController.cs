using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityLayer;
using DALayer;

namespace UILayer.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private ITransaction transactionservice;
        public TransactionController(ITransaction transactionservice)
        {
            this.transactionservice = transactionservice;
        }

        [HttpGet]
        [Route("ViewAllTransactions")]
        public IActionResult AllTransactions()
        {
            try
            {
                var transactions = transactionservice.AllTransactions();
                return Ok(transactions);

            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("CreateNewTransaction")]
        public IActionResult NewTransaction(TransactionModel details)
        {
            try
            {
                var response = transactionservice.NewTransaction(details);
                return Ok(response);

            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
