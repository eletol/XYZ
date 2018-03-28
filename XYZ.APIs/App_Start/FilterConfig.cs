using System.Web.Mvc;
using XYZ.APIs.Logging;

namespace XYZ.APIs
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new HandleExceptionsAttribute());  // NEW ENTRIE

        }
    }
}
