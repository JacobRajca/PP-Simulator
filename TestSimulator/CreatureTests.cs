using Simulator;
using Simulator.Maps;

namespace TestSimulator;

public class CreatureTests
{
    [Theory]
    [InlineData(2,2,Direction.Up, 2, 3)]
    [InlineData(3,5,Direction.Right, 4, 5)]
    [InlineData(8,9,Direction.Left, 7, 9)]
    [InlineData(9,14,Direction.Down, 9, 13)]
    public void CreatureShouldMoveCorrectlyOnAssignedMap(int x, int y, Direction direction,int expectedX, int expectedY)
    {
        // Arrange
        var map = new SmallSquareMap(10,15);
        var creature = new Orc("TestOrc");
        creature.AssignMap(map, new Point(x, y));
        // Act
        creature.Go(direction);
        // Assert
        Assert.Equal(new Point(expectedX,expectedY), creature.Position);
    }
}