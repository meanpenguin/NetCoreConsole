using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
    }
}