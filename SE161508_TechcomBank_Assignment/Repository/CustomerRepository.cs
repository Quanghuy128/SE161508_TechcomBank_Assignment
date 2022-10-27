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
    public class CustomerRepository : ICustomerRepository
    {
        CustomerDBContext customerDBContext = CustomerDBContext.Instance;
        DepartmentDBContext departmentDBContext = DepartmentDBContext.Instance;

        public void AddCustomerList(string depID)
        {
            Department dep = departmentDBContext.GetDepartmentByID(depID);
            List<Customer> customerList = new List<Customer>();
            if (dep != null)
            {
                Console.WriteLine("Enter Number Customer You Want To Add");
                int cusNum = int.Parse(Console.ReadLine());
                int count = 1;
                string name, address;
                while (count <= cusNum)
                {
                    
                    Console.WriteLine("Enter Customer Name");
                    name = Console.ReadLine();
                    Console.WriteLine("Enter Customer Address");
                    address = Console.ReadLine();
                    Customer customer = new Customer(Guid.NewGuid().ToString(), name, address, null, depID);
                    customerDBContext.AddNewCustomer(customer);
                    count++;
                }
                departmentDBContext.GetDepartmentByID(depID).CustomerList = customerList;
            }else
            {
                Console.WriteLine("Department is not existed");
            }
        }

        public List<Customer> CustomerList()
        {
            throw new NotImplementedException();
        }

        public void SearchCustomers(string searchValue)
        {
            var filterCusList = customerDBContext.Search(searchValue);
            foreach(var customer in filterCusList)
            {
                Console.WriteLine(customer.ToString());
            }
        }

        public void ShowAccountByDepositOrder()
        {
            throw new NotImplementedException();
        }

        public void ShowAccountHasMostTransaction()
        {
            throw new NotImplementedException();
        }

        public void ShowAllCustomers()
        {
            List<Customer> customerList = customerDBContext.GetCustomerList;
            customerList.ForEach((cus) => Console.WriteLine(cus?.ToString()));
        }
        public void ShowRemainMoneyOrderByAsc()
        {
            customerDBContext.ShowRemainMoneyOrderByAsc();
        }
    }
}
