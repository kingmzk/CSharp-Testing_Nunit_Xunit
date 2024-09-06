using Sparky;

namespace Sparky
{
    public class CalculatorXUnitTests
    {


        [Fact]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        {
            //Arrange
            var calculator = new Calculator();

            //Act
            var result = calculator.AddNumbers(5, 5);


            //Assert
            Assert.Equal(10, result);
        }


        [Fact]
        public void Odd_InputTwoInt_ReturnTrue()
        {
            //Arrange
            var calculator = new Calculator();

            //Act
            var result = calculator.odd(3);

            //Assert
            Assert.True(result);
            //  Assert.IsFalse(result);
        }


        [Theory]
        [InlineData(4)]
        [InlineData(12)]
        public void Odd_InputTwoInt_ReturnFalse(int num)
        {
            //Arrange
            var calculator = new Calculator();

            //Act
            var result = calculator.odd(num);

            //Assert
            // Assert.IsTrue(result);
            Assert.False(result);
        }


        [Theory]
        [InlineData(4)]
        [InlineData(12)]
        public void Odd_InputTwoInt_ReturnFal(int num)
        {
            //Arrange
            var calculator = new Calculator();

            //Act
            var result = calculator.odd(num);

            //Assert
            // Assert.True(result);
            Assert.False(result);
        }


        [Theory]
        [InlineData(4,  false)]
        [InlineData(11, true)]
        public void Odd_Input_TwoInt_ReturnBool(int num, bool expectedResult)
        {
            //Arrange
            var calculator = new Calculator();

            //Act
            var result = calculator.odd(num);

            //Assert
            Assert.Equal(expectedResult, result);
        }


        [Theory]
        [InlineData(5.5, 5.5)]
        public void AddNumbersDouble_InputTwoDouble_GetCorrectAddition(double num1, double num2)
        {
            //Arrange
            var calculator = new Calculator();

            //Act
            var result = calculator.AddNumbersDouble(num1, num2);

            //Assert
            Assert.Equal(11, result);
        }



        [Fact]
        public void OddRange_InputMinMax_ReturnsOddRange()
        {
            //Arrange
            var calculator = new Calculator();
            List<int> expectedOddRange = new List<int>() { 1, 3, 5, 7, 9 };

            //Act
            var result = calculator.OddRange(1, 10);
                
            //Assert
            Assert.Equal(expectedOddRange, result);
            Assert.Contains(7, result);
            Assert.NotEmpty(result);
            Assert.Equal(5, result.Count);
            Assert.DoesNotContain(6, result);
            Assert.Equal(result.OrderBy(u => u), result);

        }
    }
}