using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Classes
{
    //public enum AccountType
    //{
    //    Checking, //текущий, то есть стандартный, для каждодневного пользования
    //    Credit, //кредитный
    //    Saving, //накопительный, проценты капают, снимать/вносить деньги можно в любое время
    //    Deposit //депозитный или вклад (как накопительный, но нельзя снимать и вносить деньги просто так)
    //}

    //public class OperationResult
    //{
    //    public bool Success { get; set; }
    //    public string Message { get; set; }
    //}

    public abstract class Account : IAccount
    {


        //public string CardBalanceView => $"{AccountBalance.ToString("N2")} ₽";
        public float AccountBalance { get; set; }
        public string AccountOwnerName { get; private set; }    //имя владельца
        public string AccountNumber { get; private set; }
        public AccountType AccountType { get; private set; } //вид счета - кредитный, накопительный и тд
        public DateTime OpenDate { get; private set; } //дата открытия счета

        public Account(float accountBalance, string accountOwnerName, string accountNumber, AccountType accountType)
        {
            AccountBalance = accountBalance;
            AccountOwnerName = accountOwnerName;
            AccountNumber = accountNumber;
            AccountType = accountType;
            OpenDate = DateTime.Now;
            Cards = new ObservableCollection<Card>();
        }




        //public ObservableCollection<Card> GetAllCards()
        //{
        //    return Cards;
        //}

        //public void UpdateCardBalance(float newBalance)
        //{
        //    //проверки
        //    AccountBalance = newBalance;
        //}

        //public void UpdateSavingBalance(float newBalance)
        //{
        //    //проверки
        //    SavingBalance = newBalance;
        //}

        public bool HasEnoughMoney(float amount)
        {
            return AccountBalance >= amount;
        }

        //Те методы и свойства, которые мы хотим сделать доступными для переопределения, в базовом классе помечается модификатором virtual.
        public virtual OperationResult Withdraw(float amount)  //снятие/перевод денег на счет
        {
            OperationResult result = new OperationResult();

            if (amount < 0)
            {
                result.Success = false;
                result.Message = "Сумма перевода не может быть отрицательной";
                return result;
            }

            if (!HasEnoughMoney(amount))
            {
                result.Success = false;
                result.Message = "Недостаточно средств на счете";
                return result;
            }

            AccountBalance -= amount;
            result.Success = true;
            result.Message = $"Успешно переведено {amount}₽";
            return result;
        }

        public virtual OperationResult Deposit(float amount)  //добавка на счет денег
        {
            OperationResult result = new OperationResult();

            if (amount < 0)
            {
                result.Success = false;
                result.Message = "Сумма пополнения не может быть отрицательной";
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

    }
}
