using _17MinApp.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace _17MinApp
{
    public static class WebApiRegister
    {
        public static void Register(HttpConfiguration config)
        {
            config.Services.Replace(typeof(IHttpControllerSelector), new NamespaceHttpControllerSelector(config));

            config.Routes.MapHttpRoute(
                        "WebApi",
                       "api/{controller}/{action}/{id}",
                       new
                       {
                           id = RouteParameter.Optional,
                           namespaceName = new string[] { string.Format("_17MinApp.Controllers.API") }
                       }
                       );
        }
    }
}
