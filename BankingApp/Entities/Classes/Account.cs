using BankingApp.Etities.Interfaces;
using BankingApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Etities.Classes
{
    public abstract class Account : IAccount
    {
        public float AccountBalance { get; set; }
        public string AccountOwnerName { get; private set; }
        public string AccountNumber { get; private set; }
        public AccountType AccountType { get; private set; }
        public DateTime OpenDate { get; private set; }

        
        public Account(float accountBalance, string accountOwnerName, string accountNumber, AccountType accountType)
        {
            AccountBalance = accountBalance;
            AccountOwnerName = accountOwnerName;
            AccountNumber = accountNumber;
            AccountType = accountType;
            OpenDate = DateTime.Now;
            //Cards = new ObservableCollection<Card>();    //в AccountWithCards
        }

        //Те методы и свойства, которые мы хотим сделать доступными для переопределения, в базовом классе помечается модификатором virtual.
        public virtual OperationResult Withdraw(float amount)  //снятие/перевод денег на счет
        {
            OperationResult result = new OperationResult();

            if (amount <= 0)
            {
                result.Success = false;
                result.Message = "Сумма перевода должна быть положительной";
                return result;
            }

            //if (!HasEnoughMoney(amount))    //это в Bank
            //{
            //    result.Success = false;
            //    result.Message = "Недостаточно средств на счете";
            //    return result;
            //}

            AccountBalance -= amount;
            result.Success = true;
            result.Message = $"Успешно переведено {amount}₽";
            return result;
        }

        public virtual OperationResult Deposit(float amount)  //добавка на счет денег
        {
            OperationResult result = new OperationResult();

            if (amount <= 0)
            {
                result.Success = false;
                result.Message = "Сумма пополнения должна быть положительной";
                return result;
            }

            AccountBalance += amount;
            result.Success = true;
            result.Message = $"Успешно пополнено на {amount}₽";
            return result;
        }

        public float GetAccountBalance()
        {
            return AccountBalance;
        }

        //    public bool HasEnoughMoney(float amount)    //это в Bank
        //    {
        //        return AccountBalance >= amount;
        //    }




        //    //public ObservableCollection<Card> GetAllCards()    
        //    //{
        //    //    return Cards;
        //    //}

        //    //public void UpdateCardBalance(float newBalance)
        //    //{
        //    //    //проверки
        //    //    AccountBalance = newBalance;
        //    //}

        //    //public void UpdateSavingBalance(float newBalance)
        //    //{
        //    //    //проверки
        //    //    SavingBalance = newBalance;
        //    //}
    }

}

