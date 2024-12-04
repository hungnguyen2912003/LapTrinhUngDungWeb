using System.Web;
using System.Web.Mvc;

namespace _63132095_NguyenKhacDuyHung
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}
