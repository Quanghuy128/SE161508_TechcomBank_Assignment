using SE161508_TechcomBank_Assignment.BusinessObject;
using SE161508_TechcomBank_Assignment.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SE161508_TechcomBank_Assignment.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private CustomerDBContext customerDBContext = CustomerDBContext.Instance;
        private AccountDBContext accountDBContext = AccountDBContext.Instance;
        private TransactionDBContext transactionDBContext = TransactionDBContext.Instance;

        public void AddAccountList()
        {
            List<Account> accountList = new List<Account>();
            string customerID;
            Console.WriteLine("Enter Customer ID");
            customerID = Console.ReadLine();
            Customer customerByID = customerDBContext.GetCustomerByID(customerID);
            if(customerByID != null)
            {
                Console.WriteLine("Enter Account name: ");
                string accname = Console.ReadLine();
                Account account = new Account(Guid.NewGuid().ToString(), accname, 0, null, customerID);
                accountDBContext.AddNewAccount(account);
                accountList.Add(account);
                customerDBContext.GetCustomerByID(customerID).AccountList = accountList;
            }else
            {
                Console.WriteLine("Customer is not existed!!!");
            }
        }

        List<Account> IAccountRepository.GetAccountList() => accountDBContext.GetAccountList;

        public void ImplementTransaction()
        {
            List<Account>  AccountList = accountDBContext.GetAccountList;
            Console.WriteLine("Enter Your Account Name");
            string accountName = Console.ReadLine();
            
            Account selectedAccount = accountDBContext.SearchAccountByName(accountName);
            string accID = selectedAccount.AccountID;
            if (selectedAccount != null)
            {
                Console.WriteLine("Enter Transaction Type :  W/D");
                string key = Console.ReadLine();
                if (key.Equals("w", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Enter Money You Want To Withdraw");
                    long money = long.Parse(Console.ReadLine());
                    if (money > selectedAccount.AccountBalance)
                    {
                        Console.WriteLine("You Can't Draw Because Money > Balance ");
                        return;
                    }
                    selectedAccount.AccountBalance -= money;

                    string uuid = Guid.NewGuid().ToString();
                    TransactionDetail transaction = new TransactionDetail(uuid, DateTime.Today, money, 'W', accID);
                    transactionDBContext.AddNewTransaction(transaction);
                    List<TransactionDetail> temp = accountDBContext.GetAccountByID(selectedAccount.AccountID).TransactionList;
                    if(temp == null)
                    {
                        accountDBContext.GetAccountByID(selectedAccount.AccountID).TransactionList = new List<TransactionDetail>();
                    }else
                    {
                        accountDBContext.GetAccountByID(selectedAccount.AccountID)?.TransactionList?.Add(transaction);
                    }
                }
                if (key.Equals("d", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Enter Money You Want Deposit: ");
                    long money = long.Parse(Console.ReadLine());

                    selectedAccount.AccountBalance += money;

                    string uuid = Guid.NewGuid().ToString();
                    TransactionDetail transaction = new TransactionDetail(uuid, DateTime.Today, money, 'D', accID);
                    transactionDBContext.AddNewTransaction(transaction);
                    List<TransactionDetail> temp = accountDBContext.GetAccountByID(selectedAccount.AccountID).TransactionList;
                    if (temp == null)
                    {
                        accountDBContext.GetAccountByID(selectedAccount.AccountID).TransactionList = new List<TransactionDetail>();
                    }
                    else
                    {
                        accountDBContext.GetAccountByID(selectedAccount.AccountID)?.TransactionList?.Add(transaction);
                    }
                }
            }
            else
            {
                Console.WriteLine("Account is not existed");
            }
        }
        public void ShowAllAccounts()
        {
            List<Account> accountList = accountDBContext.GetAccountList;
            accountList.ForEach((acc) => Console.WriteLine(acc?.ToString()));
        }

        public void ShowMostRemainMoneyAccount()
        {
            accountDBContext.FilterAccountsHaveMostRemainMoney();
        }

        public void ShowCustomerHasHighestTransaction()
        {
            accountDBContext.ShowCustomerHasHighestTransaction();
        }

        
    }
}
