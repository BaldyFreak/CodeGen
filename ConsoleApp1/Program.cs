using ConsoleApp1.GenAttribute;
using ConsoleApp1.Utils;
using EasyTool;
using Scriban;
using System.Reflection;

var rootPath = Path.Combine(Assembly.GetExecutingAssembly().Location, @"../../../../");

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
    @"./tpls/csharp/service.scriban",
    @"./tpls/csharp/specification.scriban",
    @"./tpls/csharp/controller.scriban",
    @"./tpls/csharp/api.scriban",
    @"./tpls/csharp/test.vue.scriban",
    @"./tpls/csharp/test.scriban",
};

Dictionary<string, string> dataMap = new();



foreach (var templatePath in templatePaths)
{
    var readPath = Path.Combine(rootPath, templatePath);
    var template = Template.Parse(System.IO.File.ReadAllText(readPath, System.Text.Encoding.UTF8), readPath);
    var result = template.Render(templateContext);
    dataMap.Add(templatePath, result);
}


Console.WriteLine(dataMap);




foreach (var map in dataMap)
{
    var name = Path.GetFileName(map.Key);
    var writePath = Path.Combine(rootPath, $"results/csharp/{name}.txt");
    File.WriteAllText(writePath, map.Value);
}
