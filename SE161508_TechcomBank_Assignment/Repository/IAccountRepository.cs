using SE161508_TechcomBank_Assignment.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE161508_TechcomBank_Assignment.Repository
{
    public interface IAccountRepository
    {
        void AddAccountList();
        List<Account> GetAccountList();
        void ImplementTransaction();
        void ShowMostRemainMoneyAccount();
        void ShowCustomerHasHighestTransaction();
    }
}
