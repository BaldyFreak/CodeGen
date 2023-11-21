using ConsoleApp1.Entities;
using ConsoleApp1.GenAttribute;
using ConsoleApp1.Model;
using ConsoleApp1.Utils;
using Scriban;
using Scriban.Runtime;
using System.Linq;
using System.Reflection;



string nameSpace = "Garen.MultiTenant";
string moduleName = "Admin";
string genType = "CRUD";
string genPath = Directory.GetCurrentDirectory();

var templateContext = new TemplateContext()
{
    MemberRenamer = (member) => member.Name,
};
var scriptObject = new ScriptObject();

var type = AssemblyTypeUtil.GetTypeByClassName("SysUser");
var typeAttrs = type.GetCustomAttributes<GenClassConfigurationAttribute>();
GenClass genClass = new();
genClass.ClassName = type.Name;
genClass.BusinessName = type.Name.ToLower();

var props = type.GetProperties();
foreach (var prop in props)
{

    var propAttrs = prop.GetCustomAttribute<GenPropConfigurationAttribute>();

    scriptObject.Add($"{prop.Name}Attrs", propAttrs);
}


List<string> templatePaths = new List<string>()
{
    @"./tpls/csharp/domain.scriban"
};


Dictionary<string, string> dataMap = new();



templateContext.PushGlobal(scriptObject);
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
    var writePath = Path.Combine(@"C:\Users\60474\source\repos\CodeGen\ConsoleApp1", $"results/csharp/{name}.cs");
    File.WriteAllText(writePath, map.Value);
}
