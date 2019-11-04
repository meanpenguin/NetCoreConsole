using System;
using System.Configuration;
using System.IO;
using NodaTime;

class Program
{
    static void Main()
    {
        Console.WriteLine("Hello World!");

        Console.WriteLine($"Hello from dependency (NodaTime): {DateTimeZone.Utc}");

        var settingsValue = ConfigurationManager.AppSettings.Get("SettingKey");
        if (settingsValue == null)
        {
            throw new Exception("No Settings");
        }
        Console.WriteLine(settingsValue);

        var contentFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory!, "ContentFile.txt");
        Console.WriteLine(contentFilePath);
        if (!File.Exists(contentFilePath))
        {
            throw new Exception($"No content file: {contentFilePath}");
        }
        Console.WriteLine(File.ReadAllText(contentFilePath));
    }
}