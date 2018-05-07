### 数据库
SqlSugar：http://www.codeisbug.com/
Nuget安装：Install-Package sqlSugar 

###
API接口测试工具 - WebApiTestClient使用--Nuget引入组件：  A Simple Test Client for ASP.NET Web API
Api.cshtml文件添加：
@Html.DisplayForModel("TestClientDialogs")
@section Scripts{
    <link href="~/Areas/HelpPage/HelpPage.css" rel="stylesheet" />
    @Html.DisplayForModel("TestClientReferences")
}

项目上面点右键→属性→生成标签页配置xml的路径

config.SetDocumentationProvider(new XmlDocumentationProvider(HttpContext.Current.Server.MapPath("~/App_Data/WebApiTestClient.XML")));