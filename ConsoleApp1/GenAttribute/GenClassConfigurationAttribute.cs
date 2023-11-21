using ConsoleApp1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.GenAttribute
{
    public class GenClassConfigurationAttribute : Attribute
    {
        public GenClassConfigurationAttribute()
        {

        }
        public GenClassConfigurationAttribute(string className, string bussinessName, string classDescription)
        {
            ClassName = className;
            BusinessName = bussinessName;
            ClassDescription = classDescription;
        }
        public string ClassName { get; set; }
        public string BusinessName { get; set; }
        public string ClassDescription { get; set; }
        public GenProp PkColumn { get; set; } = new GenProp();
        public List<GenProp> Columns { get; set; } = new List<GenProp>();
    }
}
