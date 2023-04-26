using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DALayer;
using DALayer.Models;
using EntityLayer;

namespace UILayer.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private ILoan loanser;
        public LoanController(ILoan loanser)
        {
            this.loanser = loanser;
        }

        [HttpPost]
        [Route("ApplyForLoan")]
        public IActionResult NewLoan(LoanModel newln)
        {
            try
            {
                var status = loanser.NewLoan(newln);
                return Ok(status);
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        [HttpGet]
        [Route("GetLoanStatus/{username}")]
        public IActionResult LoanStatus(string username)
        {
            try
            {
                var loandtl = loanser.LoanStatusOfCustomer(username);
                return Ok(loandtl);

            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("ApproveLoan/{loanId}")]
        public IActionResult ApproveLoan(int loanId)
        {
            try
            {
                var approvalstatus = loanser.ApproveLoan(loanId);
                return Ok(approvalstatus);

            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("DisplayAllLoans")]
        public IActionResult GetAllLoans()
        {
            try
            {
                var loanlst = loanser.GetAllLoanDetails();
                return Ok(loanlst);

            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
