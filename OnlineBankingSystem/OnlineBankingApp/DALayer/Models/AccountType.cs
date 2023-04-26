using System;
using System.Collections.Generic;

#nullable disable

namespace DALayer.Models
{
    public partial class AccountType
    {
        public AccountType()
        {
            Accounts = new HashSet<Account>();
        }

        public int AccountTypeId { get; set; }
        public string AcctType { get; set; }
        public double? MinBalance { get; set; }
        public int? Interest { get; set; }
        public int? TransactionLimit { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
