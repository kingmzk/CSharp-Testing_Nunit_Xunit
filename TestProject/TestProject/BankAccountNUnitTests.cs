using Moq;
using Sparky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkyNUnit
{
    [TestFixture]
    public class BankAccountNUnitTests
    {
        private BankAccount bankAccount;
        /*
        [SetUp]
        public void SetUp()
        {
            bankAccount = new BankAccount(new LogBook() );
        }

        [Test]
        public void BankDepositMethod_Add100_ReturnTrue()
        {
            var result = bankAccount.Deposit(100);
            Assert.IsTrue( result );
            Assert.That(result, Is.True);
            Assert.That(bankAccount.GetBalance, Is.EqualTo(100));
        }
        */

        //[SetUp]
        //public void SetUp()
        //{
        //    bankAccount = new BankAccount(new LogFakker());
        //}


        //[Test]
        //public void BankDepositMethod_Add100_ReturnTrue()
        //{
        //    var result = bankAccount.Deposit(100);
        //    Assert.IsTrue(result);
        //    Assert.That(result, Is.True);
        //    Assert.That(bankAccount.GetBalance, Is.EqualTo(100));
        //}



        [Test]
        public void BankDeposit_Add100_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(x => x.Message("Deposite invoked"));

            bankAccount = new BankAccount(logMock.Object);
            var result = bankAccount.Deposit(100);
            Assert.IsTrue(result);
            Assert.That(result, Is.True);
            Assert.That(bankAccount.GetBalance, Is.EqualTo(100));
        }


        [Test]
        public void BankWithdraw_Withdraw100With200Balance_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(x => x.LogDb(It.IsAny<string>())).Returns(true);
            logMock.Setup(x => x.LogBalanceAfterWithdrawal(It.IsAny<int>())).Returns(true);

            bankAccount = new BankAccount(logMock.Object);
            bankAccount.Deposit(200);
            var result = bankAccount.Withdraw(100);

            Assert.IsTrue(result);
            Assert.That(result, Is.True);
            Assert.That(bankAccount.GetBalance, Is.EqualTo(100));
        }

        [Test]
        [TestCase(200,100)]
        public void BankWithdraw_Withdraw100With200Balance_ReturnTrue(int balance, int withdraw)
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(x => x.LogDb(It.IsAny<string>())).Returns(true);
            logMock.Setup(x => x.LogBalanceAfterWithdrawal(It.Is<int>(x => x > 0))).Returns(true);

            bankAccount = new BankAccount(logMock.Object);
            bankAccount.Deposit(balance);
            var result = bankAccount.Withdraw(withdraw);

            Assert.IsTrue(result);
           
        }

        [Test]
        [TestCase(200, 300)]
        public void BankWithdraw_Withdraw300With200Balance_ReturnFalse(int balance, int withdraw)
        {
            var logMock = new Mock<ILogBook>();
           // logMock.Setup(x => x.LogDb(It.IsAny<string>())).Returns(true);
            logMock.Setup(x => x.LogBalanceAfterWithdrawal(It.Is<int>(x => x > 0))).Returns(true);
            // logMock.Setup(x => x.LogBalanceAfterWithdrawal(It.Is<int>(x => x < 0))).Returns(false);
            logMock.Setup(x => x.LogBalanceAfterWithdrawal(It.IsInRange<int>(int.MinValue, -1 ,Moq.Range.Inclusive))).Returns(false);


            bankAccount = new BankAccount(logMock.Object);
            bankAccount.Deposit(balance);
            var result = bankAccount.Withdraw(withdraw);

            Assert.IsFalse(result);

        }


        [Test]
        public void BankLogDummy_LogMockStringOutputStr_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            string desiredOutput = "hello" ;

            logMock.Setup(x => x.LogWithOutputResult(It.IsAny<string>(),out desiredOutput)).Returns(true);
            string result = "";
            Assert.IsTrue(logMock.Object.LogWithOutputResult("Ben", out result));
            Assert.That(result, Is.EqualTo(desiredOutput));
        }

        [Test]
        public void BankLogDummy_LogRef_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            Customer customer = new();
            Customer customerNotUsed = new();

            logMock.Setup(x => x.LogWithRefObj(ref customer)).Returns(true);
          
            Assert.IsTrue(logMock.Object.LogWithRefObj(ref customer));
            Assert.IsFalse(logMock.Object.LogWithRefObj(ref customerNotUsed));

        }



        [Test]
        public void BankLogDummy_SetAndGetLogTypeAndSeverityMock_MockTest()
        {
            var logMock = new Mock<ILogBook>();
            logMock.SetupAllProperties();
            logMock.Setup(x => x.LogSeverity).Returns(10);
            logMock.Setup(x => x.LogType).Returns("Warning");

            logMock.Object.LogSeverity = 100;   //this willl not work  only works when we use SetupAllProperties

            Assert.That(logMock.Object.LogSeverity, Is.EqualTo(10));
            Assert.That(logMock.Object.LogType, Is.EquivalentTo("Warning"));


            //callbacks
            string logTemp = "Hello, ";
            logMock.Setup(x => x.LogDb(It.IsAny<string>())).Returns(true)
                .Callback((string str) => logTemp += str);
            logMock.Object.LogDb("Ben");
            Assert.That(logTemp, Is.EqualTo("Hello, Ben"));


            //callbacks
            int counter = 5;
            logMock.Setup(x => x.LogDb(It.IsAny<string>())).Callback(() => counter++).Returns(true);
            logMock.Object.LogDb("Ben");
            Assert.That(counter, Is.EqualTo(6));
        }


        [Test]
        public void BankLogDummy_VerifyExample()
        {
            var logMock = new Mock<ILogBook>();
            BankAccount bankAccount = new(logMock.Object);
            bankAccount.Deposit(100);
            Assert.That(bankAccount.GetBalance, Is.EqualTo(100));

            //verify
            logMock.Verify(x => x.Message(It.IsAny<string>()), Times.Exactly(3));
            logMock.Verify(x => x.Message("Test"), Times.AtLeastOnce);
            logMock.VerifySet(x => x.LogSeverity = 100, Times.Once);
            logMock.VerifyGet(x => x.LogSeverity, Times.Once);



        }


    }
}
