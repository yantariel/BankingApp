using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Etities.Classes
{
    public class Transaction
    { 
        public string Type { get; set; }        //по телефону или по карте  
        public float Amount { get; set; }        
        public string Recipient { get; set; }    
        public string MessageToRecipient { get; set; }    
        public float BalanceAfter { get; set; }  

        public Transaction(string type, float amount, string recipient, float balanceAfter) //конструктор
        {
            Type = type;                  
            Amount = amount;               
            Recipient = recipient;            
            BalanceAfter = balanceAfter;    
        }

        // Возвращает отформатированную сумму в виде строки
        public string GetFormattedAmount()
        {
            // N2 - формат числа с 2 знаками после запятой
            // $"-{Amount:N2} ₽" - подставляем сумму в строку
            // Пример: -500.00 ₽
            return $"-{Amount:N2} ₽";
        }
    }
}
