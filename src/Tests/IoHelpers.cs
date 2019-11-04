using System.IO;

static class IoHelpers
{
    public static void PurgeDirectory(string directory)
    {
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
            return;
        }

        var root = new DirectoryInfo(directory);

        foreach (var file in root.GetFiles("*.*", SearchOption.AllDirectories))
        {
            file.Delete();
        }
    }
}