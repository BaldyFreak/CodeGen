using EasyTool;

namespace ConsoleApp1.GenAttribute
{
    public class GenClassConfigurationAttribute : Attribute
    {
        public GenClassConfigurationAttribute()
        {

        }
        public GenClassConfigurationAttribute(
            string nameSpaceBase,
            string moduleName,
            string dbContextName,
            string genType,
            string className,
            string bussinessName,
            string classDescription)
        {
            NameSpaceBase = nameSpaceBase;
            ModuleName = moduleName;
            DbContextName = dbContextName;
            GenType = genType;
            ClassName = className;
            BusinessName = bussinessName;
            ClassDescription = classDescription;
        }
        public string NameSpaceBase { get; set; }
        public string ModuleName { get; set; }
        public string DbContextName { get; set; }
        public string GenType { get; set; }
        public string ClassName { get; set; }
        public string BusinessName { get; set; }
        public string ClassDescription { get; set; }
        public GenPropConfigurationAttribute PkProp { get; set; }
        public List<GenPropConfigurationAttribute> Props { get; set; } = new List<GenPropConfigurationAttribute>();
    }
}
