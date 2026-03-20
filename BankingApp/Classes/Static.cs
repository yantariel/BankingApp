using BankingApp.Classes;

namespace BankingApp.Classes
{
    internal static class Static
    {
        public static Account CurrentAccount;

        public static void Initialize()
        {
            CurrentAccount = new Account(50000.50f, "Yana Gudkova", "", AccountType.Checking);
        }
    }
}
