using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Classes
{
    public enum AccountType
    {
        Checking, //текущий, то есть стандартный, для каждодневного пользования
        Credit, //кредитный
        Saving, //накопительный, проценты капают, снимать/вносить деньги можно в любое время
        Deposit //депозитный или вклад (как накопительный, но нельзя снимать и вносить деньги просто так)
    }

    public class OperationResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }

    interface IAccount
    {
        ObservableCollection<Card> Cards { get; }

        //public string CardBalanceView => $"{AccountBalance.ToString("N2")} ₽";
        float AccountBalance { get; set; }
        string AccountOwnerName { get; }    //имя владельца
        string AccountNumber { get; }
        AccountType AccountType { get; } //вид счета - кредитный, накопительный и тд
        DateTime OpenDate { get; } //дата открытия счета

        bool HasEnoughMoney(float amount);

        //Те методы и свойства, которые мы хотим сделать доступными для переопределения, в базовом классе помечается модификатором virtual.
        OperationResult Withdraw(float amount);

        OperationResult Deposit(float amount);

        float GetAccountBalance();

    }
}
