using System;
using System.Collections.Generic;

#nullable disable

namespace DALayer.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Accounts = new HashSet<Account>();
            Loans = new HashSet<Loan>();
            Transactions = new HashSet<Transaction>();
        }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhNo { get; set; }
        public int? CustomerAge { get; set; }
        public DateTime? Dob { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Loan> Loans { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
