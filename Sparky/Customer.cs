using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sparky
{

    public interface ICustomer
    {
         string GreetMessage { get; set; }

         int Discount { get; set; }

         int OrderTotal { get; set; }

         bool IsPlatinum { get; set; }

        string CombineName(string firstname, string lastname);

        CustomerType GetCustomerType();


    }


    public class Customer : ICustomer
    {
        public string GreetMessage { get; set; }

        public int Discount { get; set; }

        public int OrderTotal { get; set; }

        public bool IsPlatinum { get; set; }

        public Customer()
        {
            IsPlatinum = false;
            Discount = 15;
        }

        public string CombineName(string Firstname, string Lastname)
        {
            if (string.IsNullOrWhiteSpace(Firstname))
            {
                throw new ArgumentNullException(Firstname, "The firstname cannot be null or empty");
            }
            GreetMessage = $"Hello {Firstname} {Lastname}";
            Discount = 20;
            return GreetMessage;
        }

        public CustomerType GetCustomerType()
        {
            if (OrderTotal < 100)
                return new BasicCustomer();
            else
                return new PremiumCustomer();
        } 
    }

    public class CustomerType { }

    public class BasicCustomer : CustomerType { }

    public class PremiumCustomer : CustomerType { }
}
