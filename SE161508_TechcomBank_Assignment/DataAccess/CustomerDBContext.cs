using SE161508_TechcomBank_Assignment.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE161508_TechcomBank_Assignment.DataAccess
{
    public class CustomerDBContext
    {
        private static List<Customer> CustomerList = new List<Customer>()
        {
            new Customer {CustomerID = "c9bf210c-baf6-445f-9b07-df1149a8e2e0", CustomerName="Quang Huy", CustomerAddress="ABC, Do Xuan Hop Street, HCM City, Vietnam", AccountList = new List<Account>(), DepartmentRefID = "5e0a875d-0fab-41b5-9dbf-e25a85d73c25"},
            new Customer {CustomerID = "9336e81b-0903-4efa-bb4c-fe27c85fbdc7", CustomerName="Quang Huy Nguyen", CustomerAddress="ABC, Do Xuan Hop Street, HCM City, Vietnam", AccountList = new List<Account>(), DepartmentRefID = "c8c9a9ab-96bd-4a8a-8b3a-2c3accd7da1f"},
            new Customer {CustomerID = "1b4b9aa9-38be-443b-8e91-4e67e10abfad", CustomerName="Customer 3", CustomerAddress="ABCD, Do Xuan Hop Street, HCM City, Vietnam", AccountList = new List<Account>(), DepartmentRefID = "5e0a875d-0fab-41b5-9dbf-e25a85d73c25"},
            new Customer {CustomerID = "7b749673-4daf-44ff-bed7-e1d7c6429c40", CustomerName="Customer 4", CustomerAddress="ABCDDD, Do Xuan Hop Street, HCM City, Vietnam", AccountList = new List<Account>(), DepartmentRefID = "dd4fd402-865a-422d-9d0a-71463044a3ad"},
        };

        private static CustomerDBContext instance = null;
        private static readonly object instanceLock = new object();
        private CustomerDBContext() {}
        public static CustomerDBContext Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CustomerDBContext();
                    }
                    return instance;
                }
            }
        }
        public List<Customer> GetCustomerList => CustomerList;

        public Customer GetCustomerByID(string cusID)
        {
            Customer cus = CustomerList.SingleOrDefault(cus => cus.CustomerID == cusID);
            return cus;
        }

        public void AddNewCustomer(Customer customer)
        {
            Customer cus = GetCustomerByID(customer.CustomerID);
            if (cus == null)
            {
                CustomerList.Add(customer);
            }
            else
            {
                throw new Exception("Customer is already exists.");
            }
        }
        public IEnumerable<Customer> Search(string searchValue) => from customer in CustomerList 
                                                                  where customer.CustomerName.Contains(searchValue, StringComparison.OrdinalIgnoreCase) 
                                                                  select customer;
        public void ShowRemainMoneyOrderByAsc()
        {
            List<Account> accounts = AccountDBContext.Instance.GetAccountList;

            var q = (from customer in CustomerList
                     join account in accounts on customer.CustomerID equals account.CustomerRefID
                     group account by new
                     {
                         customer.CustomerID,
                         customer.CustomerName,
                         account.AccountID,
                     }
                    into g
                     select new
                     {
                         CustomerID = g.Key.CustomerID,
                         CustomerName = g.Key.CustomerName,
                         AccountBalance = g.Max(x => x.AccountBalance),
                         AccountID = g.Key.AccountID,
                     }).OrderBy(x => x.AccountBalance);

            q.ToList().ForEach(acc =>
            {
                Console.WriteLine(acc.ToString());
            });
        }
    }
}
