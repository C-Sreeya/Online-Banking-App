using System;
using System.Collections.Generic;

#nullable disable

namespace DALayer.Models
{
    public partial class Transaction
    {
        public int TransactionId { get; set; }
        public int CustomerId { get; set; }
        public string AccountNo { get; set; }
        public string ReceiverAccountNo { get; set; }
        public int? Amount { get; set; }
        public string DebitOrCredit { get; set; }
        public DateTime? DateOfTransaction { get; set; }
        public string TransactionStatus { get; set; }
        public string ReceiverUserName { get; set; }

        public virtual Account AccountNoNavigation { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
