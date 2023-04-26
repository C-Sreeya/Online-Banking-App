using System;
using System.Collections.Generic;
using System.Text;

namespace EntityLayer
{
    public class AccountModel
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhNo { get; set; }
        public int? CustomerAge { get; set; }
        public DateTime? Dob { get; set; }
        public string AccountNo { get; set; }
        public string Ifsc { get; set; }
        public int? AccountTypeId { get; set; }
        public int? Balance { get; set; }
        public string Branch { get; set; }
        public string UserType { get; set; }
    }
}
