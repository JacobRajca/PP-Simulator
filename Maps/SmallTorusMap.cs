namespace Simulator.Maps;

public class SmallTorusMap : SmallMap
{
    public SmallTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
    }

    public override bool Exist(Point p)
    {
        return p.X >= 0 && p.X < SizeX && p.Y >= 0 && p.Y < SizeY;
    }

    public override Point Next(Point p, Direction d)
    {
        var next = p.Next(d);
        
        int x = (next.X + SizeX) % SizeX;
        int y = (next.Y + SizeY) % SizeY;

        return new Point(x, y);
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        var nextDiagonal = p.NextDiagonal(d);
        
        int x = (nextDiagonal.X + SizeX) % SizeX;
        int y = (nextDiagonal.Y + SizeY) % SizeY;

        return new Point(x, y);
    }
}