using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace EntityLayer
{
    public class SignupModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int CustomerId { get; set; }

        public string ConfirmPassword { get; set; }
        public string MobileNo { get; set; }

        public string UserRole { get; set; }

        [JsonIgnore]
        public string CreatedDate { get; set; }

        [JsonIgnore]
        public string ModifiedDate { get; set; }
    }
}
