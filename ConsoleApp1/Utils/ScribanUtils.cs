using ConsoleApp1.GenAttribute;
using EasyTool;
using Scriban;
using Scriban.Runtime;
using System;

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
            string dicts = genClass.Props
                .Where(x => !string.IsNullOrEmpty(x.DictType))
                .Where(x => new List<string> { "select", "radio", "checkbox" }.Contains(x.HtmlType))
                .Select(x=>x.DictType)
                .ToList().Aggregate((current, next) => current + "," + next);
            var scriptObject = new ScriptObject
            {
                //{ "nameSpace", GenConfiguration.nameSpace },
                //{ "moduleName", GenConfiguration.moduleName },
                //{ "dbContext", GenConfiguration.dbContext },
                //{ "genType", GenConfiguration.genType },
                //{ "genPath", GenConfiguration.genPath },
                //{ "genClass", genClass },
                {"dicts",dicts },

            };
            Func<string, string> UnCapitalize = (str) =>
            {
                var result = string.Concat(str[0].ToString().ToLower(), str.AsSpan(1));
                return result;
            };
            scriptObject.Import("uncapitalize", UnCapitalize);
            context.PushGlobal(scriptObject);
            return context;
        }
    }
}
