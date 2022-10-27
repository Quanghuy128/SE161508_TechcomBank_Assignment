using SE161508_TechcomBank_Assignment.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE161508_TechcomBank_Assignment.DataAccess
{
    public class DepartmentDBContext
    {
        private static List<Department> DepartmentList = new List<Department>()
        {
            new Department {DepartmentID = "5e0a875d-0fab-41b5-9dbf-e25a85d73c25", DepartmentName = "Techcombank DN", DepartmentAddress="Da Nang City, VietNam", CustomerList = new List<Customer>() },
            new Department {DepartmentID = "c8c9a9ab-96bd-4a8a-8b3a-2c3accd7da1f", DepartmentName = "Techcombank HN", DepartmentAddress="Hang Ma, Ha Noi, VietNam", CustomerList = new List<Customer>() },
            new Department {DepartmentID = "dd4fd402-865a-422d-9d0a-71463044a3ad", DepartmentName = "Techcombank HCM", DepartmentAddress="District 9, HCM City, VietNam", CustomerList = new List<Customer>() },
        };

        //Singleton Pattern
        private static DepartmentDBContext instance = null;
        private static readonly object instanceLock = new object();
        private DepartmentDBContext() { } // constructor private
        public static DepartmentDBContext Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new DepartmentDBContext();
                    }
                    return instance;
                }
            }
        }

        public List<Department> GetDepartmentList => DepartmentList;
        public Department GetDepartmentByID(string depID)
        {
            Department dep = DepartmentList.SingleOrDefault(dep => dep.DepartmentID == depID);
            return dep;
        }
        public void AddNewDepartment(Department department)
        {
            Department dep = GetDepartmentByID(department.DepartmentID);
            if (dep == null)
            {
                DepartmentList.Add(department);
            }
            else
            {
                throw new Exception("Department is already exists.");
            }
        }
    }
}
