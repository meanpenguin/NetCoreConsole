using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Hello World!");
        Console.WriteLine("Hello from dependency (NodaTime): " + NodaTime.DateTimeZone.Utc);
        Console.ReadKey();
    }
}