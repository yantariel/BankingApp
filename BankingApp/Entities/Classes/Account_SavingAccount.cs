using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Classes
{
    //internal class Account_SavingAccount : Account
    //{
    //    public float InterestRate { get; private set; } //годовые проценты на счет 

    //    public Account_SavingAccount(float accountBalance, string accountOwnerName, string accountNumber,
    //        AccountType accountType, DateTime openDate, float interestRate)
    //        : base(accountBalance, accountOwnerName, accountNumber, AccountType.Credit)
    //    {
    //        InterestRate = interestRate;
    //    }

    //    public OperationResult ApplyInterest() //начисление процентов (раз в месяц)
    //    {
    //        OperationResult result = new OperationResult();

    //        if (AccountBalance > 0)
    //        {
    //            float monthlyInterest = AccountBalance * InterestRate / 100 / 12; //100 - переводит процентов, 12 - кол-во месяцев в году
    //            AccountBalance += monthlyInterest;

    //            result.Success = true;
    //            result.Message = "Успешно начислены проценты по счету";
    //            return result;
    //        }
    //        result.Success = false;
    //        result.Message = "Проценты по счету не начислены";
    //        return result;
    //    }
    //}
}
