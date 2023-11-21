using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Model
{
    public class GenProp
    {
        public string PropType { get; set; }
        public string PropName { get; set; }
        public string PropDescription { get; set; }

        public bool IsPk { get; set; } = false;
        public bool IsIncrement { get; set; } = false;
        public bool IsRequired { get; set; } = true;
        public bool IsInsert { get; set; } = true;
        public bool IsEdit { get; set; } = true;
        public bool IsList { get; set; } = true;
        public bool IsQuery { get; set; } = true;
        public string QueryType { get; set; } = "EQ";
        public string HtmlType { get; set; } = "input";
        public string DictType { get; set; }
    }
}
