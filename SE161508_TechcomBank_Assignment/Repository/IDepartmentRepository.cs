using SE161508_TechcomBank_Assignment.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE161508_TechcomBank_Assignment.Repository
{
    public interface IDepartmentRepository
    {
        void AddNewDepartment();
        void ShowLargestDepositAccounts();
        void ShowAllDepartment();
        List<Department> GetList();
    }
}
