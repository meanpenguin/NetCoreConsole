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
        var publishDir = Path.GetFullPath(Path.Combine(SourceDirectory, @"..\MyConsole\bin\Release\publish"));
        Directory.Delete(publishDir, true);
        var includesDir = Path.GetFullPath(Path.Combine(SourceDirectory, @"..\includes"));
        Directory.CreateDirectory(includesDir);
        var dictionary = new Dictionary<string, string>
        {
            {"Default", "Default"},
            {"DefaultTrimmed", "Default Trimmed"},
            {"Fdd", "Framework Dependent"},
            {"SingleExe", "Single Exe"},
            {"SingleExeFdd", "Single Exe and Framework Dependent"}
        };
        foreach (var profile in dictionary)
        {
            var output = DotnetStarter.StartDotNet($@"publish {project} -c Release /p:PublishProfile={profile.Key}");
            WriteLine(output);
            Assert.True(Directory.Exists(Path.Combine(publishDir, profile.Key)));
        }
        foreach (var profile in dictionary)
        {
            var profileDir = Path.GetFullPath(Path.Combine(publishDir, profile.Key));
            var includeFile = Path.GetFullPath(Path.Combine(includesDir, profile.Key+".include.md"));
            File.Delete(includeFile);
            var files = Directory.GetFiles(profileDir);
            var size = ByteSize.FromBytes(files.Sum(t => (new FileInfo(t).Length)));
            File.WriteAllText(includeFile, $@"
 * Files: {files.Length}
 * Size: {size.ToString()}");
        }
    }
}