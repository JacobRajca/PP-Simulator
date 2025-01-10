using Simulator.Maps;
namespace Simulator;
public abstract class Creature
{
    private string _name = "Unknown";
    private int _level = 1;
    public Point? Position { get; private set; } = null;
    public SmallMap? Map { get; private set; } = null;
    public string Name
    {
        get => _name;
        set
        {
            if (!string.IsNullOrEmpty(_name) && _name != "Unknown")
            {
                throw new InvalidOperationException("Name can only be set once.");
            }

            if (string.IsNullOrEmpty(value))
            {
                value = "###";
            }

            value = value.Trim();

            value = Validator.Shortener(value, 3, 25, '#');

            if (char.IsLower(value[0]))
            {
                value = char.ToUpper(value[0]) + value.Substring(1);
            }

            _name = value;
        }
    }

    public int Level
    {
        get => _level;
        set
        {
            if (_level != 1)
            {
                throw new InvalidOperationException("Level can only be set once.");
            }
            _level = Validator.Limiter(value, 1, 10);
        }
    }

    public abstract string Greeting();
    public abstract int Power { get; }

    public abstract string Info{get; }
    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public Creature() { }

    public void Upgrade()
    {
        if (_level < 10)
        {
            _level++;
        }
    }
    public override string ToString()
    {
        return $"{this.GetType().Name.ToUpper()}: {Name} [{Level}]{Info}";
    }
    
    public void AssignMap(SmallMap map, Point position)
    {
        if (!map.Exist(position))
            throw new ArgumentException("Postac poza granicami mapy");

        Map = map;
        Position = position;
        map.Add(this, position);
    }

    public void Go(Direction direction)
    {
        if (Map == null || Position == null)
            return;

        var newPosition = Map.Next(Position.Value, direction);
        Map.Move(this, Position.Value, newPosition);
        Position = newPosition;
    }
}