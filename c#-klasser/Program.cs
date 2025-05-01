using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("=== Välj uppgift att köra ===");
        Console.WriteLine("1 - Cirkel");
        Console.WriteLine("2 - Kalkylator (två tal)");
        Console.WriteLine("3 - Studenthantering");
        Console.Write("Ditt val: ");
        string val = Console.ReadLine();

        switch (val)
        {
            case "1": Uppgift1(); break;
            case "2": Uppgift2(); break;
            case "3": Uppgift3(); break;
            default: Console.WriteLine("Ogiltigt val."); break;
        }
    }

    static void Uppgift1()
    {
        Console.WriteLine("=== Uppgift 1: Cirkel ===");
        Cirkel minCirkel = new Cirkel(5.0);
        Console.WriteLine($"Radie: {minCirkel.Radie}");
        Console.WriteLine($"Area: {minCirkel.BeräknaArea()}");
        Console.WriteLine($"Omkrets: {minCirkel.BeräknaOmkrets()}");
    }

    static void Uppgift2()
    {
        Console.WriteLine("=== Uppgift 2: Kalkylator ===");
        Console.Write("Skriv tal 1: ");
        double tal1 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Skriv tal 2: ");
        double tal2 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Välj operation (+, -, *, /): ");
        string op = Console.ReadLine();

        Kalkylator k = new Kalkylator(tal1, tal2);

        switch (op)
        {
            case "+": Console.WriteLine($"Resultat: {k.Add()}"); break;
            case "-": Console.WriteLine($"Resultat: {k.Sub()}"); break;
            case "*": Console.WriteLine($"Resultat: {k.Mul()}"); break;
            case "/": Console.WriteLine($"Resultat: {k.Div()}"); break;
            default: Console.WriteLine("Ogiltig operation."); break;
        }
    }

    static void Uppgift3()
    {
        Console.WriteLine("=== Uppgift 3: Studenter ===");

        List<Student> elever = new List<Student>();
        string[] betyg = { "A", "B", "C", "D", "E", "F" };
        Random rnd = new Random();

        for (int i = 0; i < 10; i++)
        {
            var s = new Student($"Elev{i+1}", $"Efternamn{i+1}", new DateTime(2000 + rnd.Next(0, 10), 1, 1));
            for (int j = 0; j < 5; j++)
            {
                s.SättBetyg($"Ämne{j+1}", betyg[rnd.Next(betyg.Length)]);
            }
            elever.Add(s);
        }

        Student bästa = elever.OrderByDescending(e => e.TotalPoäng()).First();
        Student sämsta = elever.OrderBy(e => e.TotalPoäng()).First();

        Console.WriteLine($"\nBästa elev: {bästa.Förnamn} {bästa.Efternamn}, Totalpoäng: {bästa.TotalPoäng()}");
        Console.WriteLine($"Sämsta elev: {sämsta.Förnamn} {sämsta.Efternamn}, Totalpoäng: {sämsta.TotalPoäng()}");

        var myndiga = elever.Where(e => e.ÄrMyndig()).ToList();
        Console.WriteLine($"\nAntal myndiga elever: {myndiga.Count}");
        foreach (var e in myndiga)
        {
            Console.WriteLine($"{e.Förnamn} {e.Efternamn}");
        }
    }
}

// === Klass för Uppgift 1 ===
public class Cirkel
{
    private double radie;
    public double Radie => radie;

    public Cirkel(double radie)
    {
        this.radie = radie;
    }

    public double BeräknaArea() => Math.PI * radie * radie;
    public double BeräknaOmkrets() => 2 * Math.PI * radie;
}

// === Klass för Uppgift 2 ===
public class Kalkylator
{
    private double tal1, tal2;

    public Kalkylator(double t1, double t2)
    {
        tal1 = t1;
        tal2 = t2;
    }

    public double Add() => tal1 + tal2;
    public double Sub() => tal1 - tal2;
    public double Mul() => tal1 * tal2;
    public double Div() => tal2 != 0 ? tal1 / tal2 : throw new DivideByZeroException();
}

// === Klass för Uppgift 3 ===
public class Student
{
    public string Förnamn { get; set; }
    public string Efternamn { get; set; }
    public DateTime Födelsedatum { get; set; }
    private Dictionary<string, string> betyg = new Dictionary<string, string>();

    public Student(string förnamn, string efternamn, DateTime födelsedatum)
    {
        Förnamn = förnamn;
        Efternamn = efternamn;
        Födelsedatum = födelsedatum;
    }

    public bool ÄrMyndig() => (DateTime.Now - Födelsedatum).TotalDays >= 18 * 365;

    public void SättBetyg(string ämne, string bokstav)
    {
        betyg[ämne] = bokstav.ToUpper();
    }

    public int TotalPoäng()
    {
        int summa = 0;
        foreach (var b in betyg.Values)
        {
            summa += BetygTillPoäng(b);
        }
        return summa;
    }

    private int BetygTillPoäng(string b)
    {
        return b switch
        {
            "A" => 250,
            "B" => 200,
            "C" => 150,
            "D" => 100,
            "E" => 50,
            _ => 0
        };
    }
} 
