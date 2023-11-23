using ConsoleApp1.GenAttribute;

namespace ConsoleApp1.Entities
{
    [GenClassConfiguration(nameSpaceBase: "Garen.MultiTenant", moduleName: "Tour", dbContextName: "ApplicationDbContext", genType: "crud",
        className: "TourScenery", bussinessName: "scenery", classDescription: "景区信息")]
    public class TourScenery : BaseEntity
    {
        [GenPropConfiguration(propType: "long", propName: "SceneryId", propDescription: "主键",
            isPk: true, isRequired: false, isInsert: false, isList: true, isQuery: false,
            queryType: "==", htmlType: "input", dictType: "")]
        public long SceneryId { get; set; }

        [GenPropConfiguration(propType: "string", propName: "SceneryName", propDescription: "景区名称",
            isPk: false, isRequired: true, isInsert: true, isList: true, isQuery: true,
            queryType: "==", htmlType: "input", dictType: "")]
        public string SceneryName { get; set; }

        [GenPropConfiguration(propType: "string", propName: "SceneryType", propDescription: "景区类型",
            isPk: false, isRequired: true, isInsert: true, isList: true, isQuery: true,
            queryType: "==", htmlType: "select", dictType: "tour_scenery_type")]
        public string SceneryType { get; set; }

        [GenPropConfiguration(propType: "string", propName: "Cover", propDescription: "景区封面",
            isPk: false, isRequired: true, isInsert: true, isList: true, isQuery: true,
            queryType: "==", htmlType: "imageUpload", dictType: "")]
        public string Cover { get; set; }

        [GenPropConfiguration(propType: "string", propName: "Notice", propDescription: "景区公告",
            isPk: false, isRequired: true, isInsert: true, isList: true, isQuery: true,
            queryType: "==", htmlType: "fileUpload", dictType: "")]
        public string Notice { get; set; }

        [GenPropConfiguration(propType: "string", propName: "Intro", propDescription: "景区详情",
            isPk: false, isRequired: true, isInsert: true, isList: true, isQuery: true,
            queryType: "==", htmlType: "editor", dictType: "")]
        public string Intro { get; set; }


    }
}
