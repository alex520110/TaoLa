using TaoLa.Web.Framework;
using System;
using System.Web.Mvc;

namespace TaoLa.Web.Areas.Admin
{
    public class AdminAreaRegistration : BaseAreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override int Order
        {
            get
            {
                return 0;
            }
        }

        public AdminAreaRegistration()
        {
        }

        public override void RegisterAreaOrder(AreaRegistrationContext context)
        {
            context.MapRoute("Admin_default", "Admin/{controller}/{action}/{id}", new { controller = "home", action = "Index", id = UrlParameter.Optional });

        }
    }
}