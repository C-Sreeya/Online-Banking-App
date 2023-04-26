using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DALayer;
using EntityLayer;

namespace UILayer.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IAccount actser;
        public AccountController(IAccount actser)
        {
            this.actser = actser;
        }

        [HttpGet]
        [Route("AllAccountDetails")]
        public IActionResult DisplayAllActs()
        {
            List<AccountModel> actslst = new List<AccountModel>();
            try
            {
                actslst = actser.DisplayAllAccounts();
                return Ok(actslst);

            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("CustomerAccountDetails/{customerId}")]
        public IActionResult DisplayByCustId(int customerId)
        {
            try
            {
                var actslst = actser.DisplayAcctbyCustId(customerId);
                return Ok(actslst);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
