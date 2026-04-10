using BankingApp.Etities.Classes;
using BankingApp.Etities.Interfaces;
using BankingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Entities.Classes
{
    //накопительный счет проценты капают, снимать/вносить деньги можно в любое время
    public class SavingAccount: Account, IAccountWithPercent
    {
        public WithPercent WithPercent {  get; private set; }

        public SavingAccount(float balance, string ownerName, string accountNumber, float interestRate)
            : base(balance, ownerName, accountNumber, AccountType.Saving)
        {
            WithPercent = new WithPercent(this, interestRate);
        }


        //В отличие от банковских вкладов, где проценты могут начисляться раз в месяц или только в конце срока, 
        //по накопительным счетам проценты обычно начисляются ежедневно. Банк рассчитывает процент на фактический остаток 
        //средств за день, а затем в определённую дату (чаще всего в конце месяца) переводит сумму на счёт клиента.
        public bool IsItTimeToApplyInterest()
        {
            TimeSpan daysPassed = DateTime.Now - WithPercent.LastInterestDate;
            return daysPassed.Days >= 30;  //на будущее поменять 30 на число, которое выберет пользователь в доступных вкладах
            //или число дней в текущем месяце если оставлю начсиление в конце месяца
        }

        public void Сapitalization(float accruedInterest)
        {
            if (IsItTimeToApplyInterest())
                WithPercent.Сapitalization(accruedInterest);
        }

        public bool IsBalanceOnCreditCardNegative()
        {
            return WithPercent.IsBalanceOnCreditCardNegative();
        }
    }
}
