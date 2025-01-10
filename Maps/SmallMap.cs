namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    protected SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX >= 20 || sizeY >= 20)
            throw new ArgumentOutOfRangeException("Wymiary mapy muszą być mniejsze lub równe 20.");
    }
    
    private readonly Dictionary<Point, List<Creature>> _creatures = new();
    
    public void Add(Creature creature, Point position)
    {
        if (!Exist(position))
            throw new ArgumentOutOfRangeException(nameof(position), "Pozycja poza granicami mapy.");

        if (!_creatures.ContainsKey(position))
            _creatures[position] = new List<Creature>();

        _creatures[position].Add(creature);
    }
    
    public void Remove(Creature creature, Point position)
    {
        if (_creatures.ContainsKey(position))
        {
            _creatures[position].Remove(creature);
            if (_creatures[position].Count == 0)
                _creatures.Remove(position);
        }
    }
    
    public void Move(Creature creature, Point from, Point to)
    {
        Remove(creature, from);
        Add(creature, to);
    }
    
    public List<Creature> At(Point position)
    {
        return _creatures.ContainsKey(position) ? _creatures[position] : new List<Creature>();
    }
    
    public List<Creature> At(int x, int y)
    {
        return At(new Point(x, y));
    }
}