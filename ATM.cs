using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faurillo_W5_OOP
{
    internal class ATM
    {
        
        public static void ShowMainMenu()
        {
            Console.WriteLine("*--------------------------*");
            Console.WriteLine("| Lastname ATM Main Menu   |");
            Console.WriteLine("|                          |");
            Console.WriteLine("| 1. Insert ATM Card       |");
            Console.WriteLine("| 2. Exit                  |");
            Console.WriteLine("|                          |");
            Console.WriteLine("*--------------------------*");
        }
        // Variable to hold the currently logged-in user's card number
        public static void ShowSecureMenu()
        {
            bool isLoggedIn = true;

            while (isLoggedIn)
            {
                Console.WriteLine("*--------------------------*");
                Console.WriteLine("| Lastname ATM Secure Menu |");
                Console.WriteLine("|                          |");
                Console.WriteLine("| 1. Balance Enquiry       |");
                Console.WriteLine("| 2. Cash Deposit          |");
                Console.WriteLine("| 3. Withdrawal            |");
                Console.WriteLine("| 4. Transactions          |");
                Console.WriteLine("| 5. Bills Payment         |");
                Console.WriteLine("| 6. Logout                |");
                Console.WriteLine("|                          |");
                Console.WriteLine("*--------------------------*");

                string secureMenuChoice = Console.ReadLine();

                switch (secureMenuChoice)
                {
                    case "1":
                        Brains.CheckBalance();  // Call method to check balance
                        break;
                    case "2":
                        Brains.DepositCash();
                        break;
                    case "3":
                        Brains.WithdrawCash();
                        break;
                    case "4":
                        Brains.ShowTransactions();
                        break;
                    case "5":
                        BillMenu();
                        break;
                    case "6":
                        isLoggedIn = false;
                        Console.WriteLine("Logging out...");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
        public static void BillMenu()
        {
            Console.WriteLine("*--------------------------*");
            Console.WriteLine("|          BILLS           |");
            Console.WriteLine("| [1] Water                |");
            Console.WriteLine("| [2] Electricity          |");
            Console.WriteLine("| [3] Loans                |");
            Console.WriteLine("|                          |");
            Console.WriteLine("*--------------------------*");

            string user_input = Console.ReadLine();

            switch (user_input)
            {
                case "1":                    
                    Brains.BillPayment();
                    break;
                case "2":                    
                    Brains.BillPayment();
                    break;
                case "3":
                    Brains.BillPayment();
                    break;
            }
        }
    }
}
