using Simulator;

namespace TestSimulator;

public class ValidatorTests
{
    [Fact]
    public void Limiter_ShouldReturnMaxWhenAboveRange()
    {
        // Arrange
        var value = 15;
        var min = 0;
        var max = 10;

        // Act
        var result = Validator.Limiter(value, min, max);

        // Assert
        Assert.Equal(max, result);
    }
    
    [Theory]
    [InlineData(5, 1, 10, 5)]
    [InlineData(0, 1, 10, 1)]
    [InlineData(15, 1, 10, 10)]
    public void Limiter_ShouldReturnCorrectValue(int value, int min, int max, int expected)
    {
        // Act
        var result = Validator.Limiter(value, min, max);

        // Assert
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void Shortener_ShouldPadToMinWhenShorterThanMin()
    {
        // Arrange
        var value = "Hi";
        var min = 5;
        var max = 10;
        var placeholder = '#';

        // Act
        var result = Validator.Shortener(value, min, max, placeholder);

        // Assert
        Assert.Equal("Hi###", result);
    }
    
    [Theory]
    [InlineData("Short", 3, 10, '#', "Short")]
    [InlineData("Short", 6, 10, '#', "Short#")]
    [InlineData("This is a very long string", 6, 15, '#', "This is a very #")]
    [InlineData("Hello", 10, 15, '#', "Hello#####")]
    public void Shortener_ShouldReturnCorrectString(string value, int min, int max, char placeholder, string expected)
    {
        // Act
        var result = Validator.Shortener(value, min, max, placeholder);

        // Assert
        Assert.Equal(expected, result);
    }
}