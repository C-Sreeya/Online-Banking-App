using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DALayer;
using DALayer.Models;
using EntityLayer;
using Microsoft.EntityFrameworkCore;

namespace DALayer
{
    public class AccountDetailsDataService : IAccountDetails
    {
        private OnlineBankingSystemDbContext db;
        public AccountDetailsDataService(OnlineBankingSystemDbContext db)
        {
            this.db = db;
        }

        public bool ChangePassword(SigninModel log)
        {
            try
            {
                var user = db.UserCredentials.Find(log.UserName);
                if(user!=null)
                {
                    user.Password = log.Password;
                    DateTime now = DateTime.Now;
                    user.ModifiedDate = now;
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();

                    return true;
                }
                else
                {
                    throw new Exception("Wrong Password");
                }
            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public SigninModel GetUserCredentials(string username)
        {
            try
            {
                var IsValidUser = db.UserCredentials.Find(username);
                if(IsValidUser!=null)
                {
                    SigninModel user = new SigninModel();
                    user.UserName = IsValidUser.UserName;
                    user.Password = IsValidUser.Password;

                    return user;
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



        public List<AccountModel> AccountSummary(string username)
        {
            List<AccountModel> accountDetails = new List<AccountModel>();

            try
            {
                var user = db.UserCredentials.Find(username);

                if(user!=null)
                {
                    var CustomerDtl = db.Customers.Find(user.CustomerId);

                    var Accountslst = db.Accounts.Where(act => act.CustomerId == CustomerDtl.CustomerId).Select(act => act);
                    foreach(var account in Accountslst)
                    {
                        AccountModel act = new AccountModel();
                        act.CustomerId = CustomerDtl.CustomerId;
                        act.CustomerName = CustomerDtl.CustomerName;
                        act.CustomerAge = CustomerDtl.CustomerAge;
                        act.CustomerAddress = CustomerDtl.CustomerAddress;
                        act.CustomerPhNo = CustomerDtl.CustomerPhNo;
                        act.Dob = CustomerDtl.Dob;
                        act.AccountNo= account.AccountNo;
                        act.AccountTypeId= account.AccountTypeId;
                        act.Balance= account.Balance;
                        act.Branch = account.Branch;
                        act.UserType= account.UserType;
                        act.Ifsc= account.Ifsc;
                        accountDetails.Add(act);
                    }

                    return accountDetails;
                    
                }
                else
                {
                    return accountDetails;
                }

            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<TransactionModel> RecentFiveTransactions(string username)
        {
            List<TransactionModel> transactionlst = new List<TransactionModel>();
            try
            {               
                var user = db.UserCredentials.Find(username);
                if (user != null)
                {
                    var transactions = db.Transactions.Where(transaction => transaction.CustomerId == user.CustomerId).
                        OrderByDescending(transaction => transaction.DateOfTransaction).Take(5).ToList();

                    foreach (var transRec in transactions)
                    {
                        TransactionModel transaction = new TransactionModel();
                        transaction.CustomerId = transRec.CustomerId;
                        transaction.AccountNo = transRec.AccountNo;
                        transaction.TransactionId = transRec.TransactionId;
                        transaction.Amount = transRec.Amount;
                        transaction.DateOfTransaction = transRec.DateOfTransaction;
                        transaction.DebitOrCredit = transRec.DebitOrCredit;
                        transaction.TransactionStatus = transRec.TransactionStatus;
                        transaction.ReceiverAccountNo = transRec.ReceiverAccountNo;
                        transaction.ReceiverUserName = transRec.ReceiverUserName;

                        transactionlst.Add(transaction);
                    }

                    return transactionlst;
                }
                else
                {
                    throw new Exception("Invalid UserName");
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }




    }
}
