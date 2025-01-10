namespace Simulator.Maps;

/// <summary>
/// Map of points.
/// </summary>
public abstract class Map
{
    /// <summary>
    /// Width of the map.
    /// </summary>
    public int SizeX { get; }

    /// <summary>
    /// Height of the map.
    /// </summary>
    public int SizeY { get; }
    
    /// <summary>
    /// Base constructor for maps.
    /// </summary>
    /// <param name="sizeX">Width of the map.</param>
    /// <param name="sizeY">Height of the map.</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown if dimensions are smaller than 5.
    /// </exception>
    protected Map(int sizeX, int sizeY)
    {
        if (sizeX < 5 || sizeY < 5)
            throw new ArgumentOutOfRangeException("Minimalna wielkosc mapy wynosi 5.");

        SizeX = sizeX;
        SizeY = sizeY;
    }
    
    /// <summary>
    /// Check if give point belongs to the map.
    /// </summary>
    /// <param name="p">Point to check.</param>
    /// <returns></returns>
    public virtual bool Exist(Point p)
    {
        return p.X >= 0 && p.X < SizeX && p.Y >= 0 && p.Y < SizeY;
    }
    
    /// <summary>
    /// Next position to the point in a given direction.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point Next(Point p, Direction d);

    /// <summary>
    /// Next diagonal position to the point in a given direction 
    /// rotated 45 degrees clockwise.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point NextDiagonal(Point p, Direction d);
}