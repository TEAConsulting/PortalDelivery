﻿using System.Web;
using System.Web.Mvc;

namespace ZPIDI_PORTAL
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
