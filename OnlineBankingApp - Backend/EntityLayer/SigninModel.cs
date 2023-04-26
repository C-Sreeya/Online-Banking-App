using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer
{
    public class SigninModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
