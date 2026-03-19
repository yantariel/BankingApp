using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Classes
{
    public class Account
    {
        public ObservableCollection<Card> Cards { get; set; }
        

        // создать класс Card
        // public ObservableCollection<Card> Cards { get; set; }

        public string CardBalanceView => $"{CardBalance.ToString("N2")} ₽";
        public string SavingBalanceView => $"{SavingBalance.ToString("N2")} ₽";
        public float CardBalance { get; private set; }
        public string CardHolderName { get; set; }    //имя владельца
        public float SavingBalance { get; private set; }
        public string CardNumber { get; private set; }
        public string CardType { get; private set; }  //дебетовая, кредитная и тд
        public float InterestRate { get; private set; }
        public DateTime OpenDate { get; set; } //дата открытия счета

        public Account(float cardBalance = 50000.50f)
        {
            Cards = new ObservableCollection<Card>();
            CardNumber = GenerateCardNumber(); //номер карты генерируется случайно  
            CardBalance = cardBalance;
            SavingBalance = 0f;
            CardType = "Дебетовая";
            OpenDate = DateTime.Now;
            InterestRate = 0f;
            CardHolderName = "Яна Гудкова";
        }

        public void AddCard(Card card) //добавляем карту в коллекцию )
        {
            Cards.Add( card );
        }

        public void RemoveCard(Card card) //удаляем карту
        {
            Cards.Remove( card );
        }

        //public ObservableCollection<Card> GetAllCards()
        //{
        //    return Cards;
        //}

        public void UpdateCardBalance(float newBalance)
        {
            //проверки
            CardBalance = newBalance;
        }

        public void UpdateSavingBalance(float newBalance)
        {
            //проверки
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

        public void Withdraw(float amount)
        {
            if (HasEnoughMoney(amount))
            {
                CardBalance -= amount;
            }
        }

        public void Deposit(float amount)
        {
            CardBalance += amount;
        }

        public float GetSavingBalance()
        {
            return SavingBalance;
        }

        private string GenerateCardNumber() //генерирует случайный номер карты
        {
            Random randomCardNumber = new Random();

            return $"{randomCardNumber.Next(10000, 99999)} {randomCardNumber.Next(10000, 99999)} {randomCardNumber.Next(10000, 99999)} {randomCardNumber.Next(10000, 99999)}";
        }
    }
}

