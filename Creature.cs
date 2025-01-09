
namespace Simulator;
public abstract class Creature
{
    private string _name = "Unknown";
    private int _level = 1;

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


    public string Go(Direction direction) => $"{direction.ToString().ToLower()}";

    public string[] Go(Direction[] directions)
    {
        var results = new string[directions.Length];
    
        for (int i = 0; i < directions.Length; i++)
        {
            results[i] = Go(directions[i]);
        }
    
        return results;
    }

    public string[] Go(string input)
    {
        var directions = DirectionParser.Parse(input);
        return Go(directions);
    }

    public override string ToString()
    {
        return $"{this.GetType().Name.ToUpper()}: {Name} [{Level}]{Info}";
    }
}