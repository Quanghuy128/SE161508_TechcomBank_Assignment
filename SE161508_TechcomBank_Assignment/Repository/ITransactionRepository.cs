using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE161508_TechcomBank_Assignment.Repository
{
    public interface ITransactionRepository
    {
        public void ShowTransactions();
        public void ShowAllTransactions();
    }
}
