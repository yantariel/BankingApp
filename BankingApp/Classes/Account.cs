using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Classes
{
    public enum AccountType
    {
        Checking, //текущий, то есть стандартный, для каждодневного пользования
        Сredit, //кредитный
        Saving, //накопительный, проценты капают, снимать/вносить деньги можно в любое время
        Deposit //депозитный или вклад (как накопительный, но нельзя снимать и вносить деньги просто так)
    }

    public class OperationResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }

    public class Account
    {
        public ObservableCollection<Card> Cards { get; set; }

        public string CardBalanceView => $"{AccountBalance.ToString("N2")} ₽";
        public float AccountBalance { get; set; }
        public string AccountOwnerName { get; set; }    //имя владельца
        public string AccountNumber { get; private set; }
        public AccountType AccountType { get; private set; } //вид счета - кредитный, накопительный и тд
        public DateTime OpenDate { get; set; } //дата открытия счета

        public Account(float accountBalance, string accountOwnerName, string accountNumber, AccountType accountType)
        {
            AccountBalance = accountBalance;
            AccountOwnerName = accountOwnerName;
            AccountNumber = accountNumber;
            AccountType = accountType;
            OpenDate = DateTime.Now;
            Cards = new ObservableCollection<Card>();
        }

        public OperationResult AddCard(Card card) //привязывает карту к счету
        {
            OperationResult result = new OperationResult();

            if (card == null) 
            {
                result.Success = false;
                result.Message = "Нельзя прикрепить несуществующую карту";
                return result;
            }

            if (card.Account != null && card.Account != this) //если карта привязана к другому счету, отвязываем ее
            {
                card.Account.Cards.Remove(card);
            }

            card.Account = this;  //this это тот конкретный объект, для которого вызван метод

            if (!Cards.Contains(card)) //если карта уже не в списке
            {
                Cards.Add(card);
                result.Success = true;
                result.Message = "Карта успешно прикреплена к счету";
            }
            return result;
        }

        public OperationResult RemoveCard(Card card)  //отвязка карты от счета
        {
            OperationResult result = new OperationResult();

            if (card == null)
            {
                result.Success = false;
                result.Message = "Нельзя открепить несуществующую карту";
                return result;
            }

            if (card.Account != this)
            {
                result.Success = false;
                result.Message = "Эта карта не привязана к этому счету";
                return result;
            }

            card.Account = null;
            Cards.Remove(card);
            result.Success = true;
            result.Message = "Карта успешно откреплена от счету";
            return result;
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

        private string GenerateAccountNumber() //генерирует случайный номер аккаунта
        {
            Random randomAccountNumber = new Random();

            return $"{randomAccountNumber.Next(10000, 99999)} {randomAccountNumber.Next(10000, 99999)} {randomAccountNumber.Next(10000, 99999)} {randomAccountNumber.Next(10000, 99999)}";
        }
    }
}

