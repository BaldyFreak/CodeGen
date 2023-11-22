using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.GenAttribute
{
    public class GenPropConfigurationAttribute : Attribute
    {
        //public GenPropConfigurationAttribute(
        //    string propType,
        //    string propName,
        //    string propDescription,
        //    bool isPk =false
        //    )
        //{
        //    PropType = propType;
        //    PropName = propName;
        //    PropDescription = propDescription;
        //    IsPk = isPk;
        //}
        public GenPropConfigurationAttribute(
            string propType,
            string propName,
            string propDescription,
            bool isPk = false,
            bool isIncrement = false,
            bool isRequired = false,
            bool isInsert = false,
            bool isEdit = false,
            bool isList = true,
            bool isQuery = false,
            string queryType = "==",
            string htmlType ="input",
            string dictType = ""
            )
        {
            PropType = propType;
            PropName = propName;
            PropDescription = propDescription;
            IsPk = isPk;
            IsIncrement = isIncrement;
            IsRequired = isRequired;
            IsInsert = isInsert;
            IsEdit = isEdit;
            IsList = isList;
            IsQuery = isQuery;
            QueryType = queryType;
            HtmlType = htmlType;
            DictType = dictType;
        }
        public string PropType { get; set; }
        public string PropName { get; set; }
        public string PropDescription { get; set; }
        public bool IsPk { get; set; } = false;
        public bool IsIncrement { get; set; } = false;
        public bool IsRequired { get; set; } = false;//负责vue中表单rules校验
        public bool IsInsert { get; set; } = true;//负责新增或者编辑模态框中的字段显示隐藏
        public bool IsEdit { get; set; } = true;
        public bool IsList { get; set; } = true;//负责table组件中控制是否展示
        public bool IsQuery { get; set; } = true;//负责form搜索组件中空值是否查询
        public string QueryType { get; set; } = "==";
        public string HtmlType { get; set; } = "input";
        public string DictType { get; set; } = string.Empty;
    }
}
