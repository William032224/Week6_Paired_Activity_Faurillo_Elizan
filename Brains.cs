using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Faurillo_W5_OOP
{
    internal class Brains
    {
        public static List<(string CardNumber, string Pin, string FullName, decimal Balance)> cardHolders;

        public static List<(string Water, string Electricity, string Loans)> bills;

        public static void InitializeBills()
        {
            bills = new List<(string, string, string)>
            {
                ("Water", "Electricity", "Loans")
            };
        }
        public static void InitializeCardHolders()
        {
            cardHolders = new List<(string, string, string, decimal)>
                {
                    ("1", "1", "John Doe", 1000.00m),
                    ("2345678901234567", "2345", "Jane Smith", 2000.50m),
                    ("3456789012345678", "3456", "Alice Johnson", 1500.75m),
                    ("4567890123456789", "4567", "Bob Brown", 3000.00m),
                    ("5678901234567890", "5678", "Eve White", 500.25m)
                };
        }
        public static string currentCardNumber = string.Empty;
        // Method to check and display the balance for the logged-in user
        public static void CheckBalance()
        {
            foreach (var cardHolder in cardHolders)
            {
                if (cardHolder.CardNumber == currentCardNumber)
                {
                    Console.WriteLine($"Your current balance is: Php {cardHolder.Balance}");
                    break;
                }
            }
        }

        // Dictionary to hold transactions history for each cardholder
        static Dictionary<string, List<string>> transactionHistory;
        // Method to deposit cash into the logged-in user's account
        public static void DepositCash()
        {
            Console.WriteLine("Enter the amount to deposit:");
            decimal depositAmount;
            if (decimal.TryParse(Console.ReadLine(), out depositAmount) && depositAmount > 0)
            {
                for (int i = 0; i < cardHolders.Count; i++)
                {
                    if (cardHolders[i].CardNumber == currentCardNumber)
                    {
                        cardHolders[i] = (cardHolders[i].CardNumber, cardHolders[i].Pin, cardHolders[i].FullName, cardHolders[i].Balance + depositAmount);
                        Console.WriteLine($"Successfully deposited: Php {depositAmount}");
                        Console.WriteLine($"Your new balance is: Php {cardHolders[i].Balance}");

                        // Record the deposit transaction
                        transactionHistory[currentCardNumber].Add($"Deposited: Php {depositAmount}");
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid amount. Please enter a positive number.");
            }
        }
        // Method to withdraw cash from the logged-in user's account
        public static void WithdrawCash()
        {
            Console.WriteLine("Enter the amount to withdraw:");
            decimal withdrawAmount;
            decimal transactionFee = 12.25m;
            if (decimal.TryParse(Console.ReadLine(), out withdrawAmount) && withdrawAmount > 0)
            {
                Console.WriteLine("Are you willing to pay a transaction fee of Php 12.25? [Y][N]");
                string user_input = Console.ReadLine().ToLower();

                if (user_input == "y")
                {
                    for (int i = 0; i < cardHolders.Count; i++)
                    {
                        if (cardHolders[i].CardNumber == currentCardNumber)
                        {
                            if (cardHolders[i].Balance - withdrawAmount >= 100.00m)
                            {
                                if (cardHolders[i].Balance >= withdrawAmount)
                                {
                                    cardHolders[i] = (cardHolders[i].CardNumber, cardHolders[i].Pin, cardHolders[i].FullName, cardHolders[i].Balance - withdrawAmount - transactionFee);
                                    Console.WriteLine($"Successfully withdrew: Php {withdrawAmount}");
                                    Console.WriteLine($"Your new balance is: Php {cardHolders[i].Balance}");

                                    // Record the withdrawal transaction
                                    transactionHistory[currentCardNumber].Add($"Withdrew: Php {withdrawAmount}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Balance cannot go lower than Php 100.00. Please enter a smaller amount.");
                            }
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Returning to main menu...");
                }
            }
            else
            {
                Console.WriteLine("Invalid amount. Please enter a positive number.");
            }
        }
        // Method to show the transaction history for the logged-in user
        public static void ShowTransactions()
        {
            if (transactionHistory.ContainsKey(currentCardNumber))
            {
                Console.WriteLine("Transaction History:");
                foreach (var transaction in transactionHistory[currentCardNumber])
                {
                    Console.WriteLine(transaction);
                }
            }
            else
            {
                Console.WriteLine("No transactions found.");
            }
        }
        public static void InitializeTransactionHistory()

        {

            transactionHistory = new Dictionary<string, List<string>>();

            foreach (var cardHolder in cardHolders)

            {
                transactionHistory[cardHolder.CardNumber] = new List<string>();
            }
        }
        public static void BillPayment()
        {
            Console.WriteLine("Enter the amount to be deducted:");
            decimal billPayment;
            if (decimal.TryParse(Console.ReadLine(), out billPayment) && billPayment > 0)
            {
                for (int i = 0; i < cardHolders.Count; i++)
                {
                    if (cardHolders[i].CardNumber == currentCardNumber)
                    {
                        if (cardHolders[i].Balance - billPayment >= 100.00m)
                        {
                            if (cardHolders[i].Balance >= billPayment)
                            {
                                cardHolders[i] = (cardHolders[i].CardNumber, cardHolders[i].Pin, cardHolders[i].FullName, cardHolders[i].Balance - billPayment);
                                Console.WriteLine($"Successfully deducted: Php {billPayment}");
                                Console.WriteLine($"Your new balance is: Php {cardHolders[i].Balance}");

                                // Record the withdrawal transaction
                                transactionHistory[currentCardNumber].Add($"Deduction of {bills[i]}: Php {billPayment}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Balance cannot go lower than Php 100.00. Please enter a smaller amount.");
                        }
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid amount. Please enter a positive number.");
            }
        }
    }
}
