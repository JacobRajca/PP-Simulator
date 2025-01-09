using Simulator;

namespace TestSimulator;

public class RectangleTests
{
    [Fact]
    public void Rectangle_ShouldCreateRectangle()
    {
        // Act
        var rect = new Rectangle(0, 0, 5, 5);

        // Assert
        Assert.Equal(0, rect.X1);
        Assert.Equal(0, rect.Y1);
        Assert.Equal(5, rect.X2);
        Assert.Equal(5, rect.Y2);
    }
    
    [Theory]
    [InlineData(0,0,2,3,0,0,2,3)]
    [InlineData(5,5,2,2,2,2,5,5)]
    [InlineData(3,3,2,1,2,1,3,3)] 
    [InlineData(1,2,3,4,1,2,3,4)] 
    public void Rectangle_ShouldSwapRectanglePositions(int x1, int y1, int x2, int y2, int expectedX1, int expectedY1, int expectedX2, int expectedY2)
    {
        // Arrange
        var rectangle = new Rectangle(x1, y1, x2, y2);
        // Assert
        Assert.Equal(expectedX1, rectangle.X1);
        Assert.Equal(expectedY1, rectangle.Y1);
        Assert.Equal(expectedX2, rectangle.X2);
        Assert.Equal(expectedY2, rectangle.Y2);
    }
    
    [Theory]
    [InlineData(0,0,2,3,1,1,true)]
    [InlineData(5,5,2,2,3,3,true)]
    [InlineData(3,3,2,1,4,4,false)] 
    [InlineData(1,2,3,4,2,5,false)] 
    public void Contains_ShouldReturnCorrectValue(int x1, int y1, int x2, int y2,int pointX,int pointY,bool expectedResult)
    {
        // Arrange
        var rect = new Rectangle(x1, y1, x2, y2);
        var point = new Point(pointX,pointY);
        // Act
        var result = rect.Contains(point);
        // Assert
        Assert.Equal(result,expectedResult);
    }
    
    [Theory]
    [InlineData(0,0,2,3,"(0, 0):(2, 3)")]
    [InlineData(5,5,2,2,"(2, 2):(5, 5)")]
    [InlineData(3,3,2,1,"(2, 1):(3, 3)")] 
    [InlineData(1,2,3,4,"(1, 2):(3, 4)")] 
    public void ToString_ShouldReturnCorrectValue(int x1, int y1, int x2, int y2, string expectedResult)
    {
        // Arrange
        var rect = new Rectangle(x1, y1, x2, y2);
        // Act
        var result = rect.ToString();
        // Assert
        Assert.Equal(expectedResult, result);
    }
}