using SE161508_TechcomBank_Assignment.BusinessObject;
using SE161508_TechcomBank_Assignment.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE161508_TechcomBank_Assignment.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private DepartmentDBContext departmentDBContext = DepartmentDBContext.Instance;

        public void AddNewDepartment()
        {
            Console.WriteLine("Enter Your Department Name");
            string depName = Console.ReadLine();
            Console.WriteLine("Enter Your Department Address");
            string address = Console.ReadLine();
            Department dep = new Department(Guid.NewGuid().ToString(), depName, address, null);
            departmentDBContext.AddNewDepartment(dep);
        }

        public List<Department> GetList() => departmentDBContext.GetDepartmentList;

        public void ShowAllDepartment() {
            List<Department> departmentList = departmentDBContext.GetDepartmentList;
            departmentList.ForEach((dep) => Console.WriteLine(dep?.ToString()));
        }
        public void ShowLargestDepositAccounts()
        {
            throw new NotImplementedException();
        }
    }
}
