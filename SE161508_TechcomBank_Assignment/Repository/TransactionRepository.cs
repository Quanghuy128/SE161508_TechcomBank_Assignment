using SE161508_TechcomBank_Assignment.BusinessObject;
using SE161508_TechcomBank_Assignment.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE161508_TechcomBank_Assignment.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        TransactionDBContext transactionDBContext = TransactionDBContext.Instance;

        public void ShowAllTransactions()
        {
            transactionDBContext.ShowAllTransactions();
        }

        public void ShowTransactions()
        {
            List<TransactionDetail> tranList = transactionDBContext.GetTransactionList;
            tranList.ForEach((tran) => Console.WriteLine(tran?.ToString()));
        }
    }
}
