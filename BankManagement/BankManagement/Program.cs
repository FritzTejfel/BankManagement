using BankManagement.AccountManagement;
using BankManagement.Models;
using BankManagement.Services;
using BankManagement.UserInterface;
using System;
using System.Collections.Generic;

namespace BankManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            UI ui = new UI();

            ui.Enter();

            Console.ReadKey();
        }
    }
}
