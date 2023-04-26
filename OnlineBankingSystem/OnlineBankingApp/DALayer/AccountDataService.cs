using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALayer;
using DALayer.Models;
using EntityLayer;
using Microsoft.EntityFrameworkCore;

namespace DALayer
{
    public class AccountDataService : IAccount
    {
        private OnlineBankingSystemDbContext db;



        public AccountDataService(OnlineBankingSystemDbContext db)
        {
            this.db = db;
        }

        public List<AccountModel> DisplayAllAccounts()
        {
            List<AccountModel> Actlst = new List<AccountModel>();

            List<Account> acts = new List<Account>();
            try
            {
                acts = db.Accounts.ToList();
                foreach(var account in acts)
                {
                    AccountModel act = new AccountModel();
                    act.CustomerId = account.CustomerId;
                    act.AccountNo = account.AccountNo;
                    act.AccountTypeId = account.AccountTypeId;
                    act.Balance = account.Balance;
                    act.Branch = account.Branch;
                    act.UserType = account.UserType;
                    act.Ifsc = account.Ifsc;

                    var customer = db.Customers.Find(act.CustomerId);

                    act.CustomerName = customer.CustomerName;
                    act.CustomerAge = customer.CustomerAge;
                    act.CustomerPhNo = customer.CustomerPhNo;
                    act.CustomerAddress = customer.CustomerAddress;
                    act.Dob = customer.Dob;


                    Actlst.Add(act);

                }
                Actlst = Actlst.OrderBy(act => act.CustomerId).ToList();
                return Actlst;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<AccountModel> DisplayAcctbyCustId(int custId)
        {
            List<AccountModel> Actlst = new List<AccountModel>();

            List<Account> acts = new List<Account>();
            Customer cust = new Customer();

            try
            {
                cust = db.Customers.Find(custId);
                if(cust!=null)
                {
                    
                    acts = db.Accounts.ToList();
                    foreach(var act in acts)
                    {
                        if(act.CustomerId==cust.CustomerId)
                        {
                            AccountModel a = new AccountModel();
                            a.CustomerId = cust.CustomerId;
                            a.CustomerName = cust.CustomerName;
                            a.CustomerAge = cust.CustomerAge;
                            a.CustomerPhNo = cust.CustomerPhNo;
                            a.CustomerAddress = cust.CustomerAddress;
                            a.Dob = cust.Dob;
                            a.AccountNo = act.AccountNo;
                            a.AccountTypeId = act.AccountTypeId;
                            a.Balance = act.Balance;
                            a.Branch = act.Branch;
                            a.UserType = act.UserType;
                            a.Ifsc = act.Ifsc;

                            Actlst.Add(a);

                        }
                    }
                    return Actlst;

                }
                else
                {
                    throw new Exception("Invalid Customer Id");
                }               
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
