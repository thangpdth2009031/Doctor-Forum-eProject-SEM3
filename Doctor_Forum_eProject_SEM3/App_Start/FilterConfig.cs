using System.Web;
using System.Web.Mvc;

namespace Doctor_Forum_eProject_SEM3
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
