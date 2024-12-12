using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;
public class Creature
{
    public string Name { get; set; }
    public int Level { get; set; }

    public Creature(string name, int level=1)
    {
        Name = name;
        Level = level;
    }

    public Creature() 
    {
        Name = "";
        Level = 1;
    }

    public string Info => $"{Name}, Level {Level}";

    public void sayHi()
    {
        Console.WriteLine($"Hi, my name is {Name} and I am at level {Level}";
    }
}

