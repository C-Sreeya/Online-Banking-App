using System;
using System.Collections.Generic;

#nullable disable

namespace DALayer.Models
{
    public partial class UserCredential
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int CustomerId { get; set; }
        public string MobileNo { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string UserRole { get; set; }
    }
}
