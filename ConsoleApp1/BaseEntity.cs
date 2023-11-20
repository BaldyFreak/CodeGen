using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class BaseEntity
    {
        [EntityProperty]
        public string? CreateBy { get; set; }
        [EntityProperty]
        public string? UpdateBy { get; set; }
        [EntityProperty]
        public DateTime CreateTime { get; set; }
        [EntityProperty]
        public DateTime UpdateTime { get; set; }
        public int PageNum { get; set; }
        public int PageSize { get; set; }
    }
}
