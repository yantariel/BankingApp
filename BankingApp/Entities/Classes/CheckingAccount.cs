using BankingApp.Classes;
using BankingApp.Interfaces;
using BankingApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Entities.Classes
{
    public class CheckingAccount: Account, IAccountWithCards
    {
        public WithCards WithCards {  get; private set; }
        public CheckingAccount(float balance, string ownerName, string accountNumber)
            : base(balance, ownerName, accountNumber, AccountType.Checking)
        {
            WithCards = new WithCards(this); //создается новый объект WithCards и ему передается текущий счет (данный CheckingAccount) 
        }

        public OperationResult AddCard(Card card)
        {
            return WithCards.AddCard(card);
        }

        public OperationResult RemoveCard(Card card)
        {
            return WithCards.RemoveCard(card);
        }

        public ObservableCollection<Card> GetCards()
        {
            return WithCards.GetCards();
        }
    }
}
