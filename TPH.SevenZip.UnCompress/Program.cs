using TPH.SevenZip.Core;

Console.WriteLine("--------------------------***--------------------------");
Console.WriteLine("-------------------7ZIP UNZIP FILES--------------------");
Console.WriteLine("--------------------------***--------------------------");

var shellScriptPath = "./ShellScripts/unzip.sh";

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

foreach (var targetFilePath in Directory.GetFiles(targetFolderPath, "*.*", SearchOption.AllDirectories).Where(x => !x.Contains("/._") && x.EndsWith(".001")).OrderBy(x => x))
{
    var targetFileInfo = new FileInfo(targetFilePath);

    if (string.IsNullOrEmpty(destinationFolderPath))
    {
        ExecutionShellScripts.Run(shellScriptPath, targetFilePath, targetFileInfo.Directory.FullName, password);
        DeleteExtractedFiles(targetFileInfo);
    }
    else
    {
        ExecutionShellScripts.Run(shellScriptPath, targetFilePath, destinationFolderPath, password);
    }
}

Console.WriteLine("DONE!!!");

static void DeleteExtractedFiles(FileInfo fileInfo)
{
    foreach (var filePath in Directory.GetFiles(fileInfo.Directory.FullName, fileInfo.Name.Replace(".001", string.Empty) + ".*"))
    {
        var fi = new FileInfo(filePath);
        fi.Delete();
    }
}