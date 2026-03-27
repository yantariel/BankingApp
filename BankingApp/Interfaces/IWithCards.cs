using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Classes
{
    interface IWithCards
    {
        ObservableCollection<Card> GetCards();

        OperationResult AddCard(Card card);
        OperationResult RemoveCard(Card card); 
    }
}
