using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaoLa.Web.Framework;

namespace TaoLa.Web
{
    public class FilterConfig
    {
        public FilterConfig()
        {
        }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new GZipAttribute());
            filters.Add(new HandleErrorAttribute());
        }
    }
}