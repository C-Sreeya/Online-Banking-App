using System;
using System.Collections.Generic;
using System.Text;
using DALayer.Models;
using DALayer;
using EntityLayer;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DALayer
{
    public class LoanDataService:ILoan
    {
        private OnlineBankingSystemDbContext db;
        public LoanDataService(OnlineBankingSystemDbContext db)
        {
            this.db = db;
        }
        public bool NewLoan(LoanModel newln)
        {
            Loan ln = new Loan();
            ln.CustomerId = newln.CustomerId;
            ln.AccountNo = newln.AccountNo;
            ln.Amount = newln.Amount;
            ln.DurationInMonths = newln.DurationInMonths;

            var act = db.Accounts.Find(newln.AccountNo);
            
            try
            {    
                if (ln != null)
                {
                    if(act!=null)
                    {
                        if (act.CustomerId == newln.CustomerId & act.AccountNo == newln.AccountNo)
                        {
                            ln.ApprovalStatus = "Applied";

                            db.Loans.Add(ln);
                            db.SaveChanges();

                            return true;
                        }
                        else
                        {
                            throw new Exception("Incorrect Customer Id or AccountNo");
                        }
                    }
                    else
                    {
                        throw new Exception("Customer Id or AccountNo not found");
                    }
                }
                else
                {
                    throw new Exception("Invalid Details");
                }               
            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public List<LoanModel> LoanStatusOfCustomer(string Username)
        {
            try
            {
                var user = this.db.UserCredentials.Find(Username);
                if (user != null)
                {
                    List<LoanModel> lnlst = new List<LoanModel>();
                    var loandtls = db.Loans.Where(l => l.CustomerId == user.CustomerId).Select(l => l);
                    if (loandtls != null)
                    {
                        foreach(var loan in loandtls)
                        {
                            LoanModel l = new LoanModel();
                            l.AccountNo = loan.AccountNo;
                            l.CustomerId = loan.CustomerId;
                            l.LoanId = loan.LoanId;
                            l.Amount = loan.Amount;
                            l.DurationInMonths = loan.DurationInMonths;
                            l.LoanDate = loan.LoanDate;
                            l.LoanStatus = loan.LoanStatus;
                            l.ApprovalStatus = loan.ApprovalStatus;
                            lnlst.Add(l);
                        }
                        return lnlst;
                    }
                    else
                    {
                        return lnlst;
                    }
                }
                else
                {
                    throw new Exception("User not found");
                }
            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool ApproveLoan(int loanId)
        {
            try
            {
                var loanRec = db.Loans.Find(loanId);
                if(loanRec!=null)
                {
                    if(loanRec.ApprovalStatus=="Applied" || loanRec.ApprovalStatus=="applied")
                    {
                        loanRec.ApprovalStatus = "Approved";

                        loanRec.LoanDate = DateTime.Now.Date;

                        loanRec.LoanStatus = "Active";

                        db.Entry(loanRec).State=EntityState.Modified ;
                        db.SaveChanges();

                        return true;

                    }
                    else if(loanRec.ApprovalStatus=="Approved")
                    {
                        return false;
                    }
                    else
                    {
                        throw new Exception("Cannot approve loan");
                    }
                }
                else
                {
                    throw new Exception("Invalid LoanId");
                }

            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<LoanModel> GetAllLoanDetails()
        {
            try
            {
                var loandtls = db.Loans.ToList();
                if(loandtls!=null)
                {
                    List<LoanModel> loanlst = new List<LoanModel>();

                    foreach(var l in loandtls)
                    {
                        LoanModel loan = new LoanModel();
                        loan.AccountNo = l.AccountNo;
                        loan.CustomerId = l.CustomerId;
                        loan.LoanId = l.LoanId;
                        loan.Amount = l.Amount;
                        loan.DurationInMonths = l.DurationInMonths;
                        loan.ApprovalStatus = l.ApprovalStatus;
                        loan.LoanStatus = l.LoanStatus;
                        loan.LoanDate = l.LoanDate;

                        loanlst.Add(loan);

                    }
                    return loanlst;
                }
                else
                {
                    throw new Exception("No records found");
                }

            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
