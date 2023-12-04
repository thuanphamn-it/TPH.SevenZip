using TPH.SevenZip.Core;


var shellScriptPath = "./ShellScripts/zip.sh";

Console.WriteLine("--------------------------***--------------------------");
Console.WriteLine("----------------------7ZIP FILES-----------------------");
Console.WriteLine("--------------------------***--------------------------");
Console.Write("Enter target folder path: ");
var targetFolderPath = Console.ReadLine();

if (string.IsNullOrEmpty(targetFolderPath))
{
    throw new Exception($"{nameof(targetFolderPath)} is required");
}

Console.Write("Enter destination folder path: ");
var destinationFolderPath = Console.ReadLine();

Console.Write("Password: ");
var password = Console.ReadLine();

if (string.IsNullOrEmpty(password))
{
    throw new Exception($"{nameof(password)} is required");
}

if (!Directory.Exists(targetFolderPath))
{
    throw new Exception($"Directory {targetFolderPath} is not existed!");
}

foreach (var targetFilePath in Directory.GetFiles(targetFolderPath, "*.*", SearchOption.AllDirectories).Where(x => !x.Contains("/._") &&
        (x.EndsWith(".mp4", StringComparison.CurrentCultureIgnoreCase)
            || x.EndsWith(".mkv", StringComparison.CurrentCultureIgnoreCase)
            || x.EndsWith(".wmv", StringComparison.CurrentCultureIgnoreCase)
            || x.EndsWith(".ts", StringComparison.CurrentCultureIgnoreCase)
        )
    ).OrderBy(x => x))
{
    var destinationFilePath = string.Empty;
    if (!string.IsNullOrEmpty(destinationFolderPath))
    {
        destinationFilePath = Path.Combine(destinationFolderPath, Guid.NewGuid().ToString());
    }
    else
    {
        destinationFilePath = Path.Combine(targetFilePath, Guid.NewGuid().ToString());
    }

    ExecutionShellScripts.Run(shellScriptPath, targetFilePath, destinationFilePath, password);
    MarkFileDone(targetFilePath);
}

Console.WriteLine("DONE!!!");

static void MarkFileDone(string targetFilePath)
{
    var fileInfo = new FileInfo(targetFilePath);
    fileInfo.MoveTo(targetFilePath + ".done");
}