using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Model
{
    public class GenClass
    {
        public string ClassName { get; set; }
        public string BusinessName { get; set; }
        public string ClassDescription { get; set; }
        public GenProp PkColumn { get; set; } = new GenProp();
        public List<GenProp> Columns { get; set; } = new List<GenProp>();
    }
}
