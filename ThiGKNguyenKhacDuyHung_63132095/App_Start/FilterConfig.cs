using System.Web;
using System.Web.Mvc;

namespace ThiGKNguyenKhacDuyHung_63132095
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
