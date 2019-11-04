using System;
using NodaTime;

class Program
{
    static void Main()
    {
        Console.WriteLine("Hello World!");
        Console.WriteLine("Hello from dependency (NodaTime): " + DateTimeZone.Utc);
    }
}