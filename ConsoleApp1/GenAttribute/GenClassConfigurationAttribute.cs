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
        public GenPropConfigurationAttribute PkProp { get; set; }
        public List<GenPropConfigurationAttribute> Props { get; set; } = new List<GenPropConfigurationAttribute>();
    }
}
