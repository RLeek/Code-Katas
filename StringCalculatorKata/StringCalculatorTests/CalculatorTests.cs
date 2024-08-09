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

        [Fact]
        public void TwoNumString_ReturnsSum()
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var result = calculator.Add("1,1");

            // Assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void ThreeNumString_ReturnsSum()
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var result = calculator.Add("1,1,1");

            // Assert
            Assert.Equal(3, result);
        }
    }
}