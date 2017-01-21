using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _17MinApp
{
    public class WebErrorFilter : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {

            var log = LogManager.GetLogger("log4netlogger");

            var errorMessage = new System.Text.StringBuilder();
            if (HttpContext.Current != null)
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                    errorMessage.AppendLine(HttpContext.Current.User.Identity.Name);

                var queryString = HttpUtility.UrlDecode(filterContext.RequestContext.HttpContext.Request.Url.ToString());
                errorMessage.AppendLine(queryString);
            }

            errorMessage.AppendLine(string.Format("Exception Message:{0}", filterContext.Exception.Message));
            if (filterContext.Exception.InnerException != null)
            {
                errorMessage.AppendLine(string.Format("InnerException Message:{0}", filterContext.Exception.InnerException.Message));
                errorMessage.AppendLine(string.Format("InnerException StackTrace:{0}", filterContext.Exception.InnerException.StackTrace));
            }

            log.Error(errorMessage.ToString(), filterContext.Exception);

            filterContext.Result = new RedirectResult("/500");
            base.OnException(filterContext);
        }

    }
}