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

public class Elf : Creature
{
    private int _singCount = 0;

    public int Agility{ get;set; }

    public Elf(string name = "Unknown", int level = 1, int agility=0) : base(name, level)
    {
        Agility = Validator.Limiter(agility, 0, 10);
    }

    public override void SayHi() => Console.WriteLine(
    $"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}."
    );

    public void Sing()
    {
        Console.WriteLine($"{Name} is singing.");
        _singCount++;
        if (_singCount % 3 == 0)
        {
            Agility = Validator.Limiter(Agility + 1, 0, 10);
        }
    }
    public override int Power => Level * 8 + Agility * 2;

    public override string Info => $"[{Agility}]";
}

public class Orc : Creature
{
    private int _huntCount = 0;
    public int Rage { get;set; }

    public Orc(string name = "Unknown", int level = 1, int rage = 0) : base(name, level)
    {
        Rage = Validator.Limiter(rage,0,10);
    }
    public override void SayHi() => Console.WriteLine(
    $"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}."
    );

    public void Hunt()
    {
        Console.WriteLine($"{Name} is hunting.");
        _huntCount++;
        if (_huntCount % 2 == 0)
        {
            Rage = Validator.Limiter(Rage + 1,0,10);
        }
    }
    public override int Power => Level * 7 + Rage * 3;

    public override string Info => $"[{Rage}]";
}

public static class Validator
{

    public static int Limiter(int value, int min, int max)
    {
        return Math.Clamp(value,min, max);
    }


    public static string Shortener(string value, int min, int max, char placeholder)
    {
        if (value.Length < min) return value.PadRight(min, placeholder);
        if (value.Length > max)
        {
            return value.Substring(0, max) + placeholder;
        }
        return value;
    }
}