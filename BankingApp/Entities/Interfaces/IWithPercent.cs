using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Interfaces
{
    public interface IWithPercent
    {
        void Сapitalization(float accruedInterest); //начисление насчитанных (в банке) ежедневных процентов на баланс в конце месяца
        //bool IsItTimeToApplyInterest();  
        bool IsBalanceOnCreditCardNegative();  //если баланс негативный, то на кредитку начислятся проценты
    }
}
