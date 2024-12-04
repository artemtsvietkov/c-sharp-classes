using System;

class MatematiskOperation
{
    // Fält för att hålla de två talen
    private double tal1;
    private double tal2;

    // Konstruktor för att sätta värden på talen
    public MatematiskOperation(double tal1, double tal2)
    {
        this.tal1 = tal1;
        this.tal2 = tal2;
    }

    // Metod för addition
    public double Addition()
    {
        return tal1 + tal2;
    }

    // Metod för subtraktion
    public double Subtraktion()
    {
        return tal1 - tal2;
    }

    // Metod för multiplikation
    public double Multiplikation()
    {
        return tal1 * tal2;
    }

    // Metod för division
    public double Division()
    {
        if (tal2 == 0)
        {
            throw new DivideByZeroException("Division med noll är inte tillåtet.");
        }
        return tal1 / tal2;
    }
}

class Program
{
    static void Main()
    {
        // Be användaren om två tal
        Console.Write("Ange det första talet: ");
        double tal1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Ange det andra talet: ");
        double tal2 = Convert.ToDouble(Console.ReadLine());

        // Be användaren om vilken operation de vill utföra
        Console.WriteLine("Vilken operation vill du utföra? (+, -, *, /)");
        string operation = Console.ReadLine();

        // Skapa ett objekt av MatematiskOperation med de två talen
        MatematiskOperation operationObj = new MatematiskOperation(tal1, tal2);

        double resultat = 0;
        bool operationValid = true;

        // Utför den valda operationen
        switch (operation)
        {
            case "+":
                resultat = operationObj.Addition();
                break;
            case "-":
                resultat = operationObj.Subtraktion();
                break;
            case "*":
                resultat = operationObj.Multiplikation();
                break;
            case "/":
                try
                {
                    resultat = operationObj.Division();
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine(ex.Message);
                    operationValid = false;
                }
                break;
            default:
                Console.WriteLine("Ogiltig operation.");
                operationValid = false;
                break;
        }

        // Skriv ut resultatet om operationen var giltig
        if (operationValid)
        {
            Console.WriteLine($"Resultatet av {tal1} {operation} {tal2} är: {resultat}");
        }
    }
}
