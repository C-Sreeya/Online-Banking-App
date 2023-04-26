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
    public class TransactionDataService: ITransaction
    {
        private OnlineBankingSystemDbContext db;
        public TransactionDataService(OnlineBankingSystemDbContext db)
        {
            this.db = db;
        }
        public bool NewTransaction(TransactionModel details)
        {
            try
            {
                var valid = db.Accounts.Where(account => account.CustomerId == details.CustomerId && 
                        account.AccountNo == details.AccountNo).FirstOrDefault();

                var isSender= db.UserCredentials.Where( user => user.CustomerId==details.CustomerId).FirstOrDefault();

                var isReceiver = db.UserCredentials.Find(details.ReceiverUserName);

                var receiverValid = db.Accounts.Where(act => act.AccountNo==details.ReceiverAccountNo && act.CustomerId==isReceiver.CustomerId).FirstOrDefault();

                bool flag;

                if(valid!=null && isSender!=null)
                {
                    if(receiverValid != null)
                    {
                        if (valid.Ifsc == receiverValid.Ifsc)
                        {
                            Transaction sender = new Transaction();
                            sender.CustomerId = details.CustomerId;
                            sender.AccountNo = details.AccountNo;
                            sender.Amount = details.Amount;
                            sender.DateOfTransaction = DateTime.Now;
                            sender.ReceiverAccountNo = details.ReceiverAccountNo;
                            sender.ReceiverUserName = details.ReceiverUserName;

                            if (valid.Balance >= details.Amount)
                            {
                                valid.Balance = valid.Balance - details.Amount;
                                db.Entry(valid).State = EntityState.Modified;
                                int senderstatus = db.SaveChanges();

                                receiverValid.Balance = receiverValid.Balance + details.Amount;
                                db.Entry(receiverValid).State = EntityState.Modified;
                                int receiverstatus = db.SaveChanges();

                                if (senderstatus != 0 && receiverstatus != 0)
                                {
                                    sender.DebitOrCredit = "+";
                                    sender.TransactionStatus = "Success";

                                    db.Transactions.Add(sender);
                                    db.SaveChanges();

                                    Transaction receiver = new Transaction();
                                    receiver.CustomerId = receiverValid.CustomerId;
                                    receiver.AccountNo = receiverValid.AccountNo;
                                    receiver.Amount = details.Amount;
                                    receiver.DateOfTransaction = DateTime.Now;
                                    receiver.ReceiverAccountNo = details.AccountNo;
                                    receiver.ReceiverUserName = isSender.UserName;
                                    receiver.DebitOrCredit = "-";
                                    receiver.TransactionStatus = "Success";

                                    db.Transactions.Add(receiver);
                                    db.SaveChanges();

                                    flag = true;
                                }
                                else
                                {
                                    throw new Exception("Cannot Make Transaction");
                                }
                            }
                            else
                            {
                                sender.DebitOrCredit = "+";
                                sender.TransactionStatus = "Failure";

                                db.Transactions.Add(sender);
                                db.SaveChanges();

                                flag = false;
                            }
                            return flag;
                        }
                        else
                        {
                            throw new Exception("Sender and Receiver Banks are different");
                        }
                    }
                    else
                    {
                        throw new Exception("Invalid Receiver username");
                    }
                                      
                }
                else
                {
                    throw new Exception("Invalid Sender Details");
                }

            }catch(Exception e)
            {
                if(e.InnerException!=null)
                {
                    throw new Exception(e.InnerException.Message);
                }
                throw new Exception(e.Message);
            }
        }


        public List<TransactionModel> AllTransactions()
        {
            List<TransactionModel> transactionlst = new List<TransactionModel>();
            try
            {
                var transactions = db.Transactions.ToList();
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
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

    }
}
