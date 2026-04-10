using BankingApp.Classes;
using BankingApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Interfaces
{
    public interface IWithCards
    {
        //ObservableCollection<Card> Cards { get; }  это наверное отдельно в Debit и Credit?

        ObservableCollection<Card> GetCards();
        OperationResult AddCard(Card card);
        OperationResult RemoveCard(Card card);
    }
}
