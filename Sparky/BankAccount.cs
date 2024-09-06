using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    public class BankAccount
    {
        private readonly ILogBook _logBook;

        public int balance { get; set; }

        public BankAccount(ILogBook logBook)
        {
            balance = 0;
            _logBook = logBook;
        }

        public bool Deposit(int amount)
        {
            _logBook.Message("LogBook: Deposit called with " + amount);
            _logBook.Message("Test");
            _logBook.LogSeverity = 100;
            var temp = _logBook.LogSeverity;
            balance += amount;
            return true;
        }

        public bool Withdraw(int amount)
        {
            if(amount <= balance)
            {
                _logBook.Message("LogBook: Withdraw called with " + amount);
                balance -= amount;
                return _logBook.LogBalanceAfterWithdrawal(balance); 
            }
            _logBook.Message("LogBook: Insufficient funds!"); 
            return _logBook.LogBalanceAfterWithdrawal(balance - amount);
        }

        public int GetBalance()
        {
            _logBook.Message($"LogBook: GetBalance called with balance {balance}");
            return balance;
        }
    }
}
