using SE161508_TechcomBank_Assignment.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace SE161508_TechcomBank_Assignment.DataAccess
{
    public class TransactionDBContext
    {
        private static List<TransactionDetail> TransactionList = new List<TransactionDetail>()
        {
            new TransactionDetail{TransactionID="5bce04a4-55ca-11ed-bdc3-0242ac120002", Date = new DateTime(2022, 10, 25), TransactionMoney=1000, TransactionType='W', AccountRefID="139c35c0-55ca-11ed-bdc3-0242ac120002"},
            new TransactionDetail{TransactionID="5bce081e-55ca-11ed-bdc3-0242ac120002", Date = new DateTime(2022, 10, 22), TransactionMoney=500, TransactionType='W', AccountRefID="139c3d40-55ca-11ed-bdc3-0242ac120002"},
            new TransactionDetail{TransactionID="5bce0986-55ca-11ed-bdc3-0242ac120002", Date = new DateTime(2022, 10, 27), TransactionMoney=400, TransactionType='D', AccountRefID="139c4164-55ca-11ed-bdc3-0242ac120002"},
            new TransactionDetail{TransactionID="5bce13b8-55ca-11ed-bdc3-0242ac120002", Date = new DateTime(2022, 10, 26), TransactionMoney=2000, TransactionType='W', AccountRefID="139c431c-55ca-11ed-bdc3-0242ac120002"},
            new TransactionDetail{TransactionID="5bce0c38-55ca-11ed-bdc3-0242ac120002", Date = new DateTime(2022, 10, 25), TransactionMoney=1400, TransactionType='D', AccountRefID="139c3f84-55ca-11ed-bdc3-0242ac120002"},
            new TransactionDetail{TransactionID="5bce114c-55ca-11ed-bdc3-0242ac120002", Date = new DateTime(2022, 10, 24), TransactionMoney=350, TransactionType='W', AccountRefID="139c3f84-55ca-11ed-bdc3-0242ac120002"},
        };

        private static TransactionDBContext instance = null;
        private static readonly object instanceLock = new object();
        private TransactionDBContext() {}
        public static TransactionDBContext Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new TransactionDBContext();
                    }
                    return instance;
                }
            }
        }

        public List<TransactionDetail> GetTransactionList => TransactionList;
        public TransactionDetail GetTransactionByID(string tranID)
        {
            TransactionDetail tran = TransactionList.SingleOrDefault(tran => tran.TransactionID == tranID);
            return tran;
        }

        public void AddNewTransaction(TransactionDetail transaction)
        {
            TransactionDetail tran = GetTransactionByID(transaction.TransactionID);
            if (tran == null)
            {
                TransactionList.Add(transaction);
            }
            else
            {
                throw new Exception("Transaction is already exists.");
            }
        }
        public void ShowAllTransactions()
        {
            List<Department> departments = DepartmentDBContext.Instance.GetDepartmentList;
            List<Customer> customers = CustomerDBContext.Instance.GetCustomerList;
            List<Account> accounts = AccountDBContext.Instance.GetAccountList;
            var q = (
                from dep in departments
                join customer in customers on dep.DepartmentID equals customer.DepartmentRefID
                join account in accounts on customer.CustomerID equals account.CustomerRefID
                join tran in TransactionList on account.AccountID equals tran.AccountRefID
                select new
                {
                    DepartmentName = dep.DepartmentName,
                    CustomerName = customer.CustomerName,
                    AccountName = account.AccountName,
                    TransactionDate = tran.Date,
                    TransactionMoney = tran.TransactionMoney,
                    Type = tran.TransactionType
                }
            );
            q.ToList().ForEach(i =>
            {
                Console.WriteLine(i.ToString());
            });
        }

    }
}
