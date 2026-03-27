using BankingApp.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Interfaces
{
    internal interface IAccount
    {
        List<Transaction> GetTransactionHistory(); //можно на ObservableCollection поменять хз пока

        OperationResult Withdraw(float amount);
        OperationResult Deposit(float amount);
        float GetBalance();
        void AddTranaction(Transaction transaction);
    }
}
