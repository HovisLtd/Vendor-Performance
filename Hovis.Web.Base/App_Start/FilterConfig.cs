using System.Web.Mvc;

namespace Hovis.Web.Base
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            //this makes the whole site require authentication
            filters.Add(new AuthorizeAttribute());
        }
    }
}