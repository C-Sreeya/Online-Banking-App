using System;
using System.Collections.Generic;
using System.Text;
using EntityLayer;

namespace DALayer
{
    public interface ITransaction
    {
        public bool NewTransaction(TransactionModel details);
        public List<TransactionModel> AllTransactions();
    }
}
