using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    [EntityType("crud","ConsoleApp1","system","user","系统角色表")]
    public class SysUser:BaseEntity
    {
        [EntityProperty(true,true)]
        public long UserId { get; set; }
        [EntityProperty]
        public string? UserName { get; set; }
        [EntityProperty]
        public string? Password { get; set; }
    }
}
