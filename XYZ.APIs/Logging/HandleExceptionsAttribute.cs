using System;
using System.Web;
using System.Web.Mvc;
using log4net;

namespace XYZ.APIs.Logging
{
    public class HandleExceptionsAttribute : HandleErrorAttribute
    {
        private static readonly
         ILog Logger =
         LogManager.GetLogger(typeof(HandleExceptionsAttribute));

        public override void OnException
       (ExceptionContext filterContext)
        {
            var ex = filterContext.Exception;
            Logger.FatalFormat(Environment.NewLine + "Fatal error: {0} - {1} -" + Environment.NewLine  +" {2}",
          HttpContext.Current.Request.Url, ex.Message, ex);
        }
    }
}