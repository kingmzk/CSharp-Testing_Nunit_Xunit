using Sparky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    public class CustomerXUnitTest
    {
        private Customer customer;
        public CustomerXUnitTest()
        {
            customer = new Customer();
        }


        [Fact]
        public void CombineName_InputFirstAndLastName_ReturnFullName()
        {
            // Arrange
            //var customer = new Customer();

            // Act
            // var result = customer.CombineName("John", "Doe");
            customer.CombineName("John", "Doe");

            // Assert
                Assert.Equal("Hello John Doe",customer.GreetMessage);
                Assert.Contains("Hello", customer.GreetMessage);
                Assert.StartsWith("Hello", customer.GreetMessage);
                Assert.EndsWith("Doe", customer.GreetMessage);
                Assert.Matches("Hello [A-Z]{1}[a-z]", customer.GreetMessage); //regular expresssions
            
        }


        [Fact]
        public void GreetMessage_NotGreeted_ReturnNull()
        {
            //Arrange

            //Act

            //Assert
            Assert.Null(customer.GreetMessage);
        }


        [Fact]
        public void DiscountCheck_DefaultCustomer_ReturnsDiscountInRange()
        {
            int result = customer.Discount;
            Assert.InRange(result, 10, 40);
        }

        [Fact]
        public void GreetMessage_GreetWithourUserName_ReturnNotNull()
        {
            customer.CombineName("ben", "");

            Assert.NotNull(customer.GreetMessage);
            Assert.False(string.IsNullOrEmpty(customer.GreetMessage));
        }

        [Fact]
        public void GreetChecker_EmptyFirstName_ThrowException()
        {
            var exceptionDetails = Assert.Throws<ArgumentNullException>(() => customer.CombineName("", "Doe"));
            Assert.Equal("The firstname cannot be null or empty", exceptionDetails.Message);

            Assert.Throws<ArgumentNullException>(() => customer.CombineName("", "Doe"));

        }

        [Fact]
        public void CustomerType_CreateCustomerWithLessThen100Order()
        {
            customer.OrderTotal = 10;
            var result = customer.GetCustomerType();
            Assert.IsType<BasicCustomer>(result);
        }

        [Fact]
        public void CustomerType_CreateCustomerWithGreaterThen100Order()
        {
            customer.OrderTotal = 101;
            var result = customer.GetCustomerType();
            Assert.IsType<PremiumCustomer>(result);
        }
    }
}
