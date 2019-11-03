using System;
using System.Diagnostics;

static class DotnetStarter
{
    public static string StartDotNet(string arguments)
    {
        using var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "dotnet",
                Arguments = arguments,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            }
        };
        process.Start();
        process.WaitForExit();
        if (process.ExitCode == 0)
        {
            return process.StandardOutput.ReadToEnd();
        }

        var error = process.StandardError.ReadToEnd();
        var output = process.StandardOutput.ReadToEnd();
        throw new Exception($@"Command: dotnet {arguments}
ExitCode: {process.ExitCode}
Error: {error}
Output: {output}");
    }
}