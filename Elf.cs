namespace Simulator;

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