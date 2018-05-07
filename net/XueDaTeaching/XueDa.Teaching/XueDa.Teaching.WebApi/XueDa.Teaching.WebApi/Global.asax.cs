using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace XueDa.Teaching.WebApi
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            // 使api返回为json (可用webapiconfig配置方法)
            //GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
            var format = GlobalConfiguration.Configuration.Formatters;
            //format.JsonFormatter.SerializerSettings.DateFormatString = "yyyy.MM.dd";
            //format.JsonFormatter.SerializerSettings = new Newtonsoft.Json.JsonSerializerSettings {  
            //    DateFormatString = "d MMMM, yyyy HH:mm:ss",  
            //    Formatting = Formatting.Indented  
            //}
            //清除默认xml

             format.XmlFormatter.SupportedMediaTypes.Clear();

             //通过参数设置返回格式 url地址中参数名称t=json（默认）|xml
             format.JsonFormatter.MediaTypeMappings.Add(new QueryStringMapping("t", "json", "application/json"));
             format.XmlFormatter.MediaTypeMappings.Add(new QueryStringMapping("t", "xml", "application/xml"));
        }
    }
}