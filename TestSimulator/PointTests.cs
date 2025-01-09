using Simulator;

namespace TestSimulator;

public class PointTests
{
    [Fact]
    public void Point_ValidSize_ShouldSetPoint()
    {
        // Arrange & Act
        var point = new Point(5, 10);
            
        // Assert
        Assert.Equal(5, point.X);
        Assert.Equal(10, point.Y);
    }

    [Theory]
    [InlineData(5, 10, Direction.Up, 5, 11)]
    [InlineData(10, 1, Direction.Down, 10, 0)]
    [InlineData(2, 8, Direction.Left, 1, 8)] 
    [InlineData(15, 10, Direction.Right, 16, 10)] 
    public void Next_ShouldReturnCorrectNextPoint(int x, int y, 
        Direction direction, int expectedX, int expectedY)
    {
        // Arrange
        var point = new Point(x, y);
        // Act
        var nextPoint = point.Next(direction);
        // Assert
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }

    [Theory]
    [InlineData(5, 10, Direction.Up, 6, 11)]
    [InlineData(5, 5, Direction.Down, 4, 4)]
    [InlineData(5, 8, Direction.Left, 4, 9)]
    [InlineData(12, 10, Direction.Right, 13, 9)] 
    public void NextDiagonal_ShouldReturnCorrectNextPoint(int x, int y, 
        Direction direction, int expectedX, int expectedY)
    {
        // Arrange
        var point = new Point(x, y);
        // Act
        var nextPoint = point.NextDiagonal(direction);
        // Assert
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }
}