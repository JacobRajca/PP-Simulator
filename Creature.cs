using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public abstract void SayHi();
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


    public void Go(Direction direction)
    {
        Console.WriteLine($"{Name} goes {direction.ToString().ToLower()}.");
    }

    public void Go(Direction[] directions)
    {
        foreach (var direction in directions)
        {
            Go(direction);
        }
    }

    public void Go(string input)
    {
        var directions = DirectionParser.Parse(input);
        Go(directions);
    }

    public override string ToString()
    {
        return $"{this.GetType().Name.ToUpper()}: {Name} [{Level}]{Info}";
    }
}