using SE161508_TechcomBank_Assignment.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE161508_TechcomBank_Assignment.Repository
{
    public interface ICustomerRepository
    {
        void ShowAccountByDepositOrder();
        void ShowAccountHasMostTransaction();
        void AddCustomerList(string depID);
        void ShowAllCustomers();
        List<Customer> CustomerList();
        void SearchCustomers(string searchValue);
        public void ShowRemainMoneyOrderByAsc();
    }
}
