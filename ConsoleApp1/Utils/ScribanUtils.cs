using ConsoleApp1.GenAttribute;
using Scriban;
using Scriban.Runtime;

namespace ConsoleApp1.Utils
{
    public static class ScribanUtils
    {
        public static TemplateContext Init()
        {
            return new TemplateContext()
            {
                MemberRenamer = (member) => { return member.Name; }
            };
        }
        public static TemplateContext PrepareContext(GenClassConfigurationAttribute genClass)
        {
            var context = new TemplateContext()
            {
                MemberRenamer = (member) =>
                {
                    return member.Name;
                }
            };
            string nameSpace = "Garen.MultiTenant";
            string moduleName = "Admin";
            string genType = "CRUD";
            string genPath = Directory.GetCurrentDirectory();
            string dbContext = "ApplicationDbContext";
            var scriptObject = new ScriptObject
            {
                { "nameSpace", nameSpace },
                { "moduleName", moduleName },
                { "genType", genType },
                { "genPath", genPath },
                { "dbContext", dbContext },
                { "genClass", genClass },

            };
            context.PushGlobal(scriptObject);
            return context;
        }
    }
}
