using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DALayer;
using EntityLayer;
using DALayer.Models;

namespace UILayer.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ILogin ser;
        public LoginController(ILogin ser)
        {
            this.ser = ser;
        }

        [HttpPost]
        [Route("ValidateUser")]

        public IActionResult Validate(SigninModel log)
        {
            userloginmodel user;
            try
            {
                user = ser.LoginUser(log);
                return Ok(user);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("RegisterUser")]

        public IActionResult Register([FromBody] SignupModel reg)
        {
            userloginmodel newuser;
            try
            {
                newuser = ser.SignupUser(reg);
                return Ok(newuser);

            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("GetUsers")]

        public IActionResult GetUsers()
        {
            List<UserCredential> userlst;
            try
            {
                userlst = ser.GetUsers();
                return Ok(userlst);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
