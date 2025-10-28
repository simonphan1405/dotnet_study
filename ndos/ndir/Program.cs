var path = "/Users/hieuphan/Documents/web-development/references/minio_samples";

var directoriesInfo = new DirectoryInfo(path);
var directories = directoriesInfo.GetDirectories();

foreach (var dir in directories)
{
    Console.WriteLine($"{dir.LastWriteTime.ToString("MM/dd/yyy")} {dir.LastWriteTime.ToString("HH:mm")}   <DIR>   {dir.Name}");
}

var files = directoriesInfo.GetFiles();
foreach (var file in files)
{
    Console.WriteLine($"{file.LastWriteTime.ToString("MM/dd/yyy")} {file.LastWriteTime.ToString("HH:mm")}           {file.Length,10}    {file.Name}");
}