namespace Simulator;

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