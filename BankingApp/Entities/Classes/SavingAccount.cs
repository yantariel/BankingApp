using BankingApp.Classes;
using BankingApp.Interfaces;
using BankingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Entities.Classes
{
    public class SavingAccount: Account, IAccountWithPercent
    {
        public WithPercent WithPercent {  get; private set; }

        public SavingAccount(float balance, string ownerName, string accountNumber, float interestRate)
            : base(balance, ownerName, accountNumber, AccountType.Saving)
        {
            WithPercent = new WithPercent(this, interestRate);
        }

        public bool IsItTimeToApplyInterest()
        {
            TimeSpan daysPassed = DateTime.Now - WithPercent.LastInterestDate;
            return daysPassed.Days >= 30;
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
