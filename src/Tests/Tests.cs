using System.Collections.Generic;
using System.IO;
using System.Linq;
using ByteSizeLib;
using Xunit;
using Xunit.Abstractions;

public class Tests :
    XunitApprovalBase
{
    public Tests(ITestOutputHelper output) :
        base(output)
    {
    }

    [Fact]
    public void Test()
    {
        var project = Path.GetFullPath(Path.Combine(SourceDirectory, @"..\MyConsole\MyConsole.csproj"));
        var publishDir = Path.GetFullPath(Path.Combine(SourceDirectory, @"..\MyConsole\publish"));
        IoHelpers.PurgeDirectory(publishDir);
        var includesDir = Path.GetFullPath(Path.Combine(SourceDirectory, @"..\includes"));
        Directory.CreateDirectory(includesDir);
        var dictionary = new Dictionary<string, string>
        {
            {"Default", "Default"},
            {"Trimmed", "Trimmed"},
            {"Fdd", "Framework Dependent"},
            {"SingleFile", "Single File"},
            {"SingleFileFdd", "Single File and Framework Dependent"},
            {"SingleFileTrimmed", "Single File, Framework Dependent, and Trimmed"}
        };
        foreach (var profile in dictionary)
        {
            var output = ProcessRunner.StartDotNet("dotnet", $@"publish {project} -c Release /p:PublishProfile={profile.Key}");
            WriteLine(output);
            Assert.True(Directory.Exists(Path.Combine(publishDir, profile.Key)));
        }

        foreach (var profile in dictionary)
        {
            var profileDir = Path.GetFullPath(Path.Combine(publishDir, profile.Key));
            WriteDoco(includesDir, profile.Key, profileDir);
            var exePath = Path.Combine(profileDir, "MyConsole.exe");
            var output = ProcessRunner.StartDotNet(exePath, "");
            Assert.Contains("Hello World", output);
            Assert.Contains("SettingValue", output);
        }
    }

    static void WriteDoco(string includesDir, string profile, string profileDir)
    {
        var includeFile = Path.GetFullPath(Path.Combine(includesDir, $"{profile}.include.md"));
        File.Delete(includeFile);
        var files = Directory.GetFiles(profileDir);
        var size = ByteSize.FromBytes(files.Sum(t => (new FileInfo(t).Length)));
        File.WriteAllText(includeFile, $@"
 * Files: {files.Length}
 * Size: {size.ToString()}");
    }
}