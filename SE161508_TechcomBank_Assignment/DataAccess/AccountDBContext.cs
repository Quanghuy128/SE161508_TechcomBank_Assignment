using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

using SE161508_TechcomBank_Assignment.BusinessObject;
namespace SE161508_TechcomBank_Assignment.DataAccess
{
    public class AccountDBContext
    {
        private static List<Account> AccountList = new List<Account>()
        {
            new Account{ AccountID = "139c35c0-55ca-11ed-bdc3-0242ac120002", AccountName = "abc123", AccountBalance = 1000000, TransactionList = new List<TransactionDetail>(), CustomerRefID = "c9bf210c-baf6-445f-9b07-df1149a8e2e0"},
            new Account{ AccountID = "139c35c1-55ca-11ed-bdc3-0242ac120002", AccountName = "abc1231", AccountBalance = 2000000, TransactionList = new List<TransactionDetail>(), CustomerRefID = "c9bf210c-baf6-445f-9b07-df1149a8e2e0"},
            new Account{ AccountID = "139c3d40-55ca-11ed-bdc3-0242ac120002", AccountName = "abc1234", AccountBalance = 60000, TransactionList = new List<TransactionDetail>(), CustomerRefID = "9336e81b-0903-4efa-bb4c-fe27c85fbdc7"},
            new Account{ AccountID = "139c3f84-55ca-11ed-bdc3-0242ac120002", AccountName = "abc1235", AccountBalance = 3000000, TransactionList = new List<TransactionDetail>(), CustomerRefID = "1b4b9aa9-38be-443b-8e91-4e67e10abfad"},
            new Account{ AccountID = "139c4164-55ca-11ed-bdc3-0242ac120002", AccountName = "abc1236", AccountBalance = 1000000, TransactionList = new List<TransactionDetail>(), CustomerRefID = "c9bf210c-baf6-445f-9b07-df1149a8e2e0"},
            new Account{ AccountID = "139c431c-55ca-11ed-bdc3-0242ac120002", AccountName = "abc123123", AccountBalance = 1500000, TransactionList = new List<TransactionDetail>(), CustomerRefID = "7b749673-4daf-44ff-bed7-e1d7c6429c40"},
        };

        //Singleton Pattern
        private static AccountDBContext instance = null;
        private static readonly object instanceLock = new object();
        private AccountDBContext() { } // constructor private
        public static AccountDBContext Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new AccountDBContext();
                    }
                    return instance;
                }
            }
        }

        public List<Account> GetAccountList => AccountList;

        public Account GetAccountByID(string accID)
        {
            Account acc = AccountList.SingleOrDefault(acc => acc.AccountID == accID);
            return acc;
        }

        public void AddNewAccount(Account account)
        {
            Account acc = GetAccountByID(account.AccountID);
            if (acc == null)
            {
                AccountList.Add(account);
            }
            else
            {
                throw new Exception("Account is already exists.");
            }
        }
        public Account SearchAccountByName(string accName) {
            var accList = from account in AccountList
                            where account.AccountName.Equals(accName)
                            select account;
            Account searchAccount = accList.First();
            return searchAccount;
        } 
        public void FilterAccountsHaveMostRemainMoney ()
        {
            List<Customer> customers = CustomerDBContext.Instance.GetCustomerList;
            var q = (
                     from customer in customers
                     join account in AccountList on customer.CustomerID equals account.CustomerRefID
                     group account by new
                     {
                         customer.CustomerID,
                         customer.CustomerName,
                     }
                    into gr
                     select new
                     {
                         CustomerName = gr.Key.CustomerName,
                         AccountName = (from t2 in gr orderby t2.AccountBalance descending select t2.AccountName).First(),
                         AccountBalance = (from t2 in gr select t2.AccountBalance).Max(),
                     });
            q.ToList().ForEach(acc =>
            {
                Console.WriteLine(acc.ToString());
            });
        } 
        public void ShowCustomerHasHighestTransaction ()
        {
            List<TransactionDetail> transactions = TransactionDBContext.Instance.GetTransactionList;
            List<Customer> customers = CustomerDBContext.Instance.GetCustomerList;
            var q = (from customer in customers
                    join account in AccountList on customer.CustomerID equals account.CustomerRefID
                    join tran in transactions on account.AccountID equals tran.AccountRefID
                    group tran by new
                    {
                        account.AccountID,
                        customer.CustomerID,
                        customer.CustomerName,
                    }
                    into g
                    select new 
                    {
                        CustomerID = g.Key.CustomerID,
                        CustomerName = g.Key.CustomerName,
                        TransactionTotal = g.Count()
                    }).OrderByDescending(x => x.TransactionTotal).FirstOrDefault();

            Console.WriteLine("Customer Has Highest Transaction:");
            Console.WriteLine($"CustomerID: {q.CustomerID}, CustomerName: {q.CustomerName}, TransactionTotal: {q.TransactionTotal}");
        }

    }
}
