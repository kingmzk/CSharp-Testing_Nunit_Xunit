using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    public interface ILogBook
    {
        public int LogSeverity { get; set; }

        public string LogType { get; set; }

        void Message(string message);

        bool LogDb(string message);

        bool LogBalanceAfterWithdrawal(int balaceAfterWithdrawal);

        string MessageWithReturnsStr(string message);

        bool LogWithOutputResult(string str, out string outputstr);

        bool LogWithRefObj(ref Customer customer);

    }

    public class LogBook : ILogBook
    {
        public int LogSeverity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string LogType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool LogBalanceAfterWithdrawal(int balaceAfterWithdrawal)
        {
            if(balaceAfterWithdrawal >= 0)
            {
                Console.WriteLine("Success");
                return true;
            }
            Console.WriteLine("failure");
            return false;
        }

        public bool LogDb(string message)
        {
            Console.WriteLine(message);
            return true;
        }

        public bool LogWithOutputResult(string str, out string outputstr)
        {
            outputstr = "Hello " + str;
            return true;
        }

        public bool LogWithRefObj(ref Customer customer)
        {
            return true;
        }

        public void Message(string message)
        {
            Console.WriteLine(message);
        }

        public string MessageWithReturnsStr(string message)
        {
            Console.WriteLine(message);
            return message;
        }
    }

    /*
    public class LogFakker : ILogBook
    {
        public void Message(string message)
        {
            Console.WriteLine(message);
        }
    }
    */
}
