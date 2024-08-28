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
            balance += amount;
            return true;
        }

        public bool Withdraw(int amount)
        {
            if(amount <= balance)
            {
                _logBook.Message("LogBook: Withdraw called with " + amount);
                balance -= amount;
                return true;
            }
            _logBook.Message("LogBook: Insufficient funds!"); 
            return false;
        }

        public int GetBalance()
        {
            _logBook.Message($"LogBook: GetBalance called with balance {balance}");
            return balance;
        }
    }
}
