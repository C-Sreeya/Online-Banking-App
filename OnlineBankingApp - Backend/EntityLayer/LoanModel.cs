using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace EntityLayer
{
    public class LoanModel
    {
        public int CustomerId { get; set; }
        public string AccountNo { get; set; }
        public int? Amount { get; set; }
        public int? DurationInMonths { get; set; }

        [JsonIgnore]
        public int LoanId { get; set; }

        [JsonIgnore]
        public DateTime? LoanDate { get; set; }

        [JsonIgnore]
        public string LoanStatus { get; set; }

        [JsonIgnore]
        public string ApprovalStatus { get; set; }

    }
}
