using ConsoleApp1;
using Scriban;
using Scriban.Runtime;
using System.Linq;
using System.Reflection;

var templateContext = new TemplateContext()
{
    MemberRenamer = (member) => member.Name,
};
var scriptObject = new ScriptObject();

var type = typeof(SysUser);
var typeAttrs = type.GetCustomAttributes<EntityTypeAttribute>();

scriptObject.Add("Type", type);
scriptObject.Add($"TypeAttrs", typeAttrs);

var props = type.GetProperties();
scriptObject.Add($"Props", props);
//foreach (var prop in props)
//{
//    var propAttrs = prop.GetCustomAttributes<EntityPropertyAttribute>().ToList();

//    scriptObject.Add($"{prop.Name}Attrs", propAttrs);
//}


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
