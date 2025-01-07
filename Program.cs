namespace Simulator;
internal class Program
{
    static void Main(string[] args)
    {
        Lab5a();
    }
    static void Lab4a()
    {
        Console.WriteLine("HUNT TEST\n");
        var o = new Orc() { Name = "Gorbag", Rage= 7 };
        o.SayHi();
        for (int i = 0; i < 10; i++)
        {
            o.Hunt();
            o.SayHi();
        }

        Console.WriteLine("\nSING TEST\n");
        var e = new Elf("Legolas", agility: 2);
        e.SayHi();
        for (int i = 0; i < 10; i++)
        {
            e.Sing();
            e.SayHi();
        }

        Console.WriteLine("\nPOWER TEST\n");
        Creature[] creatures = {
        o,
        e,
        new Orc("Morgash", 3, 8),
        new Elf("Elandor", 5, 3)
    };
        foreach (Creature creature in creatures)
        {
            Console.WriteLine($"{creature.Name,-15}: {creature.Power}");
        }
    }

    static void Lab5a()
    {
        try
        {
            // Poprawne prostokąty
            Rectangle r1 = new Rectangle(2, 3, 5, 7);
            Console.WriteLine($"Prostokat {r1}");

            // Prostokąt z błędnym układem współrzędnych
            Rectangle r2 = new Rectangle(5, 7, 2, 3);
            Console.WriteLine($"Prostokat {r2} z zamienionymi miejscami");

            // Prostokąt zawierający punkt
            Point p1 = new Point(3, 4);
            Console.WriteLine($"Prostokat {r1} zawiera w sobie punkt {p1}: {r1.Contains(p1)}");

            // Prostokąt nie zawierający punktu
            Point p2 = new Point(10, 10);
            Console.WriteLine($"Prostokat {r1} zawiera w sobie punkt {p2}: {r1.Contains(p2)}");

            // Niepoprawny prostokąt (współliniowy)
            Rectangle invalid = new Rectangle(2, 3, 2, 7);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

}

