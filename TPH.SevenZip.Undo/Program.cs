Console.WriteLine("--------------------------***--------------------------");
Console.WriteLine("----------------------Undo FILES-----------------------");
Console.WriteLine("--------------------------***--------------------------");

Console.Write("Enter target folder path: ");
var targetFolderPath = Console.ReadLine();

if (string.IsNullOrEmpty(targetFolderPath))
{
    throw new Exception($"{nameof(targetFolderPath)} is required");
}

if (!Directory.Exists(targetFolderPath))
{
    throw new Exception($"Directory {targetFolderPath} is not existed!");
}

foreach (var targetFilePath in Directory.GetFiles(targetFolderPath).Where(x => !x.Contains("/._") && x.EndsWith(".done", StringComparison.CurrentCultureIgnoreCase)))
{
    Undo(targetFilePath);
}

Console.WriteLine("DONE!!!");

static void Undo(string targetFilePath)
{
    var fileInfo = new FileInfo(targetFilePath);
    var fileName = fileInfo.FullName.Replace(".done", string.Empty);
    Console.WriteLine($"Undoing ${fileInfo.FullName} to {fileName}");
    fileInfo.MoveTo(fileName);
}
