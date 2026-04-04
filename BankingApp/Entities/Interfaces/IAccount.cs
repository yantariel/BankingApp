using BankingApp.Classes;
using BankingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BankingApp.Interfaces
{
    internal interface IAccount
    {
        float AccountBalance { get; set; }
        string AccountOwnerName { get; }    
        string AccountNumber { get; }
        AccountType AccountType { get; } //вид счета - кредитный, накопительный и тд
        DateTime OpenDate { get; } //дата открытия счета

        OperationResult Withdraw(float amount);
        OperationResult Deposit(float amount);
        float GetAccountBalance();
        //void AddTranaction(Transaction transaction);  //реализовать в Account
        //List<Transaction> GetTransactionHistory(); //можно на ObservableCollection поменять хз пока
    }
}
