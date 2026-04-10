using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Classes
{
    public class AccountManagement
    {
        public float CardBalance { get;  set; } //баланс на карте (дебетовой)
        public float SavingBalance { get;  set; } //баланс накопительного счета
        public string CardNumber { get; private set; }
        public string CardType { get; private set; }

        public AccountManagement()
        {
            CardBalance = 20000.50f;
            SavingBalance = 15000f;
            CardNumber = "2048";
            CardType = "VISA";
        }

        public void UpdateCardBalance(float newBalance)
        {
            CardBalance = newBalance;
        }

        public void UpdateSavingBalance(float newBalance)
        {
            SavingBalance = newBalance;
        }

        public bool HasEnoughMoney(float amount) 
        {
            if (CardBalance >= amount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Withdraw(float amount)  //уменьшить деньги //добавить try и возможно через бул получилось или нет 
        {
            if (HasEnoughMoney(amount))
            {
                CardBalance -= amount;
            }
        }

        public void Deposit(float amount) //добавить деньги
        {
            CardBalance += amount;
        }

        public float GetSavingBalance()
        {
            return SavingBalance;
        }
    }
}

