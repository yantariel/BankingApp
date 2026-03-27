using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Interfaces
{
    internal interface IWithPercent
    {
        void Сapitalization(); //начисление насчитанных (в банке) ежедневных процентов на баланс в конце месяца

        bool IsItTimeToApplyInterest();
        bool IsBalanceOnCreditCardNegative();
        bool IsBalanceOnCreditCardPositive();
    }
}
