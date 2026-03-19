using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Classes
{
    public class Card
    {
        // Основные свойства карты
        public string CardNumber { get; set; }        //номер карты
        public string ExpiryDate { get; set; }     //срок действия (MM/YY)
        public string CardType { get; set; }        //тип карты (дебетовая, накопительный счет)
        public string PaymentSystem { get; set; }      //платежная система (VISA, Mastercard)
        public float Balance { get; set; }            //баланс
        public DateTime ReleaseDate { get; set; }       //дата выпуска
        public string CVV { get; set; }                //cvv код
        public string Color { get; set; }             //цвет карты 

        public Card()  
        {
            CardNumber = "0000 0000 0000 0000";
            ExpiryDate = "00/00";
            CardType = "Дебетовая";  
            PaymentSystem = "VISA";
            Balance = 0f;
            ReleaseDate = DateTime.Now;  //время компьютера
            CVV = "***";
            Color = "LightPink";
        }

        public Card(string cardNumber, string cardHolderName, string expiryDate,
                    string cardType, string paymentSystem, float balance)
        {
            CardNumber = cardNumber;
            CardHolderName = cardHolderName;
            ExpiryDate = expiryDate;
            CardType = cardType;
            PaymentSystem = paymentSystem;
            Balance = balance;
            ReleaseDate = DateTime.Now;
            CVV = "***";
            Color = "LightPink";
        }


        public string GetMaskedCardNumber() //чтобы показывались только последние 4 цифорки
        {
            if (string.IsNullOrEmpty(CardNumber) || CardNumber.Length < 16)
                return "**** **** **** ****";

            string last4 = CardNumber.Substring(12, 4);  //Substring вырезает часть строки с 12 символа, берет 4
            return $"**** **** **** {last4}";
        }

        public bool HasEnoughMoney(float amount)  //проверка достаточно ли денег на карте
        {
            return Balance >= amount;
        }

        public bool Withdraw(float amount) //снятие денег 
        {
            if (HasEnoughMoney(amount))
            {
                Balance -= amount;
                return true;
            }
            return false;
        }

        public void Deposit(float amount) //пополнение карты
        {
            Balance += amount;
        }


        public bool IsExpired() //проверка срока действия карты
        {
            if (string.IsNullOrEmpty(ExpiryDate) || ExpiryDate.Length < 5) //ММ/ГГ
                return true;

            string[] parts = ExpiryDate.Split('/'); //дата вводится строкой, делит ее слэшами

            if (parts.Length != 2) //нормально поделилось на две части - ММ и ГГ
                return true;

            bool monthTryParsed = int.TryParse(parts[0], out int month);
            if (monthTryParsed == false)
                return true;

            bool yearTryParsed = int.TryParse(parts[1], out int yearShort);
            if (yearTryParsed == false)
                return true;

            if (month < 1 || month > 12) //адекватный ли месяц
                return true;

            if (yearShort < 0 || yearShort > 99) //адекватный ли год
                return true;

            int year = 2000 + yearShort; //на компьютере год не 26 а 2026

            DateTime expiryDate = new DateTime(year, month, 1).AddMonths(1).AddDays(-1); //последний день карты
            return expiryDate < DateTime.Now; //сравниваем с сегодня
        }

    }
}
