using StringCalculatorKata;

namespace StringCalculatorTests
{
    public class CalculatorTests
    {
        [Fact]
        public void EmptyString_ReturnsZero()
        {
            // Arrange
            var calculator = new Calculator();
            
            // Act
            var result = calculator.Add("");

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void NumString_ReturnsNum()
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var result = calculator.Add("1");

            // Assert
            Assert.Equal(1, result);
        }

        [Theory]
        [InlineData("1,1")]
        [InlineData("1\n1")]
        [InlineData("//;\n1;1")]
        [InlineData("//;\n1\n1")]
        public void TwoNumString_ReturnsSum(string input)
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var result = calculator.Add(input);

            // Assert
            Assert.Equal(2, result);
        }

        [Theory]
        [InlineData("1,1,1")]
        [InlineData("1\n1,1")]
        [InlineData("1\n1\n1")]
        [InlineData("//;\n1;1;1")]
        [InlineData("//;\n1;1\n1")]
        public void ThreeNumString_ReturnsSum(string input)
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var result = calculator.Add(input);

            // Assert
            Assert.Equal(3, result);
        }

        [Theory]
        [InlineData("1,-1,1")]
        [InlineData("-1\n1,1")]
        [InlineData("1\n1\n-1")]
        [InlineData("//;\n-1;1;1")]
        [InlineData("//;\n1;-1\n1")]
        public void NegativeNumString_ThrowsException(string input)
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            Action result = ()=> calculator.Add(input);

            // Assert
            Assert.Throws<System.Exception>(result);
        }


        [Theory]
        [InlineData("1001,1")]
        [InlineData("1,1001,1001")]
        public void LargeNumString_IgnoresNum(string input)
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var result = calculator.Add(input);

            // Assert
            Assert.Equal(1, result);
        }

        [Theory]
        [InlineData("//******\n1******1")]
        [InlineData("//sad\n1sad1")]
        public void CustomDelimiterString_ReturnsSum(string input)
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var result = calculator.Add(input);

            // Assert
            Assert.Equal(2, result);
        }

        [Theory]
        [InlineData("//[******][sad]\n1******1sad1")]
        [InlineData("//[gg][sad]\n1gg1sad1")]
        public void MultipleDelimiterString_ReturnsSum(string input)
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var result = calculator.Add(input);

            // Assert
            Assert.Equal(3, result);
        }
    }
}