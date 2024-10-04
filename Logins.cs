using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faurillo_W5_OOP
{
    internal class Logins
    {
        public static bool Login()
        {
            bool loggedIn = false;

            string mainMenuChoice = Console.ReadLine();
            switch (mainMenuChoice)
            {
                case "1":
                    int attempts = 0;
                    loggedIn = false;

                    while (attempts < 3 && !loggedIn)
                    {
                        Console.WriteLine("Please enter your card number:");
                        string cardNumber = Console.ReadLine();
                        Console.WriteLine("Please enter your PIN:");
                        string pin = Console.ReadLine();

                        if (ValidateCredentials(cardNumber, pin))
                        {
                            loggedIn = true;
                            Brains.currentCardNumber = cardNumber;
                            Console.WriteLine("Login successful.");
                        }
                        else
                        {
                            attempts++;
                            Console.WriteLine($"Invalid card number or PIN. You have {3 - attempts} left. Please try again.");
                        }
                    }
                    if (!loggedIn)
                    {
                        Console.WriteLine("Too many attempts. Logging out...");
                    }
                    break;

                case "2":
                    loggedIn = false;
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            return loggedIn;
        }
        public static bool ValidateCredentials(string cardNumber, string pin)
        {
            foreach (var cardHolder in Brains.cardHolders)
            {
                if (cardHolder.CardNumber == cardNumber && cardHolder.Pin == pin)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
