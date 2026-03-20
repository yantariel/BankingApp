using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Classes
{
    interface IWithCards
    {
        OperationResult AddCard(Card card);

        OperationResult RemoveCard(Card card);
    }
}
