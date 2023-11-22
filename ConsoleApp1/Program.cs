using ConsoleApp1;
using ConsoleApp1.GenAttribute;
using ConsoleApp1.Utils;
using EasyTool;
using Microsoft.Extensions.Configuration;
using Scriban;
using System.Configuration;
using System.Reflection;

#region 读取命令行参数
//var keyValuePairs = new Dictionary<string, string>();
//foreach (var arg in args)
//{
//    var parts = arg.Split('=');
//    if (parts.Length == 2)
//    {
//        var key = parts[0];
//        var value = parts[1];
//        keyValuePairs[key] = value;
//    }
//}

//string className;
//keyValuePairs.TryGetValue("className", out className);
//if (!string.IsNullOrEmpty(className))
//{
//    GenConfiguration.className = className;
//}
//string dbContext;
//keyValuePairs.TryGetValue("dbContext", out dbContext);
//if (!string.IsNullOrEmpty(dbContext))
//{
//    GenConfiguration.dbContext = dbContext;
//}
//string assemblyName;
//keyValuePairs.TryGetValue("assemblyName", out assemblyName);

//if (string.IsNullOrEmpty(assemblyName))
//{
//    assemblyName = System.Reflection.Assembly.GetEntryAssembly().GetName().Name;
//    GenConfiguration.nameSpace = assemblyName;
//}
//else
//{
//    GenConfiguration.nameSpace = assemblyName;
//}
#endregion

var rootPath = Path.Combine(Assembly.GetExecutingAssembly().Location, @"../../../../");

var type = AssemblyTypeUtil.GetTypeByClassName(GenConfiguration.className);
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
    @"./tpls/csharp/service.cs.scriban",
    @"./tpls/csharp/specification.cs.scriban",
    @"./tpls/csharp/controller.cs.scriban",
    @"./tpls/csharp/api.js.scriban",
    @"./tpls/csharp/index.vue.scriban",
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
    var name = Path.GetFileNameWithoutExtension(map.Key);
    var writePath = Path.Combine(@"C:\Users\Administrator\Desktop\test", $"{name}");
    File.WriteAllText(writePath, map.Value);
}
