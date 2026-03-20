using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Classes
{
    internal class CardNumberGenerator
    {
        private class PaymentSystemNumber    //числа с которых начинаются карты разных платежных систем
        {
            public const int Mir = 2;
            public const int Visa = 4;
            public const int MasterCard = 5;
            public const int UnionPay = 6;
        }

        private string GenerateCardNumber(PaymentSystemNumber paymentSystemNumber)
        {
            int firstDigit = GetFirstDigitForPaymentSystemNumber(paymentSystemNumber);

            string binNumber;  //bin - идентификационный номер банка, который выпустил карту
            binNumber = GenerateBin(firstDigit);

            string accountId = GenerateAccountID(); //непосредственно номер карты

            string cardNumberWithoutLuhnAlgorithm = binNumber + accountId;

            int digitFromLuhnAlgorithm = LuhnAlgorithm(cardNumberWithoutLuhnAlgorithm); //последняя цифра расчитывается с помощью алгоритма Луна

            return cardNumberWithoutLuhnAlgorithm + digitFromLuhnAlgorithm; //окончательный номер карты с последней цифрой с алгоритмом Луна


        }

        private string GenerateBin(int firstDigit)
        {
            Random random = new Random();

            string bin = firstDigit.ToString();
            for (int i = 0; i < 5; i++)  //первая цифра из 6 уже есть 
            {
                bin += random.Next(0, 10); //Возвращает неотрицательное случайное целое число в диапазоне 
            }
            return bin;
        }

        private string GenerateAccountID()
        {
            Random random = new Random();

            string accountID = "";
            for (int i = 0; i < 10; i++)  
            {
                accountID += random.Next(0, 10); //Возвращает неотрицательное случайное целое число в диапазоне 
            }
            return accountID;
        }

        private string LuhnAlgorithm(string cardNumberWithoutLuhnAlgorithm)  //проверяет точность идентификационных номеров
        {
            int sum = 0;

            for (int i = 0; i < cardNumberWithoutLuhnAlgorithm.Length; i++)
            {
                int digit = int.Parse(cardNumberWithoutLuhnAlgorithm[i].ToString());
                if (i % )
            }
        }

    }
}
