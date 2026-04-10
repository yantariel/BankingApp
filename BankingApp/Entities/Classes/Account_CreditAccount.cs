using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Classes
{
    //internal class Account_CreditAccount : Account
    //{
    //    public float CreditLimit { get; private set; } //ограничение по кредитному счету
    //    public float InterestRate { get; private set; } //проценты по кредиту 

    //    public Account_CreditAccount(float accountBalance, string accountOwnerName, string accountNumber, 
    //        AccountType accountType, DateTime openDate, float creditLimit, float interestRate)
    //        : base(accountBalance, accountOwnerName, accountNumber, AccountType.Credit)
    //    {
    //        InterestRate = interestRate;
    //        CreditLimit = creditLimit;
    //    }

    //    //А чтобы переопределить метод в классе-наследнике, этот метод определяется с модификатором override. 
    //    public override OperationResult Withdraw(float amount) //снятие/перевод денег, баланс кредитной карты может быть отрицательным
    //    {
    //        OperationResult result = new OperationResult();

    //        if (amount < 0)
    //        {
    //            result.Success = false;
    //            result.Message = "Сумма перевода не может быть отрицательной";
    //            return result;
    //        }

    //        if (AccountBalance - amount < -CreditLimit)
    //        {
    //            result.Success = false;
    //            result.Message = "Превышен лимит по кредиту";
    //            return result;
    //        }

    //        AccountBalance -= amount;
    //        result.Success = true;
    //        result.Message = $"Успешно переведено {amount}₽";
    //        return result;
    //    }

    //}
}
