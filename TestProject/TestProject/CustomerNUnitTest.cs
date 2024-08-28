using Sparky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkyNUnit
{
    [TestFixture]
    public class CustomerNUnitTest
    {
        private Customer customer;

        [SetUp]
        public void SetUp()
        {
            customer = new Customer();
        }


        [Test]
        public void CombineName_InputFirstAndLastName_ReturnFullName()
        {
            // Arrange
            //var customer = new Customer();

            // Act
            // var result = customer.CombineName("John", "Doe");
            customer.CombineName("John", "Doe");

            // Assert
            //  Assert.That(result, Is.EqualTo("Hello John Doe"));
            //Assert.That(customer.GreetMessage, Is.EqualTo("Hello John Doe"));
            //Assert.AreEqual(customer.GreetMessage, "Hello John Doe");
            //Assert.That(customer.GreetMessage, Does.Contain("Hello").IgnoreCase);
            //Assert.That(customer.GreetMessage, Does.StartWith("Hello"));
            //Assert.That(customer.GreetMessage, Does.EndWith("Doe"));
            //Assert.That(customer.GreetMessage, Does.Match("Hello [A-Z]{1}[a-z]")); //regular expresssions

            Assert.Multiple(() =>                                                                 //this shows all possible fail erros
            {
                Assert.That(customer.GreetMessage, Is.EqualTo("Hello John Doe"));
                Assert.AreEqual(customer.GreetMessage, "Hello John Doe");
                Assert.That(customer.GreetMessage, Does.Contain("Hello").IgnoreCase);
                Assert.That(customer.GreetMessage, Does.StartWith("Hello"));
                Assert.That(customer.GreetMessage, Does.EndWith("Doe"));
                Assert.That(customer.GreetMessage, Does.Match("Hello [A-Z]{1}[a-z]")); //regular expresssions
            });
        }


        [Test]
        public void GreetMessage_NotGreeted_ReturnNull()
        {
            //Arrange

            //Act

            //Assert
            Assert.IsNull(customer.GreetMessage);
        }


        [Test]
        public  void DiscountCheck_DefaultCustomer_ReturnsDiscountInRange()
        {
            int result = customer.Discount;
            Assert.That(result, Is.InRange(10, 40));
        }

        [Test]
        public void GreetMessage_GreetWithourUserName_ReturnNotNull()
        {
            customer.CombineName("ben", "");

            Assert.IsNotNull(customer.GreetMessage);
            Assert.IsFalse(string.IsNullOrEmpty(customer.GreetMessage));
        }

        [Test]
        public void GreetChecker_EmptyFirstName_ThrowException()
        {
            var exceptionDetails = Assert.Throws<ArgumentNullException>(() => customer.CombineName("", "Doe"));
            Assert.AreEqual("The firstname cannot be null or empty", exceptionDetails.Message);

            Assert.That(() => customer.CombineName("", "Doe"), Throws.ArgumentNullException);

            Assert.That(() => customer.CombineName("", "Doe"),
                Throws.ArgumentNullException.With.Message.EqualTo("The firstname cannot be null or empty"));
        }

        [Test]
        public void CustomerType_CreateCustomerWithLessThen100Order()
        {
            customer.OrderTotal = 10;
            var result = customer.GetCustomerType();
            Assert.That(result, Is.TypeOf<BasicCustomer>());
        }

        [Test]
        public void CustomerType_CreateCustomerWithGreaterThen100Order()
        {
            customer.OrderTotal = 101;
            var result = customer.GetCustomerType();
            Assert.That(result, Is.TypeOf<PremiumCustomer>());
        }
    }
}
