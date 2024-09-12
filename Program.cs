namespace Faurillo_W5_OOP
{
    namespace Lastname_GP1_ATMConsoleApp_Procedural
    {
        internal class Program
        {
            public static void Main(string[] args)
            {
                Brains.InitializeCardHolders();
                Brains.InitializeTransactionHistory();
                ATM.ShowMainMenu();
                if (Logins.Login())
                {
                    ATM.ShowSecureMenu();
                }
            }
        }
    }
}
