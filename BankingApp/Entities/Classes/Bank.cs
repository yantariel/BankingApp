using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Etities.Classes
{
    public class Bank
    {

        public bool HasEnoughMoney(float amount)
        {
            return AccountBalance >= amount;
        }
    }
}
