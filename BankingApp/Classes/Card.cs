using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Classes
{
    public class Card
    {
        public string CardNumber { get; set; }     //номер карты
        public string ExpiryDate { get; set; }     //срок действия (MM/YY)
        public string PaymentSystem { get; set; }  //платежная система (VISA, Mastercard)
        public float CardBalance { get; set; }     //баланс
        public DateTime ReleaseDate { get; set; }  //дата выпуска
        public string CVV { get; set; }            //cvv код
        public Account Account { get; set; }

        public Card(string cardNumber, string expiryDate, string paymentSystem, float balance)
        {
            CardNumber = cardNumber;
            ExpiryDate = expiryDate;
            PaymentSystem = paymentSystem;
            CardBalance = balance;
            ReleaseDate = DateTime.Now;  //время компьютера
            CVV = "***";                 //cvv по умолчанию скрыто звездочками
        }


        public string GetMaskedCardNumber() //чтобы показывались только последние 4 циферки
        {
            if (string.IsNullOrEmpty(CardNumber) || CardNumber.Length < 16)
                return "**** **** **** ****";

            string last4 = CardNumber.Substring(12, 4);  //Substring вырезает часть строки с 12 символа, берет 4
            return $"**** **** **** {last4}";
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
