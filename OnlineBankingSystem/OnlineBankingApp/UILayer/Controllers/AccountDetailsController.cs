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
    public class AccountDetailsController : ControllerBase
    {
        private IAccountDetails actserv;
        public AccountDetailsController(IAccountDetails actserv)
        {
            this.actserv = actserv;
        }

        [HttpPost]
        [Route("ChangePassword")]
         
        public IActionResult ChangePassword(SigninModel user)
        {
            try
            {
                var resp = actserv.ChangePassword(user);
                return Ok(resp);

            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("GetUserDetails/{username}")]
        public IActionResult GetUserDetails(string username)
        {
            try
            {
                var user = actserv.GetUserCredentials(username);
                return Ok(user);

            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet]
        [Route("AccountSummary/{username}")]
        public IActionResult AccountSummary(string username)
        {
            try
            {
                var accountslst = actserv.AccountSummary(username);
                return Ok(accountslst);

            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("RecentTransactions/{username}")]
        public IActionResult RecentTransactions(string username)
        {
            try
            {
                var accountslst = actserv.RecentFiveTransactions(username);
                return Ok(accountslst);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }




    }
}
