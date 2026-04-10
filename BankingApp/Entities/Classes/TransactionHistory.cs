using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Etities.Classes
{
    public class TransactionHistory
    {
        private List<Transaction> _transactions = new List<Transaction>(); //тут ссылка на класс Transaction

        public void AddTransaction(Transaction transaction)
        {
            _transactions.Add(transaction);
        }

        public List<Transaction> ShowAllTransactions()
        {
            return _transactions;
        }

        public void ClearAllTransactions()
        {
            _transactions.Clear();
        }
    }
}

