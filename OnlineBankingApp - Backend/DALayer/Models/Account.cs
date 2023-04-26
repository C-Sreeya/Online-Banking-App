using System;
using System.Collections.Generic;

#nullable disable

namespace DALayer.Models
{
    public partial class Account
    {
        public Account()
        {
            Loans = new HashSet<Loan>();
            Transactions = new HashSet<Transaction>();
        }

        public string AccountNo { get; set; }
        public int CustomerId { get; set; }
        public string Ifsc { get; set; }
        public int? AccountTypeId { get; set; }
        public int? Balance { get; set; }
        public string Branch { get; set; }
        public string UserType { get; set; }

        public virtual AccountType AccountType { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<Loan> Loans { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
