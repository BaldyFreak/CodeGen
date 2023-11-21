using ConsoleApp1.GenAttribute;

namespace ConsoleApp1.Entities
{
    [GenClassConfiguration(className: "SysUser", bussinessName: "user", classDescription: "系统用户")]
    public class SysUser:BaseEntity
    {
        [GenPropConfiguration(propType: "long", propName: "UserId", propDescription: "主键", isPk: true, isIncrement: true, isRequired: false,
            isInsert: false, isEdit: false, isList: true, isQuery: false, queryType: "EQ", htmlType: "input", dictType: "")]
        public long UserId { get; set; }

        [GenPropConfiguration(propType: "string", propName: "UserName", propDescription: "用户名", isPk: false, isIncrement: false, isRequired: true,
            isInsert: true, isEdit: true, isList: true, isQuery: true, queryType: "EQ", htmlType: "input", dictType: "")]
        public string UserName { get; set; }

        [GenPropConfiguration(propType: "string", propName: "Password", propDescription: "密码", isPk: false, isIncrement: false, isRequired: true,
            isInsert: true, isEdit: false, isList: false, isQuery: false, queryType: "EQ", htmlType: "input", dictType: "")]
        public string Password { get; set; }


        

    }
}
