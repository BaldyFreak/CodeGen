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
    @"./tpls/Service.cs.scriban",
    @"./tpls/Specification.cs.scriban",
    @"./tpls/Controller.cs.scriban",
    @"./tpls/api.js.scriban",
    @"./tpls/index.vue.scriban",
};

Dictionary<string, string> dataMap = new();



foreach (var templatePath in templatePaths)
{
    var readPath = Path.Combine(rootPath, templatePath);
    var template = Template.Parse(System.IO.File.ReadAllText(readPath, System.Text.Encoding.UTF8), readPath);
    var result = template.Render(templateContext);
    dataMap.Add(templatePath, result);
}






foreach (var map in dataMap)
{
    var fullName = Path.GetFileNameWithoutExtension(map.Key);
    var name = Path.GetFileNameWithoutExtension(fullName);
    var extension = Path.GetExtension(fullName);
    string outPutName;
    if (new List<string> { "Service","Controller","Specification"}.Contains(name))
    {
        outPutName = GenConfiguration.className+ name;
    }
    else
    {
        outPutName = name;
    }
    var writePath = Path.Combine(@"C:\Users\60474\Desktop\genDownload", $"{outPutName}{extension}");
    File.WriteAllText(writePath, map.Value);
}

Console.WriteLine("生成成功");

