using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;


namespace DALayer
{
    public interface ILoan
    {       
        public bool NewLoan(LoanModel newln);
        public List<LoanModel> LoanStatusOfCustomer(string Username);
        public bool ApproveLoan(int loanId);
        public List<LoanModel> GetAllLoanDetails();
    }
}
