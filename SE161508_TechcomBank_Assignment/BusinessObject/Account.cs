using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE161508_TechcomBank_Assignment.BusinessObject
{
    public class Account
    {
        public string AccountID { get; set; }
        public string AccountName { get; set; }
        public long AccountBalance { get; set; }
        public List<TransactionDetail> TransactionList { get; set; }
        public string CustomerRefID { get; set; }
        public Account(string accountID, string accountName, long accountBalance, List<TransactionDetail> transactionList, string customerID)
        {
            AccountID = accountID;
            AccountName = accountName;
            AccountBalance = accountBalance;
            TransactionList = transactionList;
            CustomerRefID = customerID;
        }
        public Account()
        {
        }
        public override string? ToString(){
            return $"AccountID : {this.AccountID}, AccountName : {this.AccountName}, AccountBalance : {this.AccountBalance}";
        }

    }
}
