using ConsoleApp1.GenAttribute;
using EasyTool;
using Scriban;
using Scriban.Runtime;
using System;
using System.Text;

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
                .Select(x=>$"'{x.DictType}'")
                .ToList().Aggregate((current, next) => current + "," + next);
            var scriptObject = new ScriptObject
            {
                //{ "nameSpace", GenConfiguration.nameSpace },
                //{ "moduleName", GenConfiguration.moduleName },
                //{ "dbContext", GenConfiguration.dbContext },
                //{ "genType", GenConfiguration.genType },
                //{ "genPath", GenConfiguration.genPath },
                { "genClass", genClass },
                {"dicts",dicts },

            };
            Func<string, string> UnCapitalize = (str) =>
            {
                var result = string.Concat(str[0].ToString().ToLower(), str.AsSpan(1));
                return result;
            };
            scriptObject.Import("uncapitalize", UnCapitalize);

            Func<string, string> ToSnakeCase = (str) =>
            {
                if (string.IsNullOrEmpty(str))
                {
                    return str;
                }
                var result = new StringBuilder();
                for (int i = 0; i < str.Length; i++)
                {
                    char c = str[i];
                    if (char.IsUpper(c))
                    {
                        if (i > 0 && str[i - 1] != '_')
                        {
                            result.Append('_');
                        }
                        result.Append(char.ToLower(c));
                    }
                    else
                    {
                        result.Append(c);
                    }
                }
                return result.ToString();
            };
            scriptObject.Import("to_snake_case", ToSnakeCase);
            context.PushGlobal(scriptObject);
            return context;
        }
    }
}
