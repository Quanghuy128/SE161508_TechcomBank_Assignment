using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE161508_TechcomBank_Assignment.BusinessObject
{
    public class Department
    {
        public string DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentAddress { get; set; }
        public List<Customer> CustomerList { get; set; }

        public Department(string departmentID, string departmentName, string departmentAddress, List<Customer> customerList)
        {
            DepartmentID = departmentID;
            DepartmentName = departmentName;
            DepartmentAddress = departmentAddress;
            CustomerList = customerList;
        }
        public Department() { }

        public override string? ToString()
        {
            return $"DepartmentID : {this.DepartmentID}, DepartmentName : {this.DepartmentName}, Address :{this.DepartmentAddress}";
        }
}
}
