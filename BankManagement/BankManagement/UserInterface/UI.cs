using BankManagement.AccountManagement;
using System;
using BankManagement.Services;
using System.Collections.Generic;
using System.Text;

namespace BankManagement.UserInterface
{
    public class UI
    {
        private static string Firstname = null;
        private static int Code = 0;
        private DataUpload connection = new DataUpload();
        private DataRequestCustomer customerRequest = new DataRequestCustomer();
        private DataRequestBankAccount accountRequest = new DataRequestBankAccount();
        private LoginCheck check = new LoginCheck();
        private MoneyManagement money = new MoneyManagement();
        private const string ADMIN_PASSWORD = "admin";

        public void Enter()
        {
            Console.WriteLine("----Login-------");

            Console.Write("Firstname:\t");
            Firstname = Console.ReadLine();

            Console.Write("Code:\t");
            Code = int.Parse(Console.ReadLine());

            Console.WriteLine("----------------");

            if (check.CustomerCheck(Firstname, Code))
            {
                Menu();                
            }

            else
            {
                FailLogin();
            }
        }

        private void Menu()
        {
            Console.WriteLine("---Menu----");

            Console.WriteLine("\nBalance:\t{0}\n", accountRequest.GetBalance(Code));

            Console.WriteLine("1 - Inlay Money");
            Console.WriteLine("2 - Take out Money");
            Console.WriteLine("3 - Login as Admin");
            Console.WriteLine("4 - Exit");

            Console.WriteLine("Choose one number!:\t");

            int number = int.Parse(Console.ReadLine());

            Options(number);
            
        }

        private void FailLogin()
        {
            Console.WriteLine("No matching account");
            Console.ReadKey();
        }

        private void Options(int number)
        {
            switch (number)
            {
                case 1: {
                        Inlay();
                    } break;
                case 2: {
                        TakeOut();
                    } break;
                case 3: {
                        Admin();
                    } break;
                case 4: {

                    } break;
                default: {
                        Console.WriteLine("No other options!");
                    } break;
            }

        }

        private void Inlay()
        {
            Console.WriteLine("Balance:\t{0}", accountRequest.GetBalance(Code));
            Console.Write("Amount:\t");
            double amount = double.Parse(Console.ReadLine());
            money.Inlay(Code, amount);
            Console.WriteLine("Balance:\t{0}", accountRequest.GetBalance(Code));
            Console.ReadLine();
            Menu();

        }

        private void TakeOut()
        {
            Console.WriteLine("Balance:\t{0}", accountRequest.GetBalance(Code));
            Console.Write("Amount:\t");
            double amount = double.Parse(Console.ReadLine());
            money.Takeout(Code, amount);
            Console.WriteLine("Balance:\t{0}", accountRequest.GetBalance(Code));
            Console.ReadLine();
            Menu();
        }

        private void Admin()
        {
            Console.WriteLine("Password:\t");
            string pass = Console.ReadLine();

            if (pass.Equals(ADMIN_PASSWORD))
            {
                AdminMenu();
            }
            else
            {
                Console.WriteLine("Access denied!");
                Console.ReadLine();
            }
            Menu();
        }

        private void Exit()
        {
            Console.WriteLine("Good bye!");
            Console.ReadKey();
        }

        private void AdminMenu()
        {
            Console.WriteLine("Admin menu");
            //in progress
            Console.ReadLine();
        }
    }
}
