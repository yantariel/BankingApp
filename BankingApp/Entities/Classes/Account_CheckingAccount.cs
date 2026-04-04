using BankingApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Classes
{
    internal class Account_CheckingAccount : Account //обычный дебетовый счет
    {
        public ObservableCollection<Card> Cards { get; private set; }
        public Account_CheckingAccount(float accountBalance, string accountOwnerName, string accountNumber,
            AccountType accountType, DateTime openDate)
            : base(accountBalance, accountOwnerName, accountNumber, AccountType.Checking)
        {
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
    }
}
