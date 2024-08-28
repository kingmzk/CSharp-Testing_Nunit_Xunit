using Sparky;

namespace SparkyNUnit
{
    [TestFixture]
    public class CalculatorNUnitTests
    {


        [Test]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        {
            //Arrange
            var calculator = new Calculator();

            //Act
            var result = calculator.AddNumbers(5, 5);


            //Assert
            Assert.That(result, Is.EqualTo(10));
            Assert.AreEqual(10, result);
        }


        [Test]
       public void Odd_InputTwoInt_ReturnTrue()
        {
            //Arrange
            var calculator = new Calculator();

            //Act
            var result = calculator.odd(3);

            //Assert
            Assert.IsTrue(result);
            //  Assert.IsFalse(result);
        }


        [Test]
        [TestCase(4)]
        [TestCase(12)]
        public void Odd_InputTwoInt_ReturnFalse(int num)
        {
            //Arrange
            var calculator = new Calculator();

            //Act
            var result = calculator.odd(num);

            //Assert
            // Assert.IsTrue(result);
            Assert.IsFalse(result);
        }


        [Test]
        [TestCase(4)]
        [TestCase(12)]
        public void Odd_InputTwoInt_ReturnFal(int num)
        {
            //Arrange
            var calculator = new Calculator();

            //Act
            var result = calculator.odd(num);

            //Assert
            // Assert.IsTrue(result);
            Assert.IsFalse(result);
        }


        [Test]
        [TestCase(4, ExpectedResult = false)]
        [TestCase(11,ExpectedResult = true)]
        public bool Odd_Input_TwoInt_ReturnBool(int num)
        {
            //Arrange
            var calculator = new Calculator();

            //Act
            var result = calculator.odd(num);

            //Assert
           return calculator.odd(num);
        }


        [Test]
        [TestCase(5.5, 5.5)]
        [TestCase(5.5, 6.5)]
        public void AddNumbersDouble_InputTwoDouble_GetCorrectAddition(double num1, double num2)
        {
            //Arrange
            var calculator = new Calculator();

            //Act
            var result = calculator.AddNumbersDouble(num1, num2);

            //Assert
            Assert.AreEqual(11, result, 1.5);
        }



        [Test]
        public void OddRange_InputMinMax_ReturnsOddRange()
        {
            //Arrange
            var calculator = new Calculator();
            List<int> expectedOddRange = new List<int>() { 1, 3, 5, 7, 9 };

            //Act
            var result = calculator.OddRange(1, 10);

            //Assert
            Assert.That(expectedOddRange, Is.EquivalentTo(result));
            Assert.AreEqual(expectedOddRange, result);
            Assert.Contains(7, result);
            Assert.That(result, Does.Contain(7));
            Assert.That(result, Is.Ordered); //.ascending ,descending
            Assert.That(result, Is.Unique);
            Assert.That(result, Is.Not.Empty);
            Assert.That(result.Count, Is.EqualTo(5));
            Assert.That(result, Has.No.Member(6));
        }

    }
}