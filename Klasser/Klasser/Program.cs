using System;

class Cirkel
{
    // Fält
    private double radie;

    // Konstruktor
    public Cirkel(double radie)
    {
        this.radie = radie;
    }

    // Metod för att beräkna omkrets
    public double BeraknaOmkrets()
    {
        return 2 * Math.PI * radie;
    }

    // Metod för att beräkna area
    public double BeraknaArea()
    {
        return Math.PI * radie * radie;
    }

    // Metod för att skriva ut cirkelns information
    public void SkrivUtInfo()
    {
        Console.WriteLine("Radie: " + radie);
        Console.WriteLine("Omkrets: " + BeraknaOmkrets());
        Console.WriteLine("Area: " + BeraknaArea());
    }
}

class Program
{
    static void Main()
    {
        // Skapa ett objekt av Cirkel-klassen med radie 5
        Cirkel minCirkel = new Cirkel(5);

        // Testa metoderna och skriv ut cirkelns information
        minCirkel.SkrivUtInfo();
    }
}
