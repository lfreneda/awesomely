using System.Web;
using System.Web.Mvc;

namespace Awesomely.OAuth.Sample.MVC {
    public class FilterConfig {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
        }
    }
}