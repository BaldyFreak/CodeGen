using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Utils
{
    public static class AssemblyTypeUtil
    {
        public static Type GetTypeByClassName(string className)
        {
            return Assembly.GetExecutingAssembly().GetTypes().Where(x => x.Name == className).FirstOrDefault();
        }
    }
}
