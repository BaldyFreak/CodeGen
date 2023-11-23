using ConsoleApp1.GenAttribute;

namespace ConsoleApp1.Entities
{


    /**
     * [input textarea] [ select radio checkbox] datetime [imageUpload fileUpload] editor
     * IsPk->[]
     * IsRequired
     * IsList->[HtmlType] [DictType] (单个或组合)
     * IsInsert->[HtmlType] [DictType] (单个或组合)
     * IsQuery->[HtmlType] [DictType] [QueryType] (单个或组合)
     */
    [GenClassConfiguration(nameSpaceBase: "Garen.MultiTenant", moduleName: "Tour", dbContextName: "ApplicationDbContext", genType: "crud",
        className: "TourScenery", bussinessName: "scenery", classDescription: "景区信息")]
    public class TourScenery
    {
        [GenPropConfiguration(propType: "long", propName: "SceneryId", propDescription: "主键",
            isPk: true, isRequired: false, isInsert: false, isList: true, isQuery: false,
            queryType: "", htmlType: "input", dictType: "")]
        public long SceneryId { get; set; }

        [GenPropConfiguration(propType: "string", propName: "SceneryName", propDescription: "景区名称",
            isPk: false, isRequired: true, isInsert: true, isList: true, isQuery: true,
            queryType: "LIKE", htmlType: "input", dictType: "")]
        public string SceneryName { get; set; }

        [GenPropConfiguration(propType: "string", propName: "Intro", propDescription: "景区简介",
            isPk: false, isRequired: true, isInsert: true, isList: true, isQuery: true,
            queryType: "LIKE", htmlType: "textarea", dictType: "")]
        public string Intro { get; set; }

        [GenPropConfiguration(propType: "DateTime", propName: "EffectTime", propDescription: "有效期",
            isPk: false, isRequired: true, isInsert: true, isList: true, isQuery: true,
            queryType: "BETWEEN", htmlType: "datetime", dictType: "")]
        public DateTime EffectTime { get; set; }

        [GenPropConfiguration(propType: "string", propName: "SceneryType", propDescription: "景区类型",
            isPk: false, isRequired: true, isInsert: true, isList: true, isQuery: true,
            queryType: "==", htmlType: "select", dictType: "sys_oper_type")]
        public string SceneryType { get; set; }

        [GenPropConfiguration(propType: "string", propName: "Status", propDescription: "状态",
            isPk: false, isRequired: true, isInsert: true, isList: true, isQuery: true,
            queryType: "==", htmlType: "radio", dictType: "sys_job_status")]
        public string Status { get; set; }

        [GenPropConfiguration(propType: "string", propName: "Tags", propDescription: "标签",
            isPk: false, isRequired: true, isInsert: true, isList: true, isQuery: true,
            queryType: "==", htmlType: "checkbox", dictType: "sys_job_group")]
        public string Tags { get; set; }

        [GenPropConfiguration(propType: "string", propName: "Cover", propDescription: "景区封面",
            isPk: false, isRequired: true, isInsert: true, isList: true, isQuery: false,
            queryType: "", htmlType: "imageUpload", dictType: "")]
        public string Cover { get; set; }

        [GenPropConfiguration(propType: "string", propName: "NoticeFile", propDescription: "公告文件",
            isPk: false, isRequired: true, isInsert: true, isList: true, isQuery: false,
            queryType: "", htmlType: "fileUpload", dictType: "")]
        public string NoticeFile { get; set; }

        [GenPropConfiguration(propType: "string", propName: "Detail", propDescription: "景区详情",
            isPk: false, isRequired: true, isInsert: true, isList: true, isQuery: false,
            queryType: "", htmlType: "textarea", dictType: "")]
        public string Detail { get; set; }
    }
}
