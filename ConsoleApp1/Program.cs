using ConsoleApp1.GenAttribute;
using ConsoleApp1.Utils;
using Scriban;
using System.Reflection;






var type = AssemblyTypeUtil.GetTypeByClassName("SysTest");
var genClass = type.GetCustomAttribute<GenClassConfigurationAttribute>();
var props = type.GetProperties();
foreach (var prop in props)
{
    var propAttr = prop.GetCustomAttribute<GenPropConfigurationAttribute>();
    genClass.Props.Add(propAttr);
    if (propAttr.IsPk)
    {
        genClass.PkProp = propAttr;
    }
}

var templateContext = ScribanUtils.PrepareContext(genClass);

List<string> templatePaths = new List<string>()
{
    @"./tpls/csharp/service.scriban"
};

Dictionary<string, string> dataMap = new();



foreach (var templatePath in templatePaths)
{
    var readPath = Path.Combine(@"C:\Users\60474\source\repos\CodeGen\ConsoleApp1", templatePath);
    var template = Template.Parse(System.IO.File.ReadAllText(readPath, System.Text.Encoding.UTF8), readPath);
    var result = template.Render(templateContext);
    dataMap.Add(templatePath, result);
}


Console.WriteLine(dataMap);




foreach (var map in dataMap)
{
    var name = Path.GetFileName(map.Key);
    var writePath = Path.Combine(@"C:\Users\60474\source\repos\CodeGen\ConsoleApp1", $"results/csharp/{name}.txt");
    File.WriteAllText(writePath, map.Value);
}
