using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class GenConfiguration
    {
        public static string className = "SysTest";
        public static string dbContext = "ApplicationDbContext";
        public static string nameSpace = "ConsoleApp1";
        public static string moduleName = "Admin";
        public static string genType = "crud";
        public static string genPath = Directory.GetCurrentDirectory();
    }
}
