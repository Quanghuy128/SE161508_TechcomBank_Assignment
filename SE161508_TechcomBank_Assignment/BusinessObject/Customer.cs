using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace SE161508_TechcomBank_Assignment.BusinessObject
{
    public class Customer
    {
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public List<Account> AccountList { get; set; }
        public string DepartmentRefID { get; set; }

        public Customer(string customerID, string customerName, string customerAddress, List<Account> accountList, string departmentRefID)
        {
            CustomerID = customerID;
            CustomerName = customerName;
            CustomerAddress = customerAddress;
            AccountList = accountList;
            DepartmentRefID = departmentRefID;
        }
        public Customer()
        {
        }

        public override string? ToString()
        {
            return $"CustomerID :{this.CustomerID}, CustomerName :{this.CustomerName}, Address :{this.CustomerAddress}";
        } 
        
    }
}
