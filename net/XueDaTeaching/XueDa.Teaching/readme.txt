### ���ݿ�
SqlSugar��http://www.codeisbug.com/
Nuget��װ��Install-Package sqlSugar 

###
API�ӿڲ��Թ��� - WebApiTestClientʹ��--Nuget���������  A Simple Test Client for ASP.NET Web API
Api.cshtml�ļ���ӣ�
@Html.DisplayForModel("TestClientDialogs")
@section Scripts{
    <link href="~/Areas/HelpPage/HelpPage.css" rel="stylesheet" />
    @Html.DisplayForModel("TestClientReferences")
}

��Ŀ������Ҽ������ԡ����ɱ�ǩҳ����xml��·��

config.SetDocumentationProvider(new XmlDocumentationProvider(HttpContext.Current.Server.MapPath("~/App_Data/WebApiTestClient.XML")));