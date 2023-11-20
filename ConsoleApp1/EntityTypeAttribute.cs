using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class EntityTypeAttribute : Attribute
    {
        public EntityTypeAttribute()
        {

        }
        public EntityTypeAttribute(string genType, string nameSpace, string moduleName, string businessName, string functionName)
        {
            GenType = genType;
            NameSpace = nameSpace;
            ModuleName = moduleName;
            BusinessName = businessName;
            FunctionName = functionName;
        }
        public string? GenType { get; set; }
        public string? NameSpace { get; set; }
        public string? ModuleName { get; set; }
        public string? BusinessName { get; set; }
        public string? FunctionName { get; set; }
    }
}
