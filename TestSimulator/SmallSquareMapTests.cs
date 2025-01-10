using Simulator;
using Simulator.Maps;

namespace TestSimulator;

public class SmallSquareMapTests
{
    [Fact]
    public void Constructor_ValidSize_ShouldSetSize()
    {
        // Arrange
        int sizeX = 10;
        int sizeY = 15;
        // Act
        var map = new SmallSquareMap(sizeX, sizeY);
        // Assert
        Assert.Equal(sizeX, map.SizeX);
        Assert.Equal(sizeY, map.SizeY);
    }

    [Theory]
    [InlineData(4,10)]
    [InlineData(21,10)]
    [InlineData(10,4)]
    [InlineData(10,21)]
    public void 
        Constructor_InvalidSize_ShouldThrowArgumentOutOfRangeException
        (int sizeX, int sizeY)
    {
        // Act & Assert
        // The way to check if method throws anticipated exception:
        Assert.Throws<ArgumentOutOfRangeException>(() =>
             new SmallSquareMap(sizeX,sizeY));
    }

    [Theory]
    [InlineData(3, 4, 10, 15, true)]
    [InlineData(10, 15, 10, 15, false)]
    [InlineData(0, 0, 10, 15, true)]
    [InlineData(9, 14, 10, 15, true)]
    public void Exist_ShouldReturnCorrectValue(int x, int y, 
        int sizeX,int sizeY, bool expected)
    {
        // Arrange
        var map = new SmallSquareMap(sizeX,sizeY);
        var point = new Point(x, y);
        // Act
        var result = map.Exist(point);
        // Assert
        Assert.Equal(expected, result);
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
        var map = new SmallSquareMap(18,15);
        var point = new Point(x, y);
        // Act
        var nextPoint = map.Next(point, direction);
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
        var map = new SmallSquareMap(15,15);
        var point = new Point(x, y);
        // Act
        var nextPoint = map.NextDiagonal(point, direction);
        // Assert
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }
}