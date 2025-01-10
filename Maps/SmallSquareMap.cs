namespace Simulator.Maps;

public class SmallSquareMap : SmallMap
{
    private readonly Rectangle _bounds;

    public SmallSquareMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        _bounds = new Rectangle(0, 0, SizeX - 1, SizeY - 1);
    }

    public override bool Exist(Point p)
    {
        return _bounds.Contains(p);
    }

    public override Point Next(Point p, Direction d)
    {
        var nextPoint = p.Next(d);
        return Exist(nextPoint) ? nextPoint : p;
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        var nextDiagonalPoint = p.NextDiagonal(d);
        return Exist(nextDiagonalPoint) ? nextDiagonalPoint : p;
    }
}
