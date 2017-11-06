using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;

namespace Wheny.Web
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // 在应用程序启动时运行的代码
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //移除多余的视图引擎
            for (var i = 0; i < ViewEngines.Engines.Count;)
            {
                if (ViewEngines.Engines[i] is RazorViewEngine)
                {
                    i++;
                }
                else
                {
                    ViewEngines.Engines.RemoveAt(i);
                }
            }

        }
    }
}