using ConsoleApp1.GenAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Entities
{
    public class BaseEntity
    {
        [GenPropConfiguration(propType: "string", propName: "CreateBy", propDescription: "创建者",
            isPk: false, isRequired: false, isInsert: false, isList: false, isQuery: false,
            queryType: "==", htmlType: "", dictType: "")]
        public string CreateBy { get; set; }


        [GenPropConfiguration(propType: "string", propName: "UpdateBy", propDescription: "更新者",
            isPk: false, isRequired: false, isInsert: false, isList: false, isQuery: false,
            queryType: "==", htmlType: "", dictType: "")]
        public string UpdateBy { get; set; }


        [GenPropConfiguration(propType: "DateTime", propName: "CreateTime", propDescription: "创建时间",
            isPk: false, isRequired: false, isInsert: false, isList: false, isQuery: false,
            queryType: "==", htmlType: "", dictType: "")]
        public DateTime CreateTime { get; set; }

        [GenPropConfiguration(propType: "DateTime", propName: "UpdateTime", propDescription: "更新时间",
            isPk: false, isRequired: false, isInsert: false, isList: false, isQuery: false,
            queryType: "==", htmlType: "", dictType: "")]
        public DateTime UpdateTime { get; set; }

        [GenPropConfiguration(propType: "string", propName: "Remark", propDescription: "备注",
            isPk: false, isRequired: false, isInsert: true, isList: false, isQuery: false,
            queryType: "==", htmlType: "textarea", dictType: "")]
        public string Remark { get; set; }
    }
}
