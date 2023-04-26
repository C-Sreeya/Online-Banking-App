using System;
using System.Collections.Generic;

#nullable disable

namespace DALayer.Models
{
    public partial class Loan
    {
        public int LoanId { get; set; }
        public int CustomerId { get; set; }
        public string AccountNo { get; set; }
        public int? Amount { get; set; }
        public DateTime? LoanDate { get; set; }
        public int? DurationInMonths { get; set; }
        public string LoanStatus { get; set; }
        public string ApprovalStatus { get; set; }

        public virtual Account AccountNoNavigation { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
