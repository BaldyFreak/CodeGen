
using Microsoft.Build.Construction;
using Microsoft.Build.Evaluation;
using System.Reflection;

Console.WriteLine(Directory.GetCurrentDirectory());
var projectFiles = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.csproj", SearchOption.TopDirectoryOnly);
foreach (var projectFile in projectFiles)
{
    Console.WriteLine(projectFile);
}

var t  = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.Name == "SysGG").FirstOrDefault();
Console.WriteLine(t);
