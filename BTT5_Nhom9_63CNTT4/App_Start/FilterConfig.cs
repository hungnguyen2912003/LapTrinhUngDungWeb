﻿using System.Web;
using System.Web.Mvc;

namespace BTT5_Nhom9_63CNTT4
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
