using BankingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Classes
{
    public class CardNumberGenerator  //в Bank
    {

        public string GenerateCardNumber(PaymentSystem paymentSystem)
        {
            int firstDigit = GetFirstDigitForPaymentSystem(paymentSystem); //карты разных платежных систем начинаются с разных цифр

            string binNumber = GenerateBin(firstDigit); //bin - идентификационный номер банка, который выпустил карту (6 цифр)

            string accountId = GenerateAccountID(); //непосредственно номер карты (9 цифр_

            string cardNumberWithoutLuhnAlgorithm = binNumber + accountId; //получаем 15 цифр без последней

            int digitFromLuhnAlgorithm = LuhnAlgorithm(cardNumberWithoutLuhnAlgorithm); //последняя цифра расчитывается с помощью алгоритма Луна

            return cardNumberWithoutLuhnAlgorithm + digitFromLuhnAlgorithm.ToString(); //окончательный номер карты с последней цифрой с алгоритмом Луна
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
            for (int i = 0; i < 9; i++)  
            {
                accountID += random.Next(0, 10); //Возвращает неотрицательное случайное целое число в диапазоне 
            }
            return accountID;
        }

        private int GetFirstDigitForPaymentSystem(PaymentSystem paymentSystem)
        {
            switch (paymentSystem)
            {
                case PaymentSystem.Visa:
                    return 4; 

                case PaymentSystem.MasterCard:
                    return 5;  

                case PaymentSystem.Mir:
                    return 2; 

                default:
                    return 2;  //по умолчанию Mir
            }
        }

        private int LuhnAlgorithm(string cardNumberWithoutLuhnAlgorithm)  //проверяет точность идентификационных номеров
        {
            int sum = 0;
            int length = cardNumberWithoutLuhnAlgorithm.Length;
            bool shouldDouble = false;  //в алгоритме нужно удваивать каждую вторую цифру идя справа налево
            //если идти справа налево получим, что первая цифра (под индексом 14 при нумерации слева направо) 
            //не должна умножаться на 2, тк она на нечетном месте
            //(по алгоритму умножается на два каждая цифра на четном месте справа налево)

            for (int i = length - 1; i >= 0 ; i--) //цикл от последнего индекса (14 если нумеровать слева направо с 0)
            {
                int digit = int.Parse(cardNumberWithoutLuhnAlgorithm[i].ToString());

                if (shouldDouble) //если цифра на четном месте, умножаем на 2 согласно алгоритму (то есть на нечетном индексе)
                {
                    digit *= 2;
                    if (digit > 9)
                    {
                        digit = digit - 9;
                    }
                }

                sum += digit; 
                shouldDouble = !shouldDouble;  //переключаем флаг, так как теперь цифра - на четном месте справа налево
            }

            int flag = sum % 10; 
            //нужно, чтобы сумма всех цифр (с новой найденной) заканчивалась на 0
            int digitFromLuhnAlgorithm = 0; //если у нас сумма уже кратна 10, 
            if (flag != 0)
            {
                digitFromLuhnAlgorithm = (10 - (flag % 10)); //то есть sum % 10 ищет последнюю цифру суммы, 10 - (sum % 10) дает
                                                             //недостающую 16 цифру банковского номера (чтобы сумма 16 цифр была кратна 10)
            }
            return digitFromLuhnAlgorithm;
        }
    }
}
