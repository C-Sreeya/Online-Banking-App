using System;
using System.Collections.Generic;
using System.Text;
using EntityLayer;
using DALayer.Models;

namespace DALayer
{
    public interface IAccountDetails
    {
        public bool ChangePassword(SigninModel log);
        public SigninModel GetUserCredentials(string username);
        public List<AccountModel> AccountSummary(string username);
        public List<TransactionModel> RecentFiveTransactions(string username);

    }
}
