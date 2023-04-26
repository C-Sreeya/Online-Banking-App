using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace EntityLayer
{
    public class TransactionModel
    {
        [JsonIgnore]
        public int TransactionId { get; set; }
        public int CustomerId { get; set; }
        public string AccountNo { get; set; }
        public string ReceiverUserName { get; set; }
        public string ReceiverAccountNo { get; set; }
        public int? Amount { get; set; }

        [JsonIgnore]
        public string DebitOrCredit { get; set; }

        [JsonIgnore]
        public DateTime? DateOfTransaction { get; set; }

        [JsonIgnore]
        public string TransactionStatus { get; set; }
    }
}
