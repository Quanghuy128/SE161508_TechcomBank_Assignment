

using SE161508_TechcomBank_Assignment.Repository;
using System.ComponentModel.Design;

namespace SE161508_TechcomBank_Assignment
{
    public class Program
    {
        private static void Menu()
        {
            Console.WriteLine("-----------------------WELCOME TO TECHCOMBANK-----------------------");
            Console.WriteLine("1. Add New Department");
            Console.WriteLine("2. Add New Customers");
            Console.WriteLine("3. Add New Accounts");
            Console.WriteLine("4. Show Infomation Of Any Customer");
            Console.WriteLine("5. WithDraw/Deposit");
            Console.WriteLine("6. Show All Transaction of Account, Customer, Department");
            Console.WriteLine("7. Show Accounts have Most Remains Money");
            Console.WriteLine("8. Order Remains Money Each Customer and Show information of Customer");
            Console.WriteLine("9. Show Customers have Most Transaction Times");
        }
        public static void Main()
        {
            DepartmentRepository departmentRepository = new DepartmentRepository();
            CustomerRepository customerRepository = new CustomerRepository();
            AccountRepository accountRepository = new AccountRepository();
            TransactionRepository transactionRepository = new TransactionRepository();
            int choice;
            do
            {
                Menu();
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                        departmentRepository.ShowAllDepartment();
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                        departmentRepository.AddNewDepartment();
                        Console.WriteLine("Add Successfully");
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                        departmentRepository.ShowAllDepartment();
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                        break;
                    case 2:
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                        departmentRepository.ShowAllDepartment();
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                        Console.WriteLine("Enter Department ID");
                        string depID = Console.ReadLine();
                        customerRepository.AddCustomerList(depID);
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                        customerRepository.ShowAllCustomers();
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                        break;
                    case 3:
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                        customerRepository.ShowAllCustomers();
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                        accountRepository.AddAccountList();
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                        accountRepository.ShowAllAccounts();
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                        break;
                    case 4:
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                        customerRepository.ShowAllCustomers();
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                        Console.WriteLine("Search Customer: ");
                        string searchValue = Console.ReadLine();
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                        customerRepository.SearchCustomers(searchValue);
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                        break;
                    case 5:
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                        accountRepository.ShowAllAccounts();
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------");

                        accountRepository.ImplementTransaction();
                        accountRepository.ShowAllAccounts();
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                        transactionRepository.ShowTransactions();
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                        break;
                    case 6:
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                        transactionRepository.ShowAllTransactions();
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                        break;
                    case 7:
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                        accountRepository.ShowMostRemainMoneyAccount();
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                        break;
                    case 8:
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                        customerRepository.ShowRemainMoneyOrderByAsc();
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                        break;
                    case 9:
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                        accountRepository.ShowCustomerHasHighestTransaction();
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                        break;
                    case 0:
                        break;
                }
            }while(choice!=0);
            Console.WriteLine("Bye....");
        }
    }
}