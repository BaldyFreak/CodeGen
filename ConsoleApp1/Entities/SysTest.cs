using ConsoleApp1.GenAttribute;

namespace ConsoleApp1.Entities
{
    [GenClassConfiguration(className: "SysTest", bussinessName: "test", classDescription: "系统测试")]
    public class SysTest : BaseEntity
    {
        [GenPropConfiguration(propType: "long", propName: "TestId", propDescription: "主键", isPk: true, isIncrement: true, isRequired: false,
            isInsert: false, isEdit: false, isList: true, isQuery: true, queryType: "==", htmlType: "input", dictType: "")]
        public long TestId { get; set; }

        [GenPropConfiguration(propType: "string", propName: "TestName", propDescription: "测试名", isPk: false, isIncrement: false, isRequired: true,
            isInsert: true, isEdit: true, isList: true, isQuery: true, queryType: "==", htmlType: "input", dictType: "")]
        public string TestName { get; set; }

        [GenPropConfiguration(propType: "string", propName: "Password", propDescription: "密码", isPk: false, isIncrement: false, isRequired: true,
            isInsert: true, isEdit: false, isList: false, isQuery: false, queryType: "==", htmlType: "input", dictType: "")]
        public string Password { get; set; }

        [GenPropConfiguration(propType: "DateTime", propName: "OutDate", propDescription: "过期时间", isPk: false, isIncrement: false, isRequired: false,
            isInsert: false, isEdit: false, isList: true, isQuery: true, queryType: "BETWEEN", htmlType: "datetime", dictType: "")]
        public DateTime OutDate { get; set; }

        [GenPropConfiguration(propType: "string", propName: "AvatarUrl", propDescription: "头像地址", isPk: false, isIncrement: false, isRequired: true,
            isInsert: true, isEdit: true, isList: true, isQuery: false, queryType: "==", htmlType: "imageUpload", dictType: "")]
        public string AvatarUrl { get; set; }

        [GenPropConfiguration(propType: "string", propName: "Gender", propDescription: "性别", isPk: false, isIncrement: false, isRequired: true,
            isInsert: true, isEdit: true, isList: true, isQuery: true, queryType: "==", htmlType: "select", dictType: "sys_user_sex")]
        public string Gender { get; set; }

    }
}
