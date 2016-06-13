using TaoLa.Core;
using TaoLa.Web.Framework;
using System;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace TaoLa.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //AreaRegistration.RegisterAllAreas();
            //RouteConfig.RegisterRoutes(RouteTable.Routes);

            RouteTable.Routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            RouteTable.Routes.IgnoreRoute("Areas/");
            RegistAtStart.Regist();  //插件
            // Job.Start();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            GlobalConfiguration.Configure(new Action<HttpConfiguration>(WebApiConfig.Register));
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BaseAreaRegistration.RegisterAllAreasOrder();
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ObjectContainer.ApplicationStart(new AutoFacContainer());
        }
    }
}
