using BankingApp.Etities.Classes;
using BankingApp.Etities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Entities.Classes
{
    //начисляет проценты на баланс, рассчитываться и устанавливаться будут в классе Bank
    public class WithPercent: IWithPercent  //его наверное нужно сделать абстрактным?
    {
        public Account Account { get; set; }
        public DateTime LastInterestDate { get; private set; }
        public float InterestRate;

        public WithPercent(Account account, float interestRate)
        {
            Account = account;
            LastInterestDate = DateTime.Now;
            InterestRate = interestRate;
        }

        public void Сapitalization(float accruedInterest)
        {
            if (accruedInterest >= 0)
            {
                Account.AccountBalance += accruedInterest;
                LastInterestDate = DateTime.Now;
            }
        }

        public bool IsBalanceOnCreditCardNegative()
        {
            return Account.AccountBalance < 0;
        }

        //public void SetInterestRate(float rate)  //как нибудь так в Bank
        //{
        //    InterestRate = rate;
        //}
    }

}
