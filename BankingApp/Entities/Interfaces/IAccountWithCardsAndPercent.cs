using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Interfaces
{
    internal interface IAccountWithCardsAndPercent: IWithCards, IWithPercent  //это интерфейс по сути для CreditAccount
    {

    }
}
