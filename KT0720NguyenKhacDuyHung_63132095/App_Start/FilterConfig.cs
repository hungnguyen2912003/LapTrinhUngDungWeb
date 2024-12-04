using System.Web;
using System.Web.Mvc;

namespace KT0720NguyenKhacDuyHung_63132095
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
