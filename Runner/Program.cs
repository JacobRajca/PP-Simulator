using Simulator;
using Simulator.Maps;
namespace Runner;

internal class Program
{
    static void Main(string[] args)
    {
        Lab5b();
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
    
    static void Lab5b()
    {
        try
        {
            // Test tworzenia map
            SmallSquareMap map = new SmallSquareMap(10,15);
            Console.WriteLine($"Map stworzona o rozmiarze: {map.SizeX} {map.SizeY}");

            // Test Exist()
            Point inside = new Point(5, 5);
            Point outside = new Point(-1, 10);
            Console.WriteLine($"Punkt {inside} istnieje: {map.Exist(inside)}");  // True
            Console.WriteLine($"Punkt {outside} istnieje: {map.Exist(outside)}"); // False

            // Test Next()
            Point start = new Point(9, 9);
            Point next = map.Next(start, Direction.Right);
            Console.WriteLine($"Nastepny punkt z {start} w prawo: {next}");  // Powinien byc (9,9), wyszedl poza krawedzie

            // Test NextDiagonal()
            Point diagonalStart = new Point(4, 4);
            Point diagonalNext = map.NextDiagonal(diagonalStart, Direction.Up);
            Console.WriteLine($"Nastepny punkt po skosie z {diagonalStart} w gore: {diagonalNext}");

            // Próba stworzenia mapy z niepoprawnym rozmiarem
            SmallSquareMap invalidMap = new SmallSquareMap(25,22); // Powinien rzucić wyjątek
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

}

