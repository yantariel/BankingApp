using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BankingApp.Classes
{
    public class TransferManagement
    {
        private Account _accountManagement;
        private TransactionHistory _transactionHistory;

        public TransferManagement(Account accountManagement, TransactionHistory transactionHistory) //конструктор
        {
            _accountManagement = accountManagement;
            _transactionHistory = transactionHistory;
        }

        public bool IsPhoneCorrect(string textPhoneNumber)
        {
            if (textPhoneNumber == null)
            {
                return false;
            }
            {
                if (textPhoneNumber.StartsWith("+7") == false)
                {
                    return false;
                }

                string numberWithoutPlus = textPhoneNumber.Remove(0, 1); //убираем +

                if (long.TryParse(numberWithoutPlus, out long phoneNumber)) 
                {
                    if (numberWithoutPlus.Length == 11)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }

        public bool IsCardCorrect(string textCardNumber)
        {
            if (textCardNumber == null)
            {
                return false;
            }
            else
            {
                if (int.TryParse(textCardNumber, out int cardNumber))
                {
                    if (textCardNumber.Length == 16)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }

        public TransferResult ProcessTransfer(string recipient, float amount, TransferType type)
        {

            TransferResult result = new TransferResult();

            if (amount <= 0)
            {
                result.Success = false;
                result.Message = "Нельзя перевести отрицательную сумму";
                return result;
            }

            if (_accountManagement.HasEnoughMoney(amount) == false)
            {
                result.Success = false;
                result.Message = "Недостаточно средств на карте";
                return result;
            }

            bool isValidRecipient = false; 

            if (type == TransferType.Phone) //правильный ли телефон/карта
            {
                isValidRecipient = IsPhoneCorrect(recipient);
            }
            else
            {
                isValidRecipient = IsCardCorrect(recipient);
            }

            if (isValidRecipient == false)
            {
                result.Success = false;

                if (type == TransferType.Phone)
                {
                    result.Message = "Введите корректный номер телефона (вводите без пробелов, начинайте с +7..)";
                }
                else
                {
                    result.Message = "Введите корректный номер карты (вводите без пробелов)";
                }

                return result;
            }

            _accountManagement.Withdraw(amount);

            string transactionType = "";
            if (type == TransferType.Phone)
            {
                transactionType = "Перевод по телефону";
            }
            else
            {
                transactionType = "Перевод по карте";
            }

            Transaction transaction = new Transaction(transactionType, amount, recipient, _accountManagement.CardBalance);

            _transactionHistory.AddTransaction(transaction);

            result.Success = true;
            result.Message = $"Успешно переведено {amount} ₽";
            result.NewBalance = _accountManagement.CardBalance;
            result.Transaction = transaction;

            return result;
        }
    }   

    public enum TransferType
    {
        Phone,
        Card
    }

    public class TransferResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public float NewBalance { get; set; }
        public Transaction Transaction { get; set; }
    }


}

