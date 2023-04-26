using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace DALayer
{
    public interface IAccount
    {
        public List<AccountModel> DisplayAllAccounts();
        public List<AccountModel> DisplayAcctbyCustId(int custId);
    }
}
