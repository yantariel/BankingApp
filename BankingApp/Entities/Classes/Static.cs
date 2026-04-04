using BankingApp.Classes;
using System;

namespace BankingApp.Classes
{
    internal static class Static
    {
        public static Account CurrentAccount;

        public static void Initialize()
        {
            CurrentAccount = new Account(50000.50f, "Yana Gudkova", GenerateAccountNumber(AccountType.Checking), AccountType.Checking);
        }

        private static string GenerateAccountNumber(AccountType accountType)
        {
            Random random = new Random();
            string accountCode = GetAccountCodeByType(accountType);
            return accountCode + random.Next(100000000, 999999999).ToString(); //20 цифр, первые 5 отражают тип счета
        }

        private static string GetAccountCodeByType(AccountType accountType)
        {
            switch (accountType)
            {
                case AccountType.Checking:
                    return "40817";           //код обычного счета

                case AccountType.Credit:
                    return "45506";           //код кредитного счета

                case AccountType.Saving:
                    return "42303";           //код накопительного счета

                case AccountType.Deposit:
                    return "42301";           //код депозитного счета

                default:
                    return "40817";           //по умолчанию //код обычного счета
            }
        }

    }
}
