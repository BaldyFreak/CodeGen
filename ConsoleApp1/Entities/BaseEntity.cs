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
        [GenPropConfiguration(propType: "string", propName: "CreateBy", propDescription: "创建者", isPk: false, isIncrement: false, isRequired: false,
            isInsert: false, isEdit: false, isList: true, isQuery: false, queryType: "==", htmlType: "input", dictType: "")]
        public string CreateBy { get; set; }


        [GenPropConfiguration(propType: "string", propName: "UpdateBy", propDescription: "更新者", isPk: false, isIncrement: false, isRequired: false,
            isInsert: false, isEdit: false, isList: false, isQuery: false, queryType: "==", htmlType: "input", dictType: "")]
        public string UpdateBy { get; set; }


        [GenPropConfiguration(propType: "DateTime", propName: "CreateTime", propDescription: "创建时间", isPk: false, isIncrement: false, isRequired: false,
            isInsert: false, isEdit: false, isList: true, isQuery: true, queryType: "==", htmlType: "date-picker", dictType: "")]
        public DateTime CreateTime { get; set; }

        [GenPropConfiguration(propType: "DateTime", propName: "UpdateTime", propDescription: "更新时间", isPk: false, isIncrement: false, isRequired: false,
            isInsert: false, isEdit: false, isList: false, isQuery: false, queryType: "EQ", htmlType: "date-picker", dictType: "")]
        public DateTime UpdateTime { get; set; }

        [GenPropConfiguration(propType: "string", propName: "Remark", propDescription: "备注", isPk: false, isIncrement: false, isRequired: false,
            isInsert: true, isEdit: false, isList: false, isQuery: false, queryType: "EQ", htmlType: "input", dictType: "")]
        public string Remark { get; set; }
    }
}
