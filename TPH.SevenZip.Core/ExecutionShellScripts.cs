namespace TPH.SevenZip.Core;

using System.Diagnostics;
using System.Text;

public static class ExecutionShellScripts
{
    public static void Run(string shellScriptPath, params string[] args)
    {
        var processStartInfo = new ProcessStartInfo();
        processStartInfo.FileName = shellScriptPath;
        foreach (var arg in args)
        {
            processStartInfo.ArgumentList.Add(arg);
        }

        var process = Process.Start(processStartInfo);
        process.WaitForExit();
    }

    
}
