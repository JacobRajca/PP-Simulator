namespace Simulator.Maps;

public class SmallSquareMap : Map
{
    public int Size { get; }

    private readonly Rectangle _bounds;

    public SmallSquareMap(int size)
    {
        if (size < 5 || size > 20)
            throw new ArgumentOutOfRangeException(nameof(size), "Rozmiar mapy musi zawierac sie w przedziale od 5 do 20");

        Size = size;
        
        _bounds = new Rectangle(0, 0, Size - 1, Size - 1);
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