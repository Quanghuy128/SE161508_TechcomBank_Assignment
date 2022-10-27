using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE161508_TechcomBank_Assignment.BusinessObject
{
    public class TransactionDetail
    {
        public string TransactionID { get; set; }
        public DateTime Date { get; set; }
        public long TransactionMoney { get; set; }
        public char TransactionType { get; set; }
        public string AccountRefID { get; set; }

        public TransactionDetail(string transactionID, DateTime date, long transactionMoney, char transactionType, string accountRefID)
        {
            TransactionID = transactionID;
            Date = date;
            TransactionMoney = transactionMoney;
            TransactionType = transactionType;
            AccountRefID = accountRefID;
        }
        public TransactionDetail()
        {
        }

        public override string? ToString() => $"TransactionID : {this.TransactionID}, Date : {this.Date},TransactionMoney :{this.TransactionMoney},TransactionType : {this.TransactionType}, AccountID: {this.AccountRefID}";

    }
}
