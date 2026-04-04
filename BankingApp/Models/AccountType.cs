using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Models
{
    public enum AccountType
    {
        Checking, //текущий, то есть стандартный, для каждодневного пользования
        Credit, //кредитный
        Saving, //накопительный, проценты капают, снимать/вносить деньги можно в любое время
        Deposit //депозитный или вклад (как накопительный, но нельзя снимать и вносить деньги просто так)
    }
}
