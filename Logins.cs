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
                    loggedIn = true;
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
                        Console.WriteLine("Invalid card number or PIN. Please try again.");
                        loggedIn = false;
                        Login();
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
