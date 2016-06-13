using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaoLa.IServices;
using TaoLa.Web.Framework;

namespace TaoLa.Web.Areas.Admin.Controllers
{
    public class HomeController : BaseAdminController
    {

        private IShopService _iShopService;

     //   private IStatisticsService _iStatisticsService;

        private IManagerService _iManagerService;

        public HomeController(IShopService iShopService, IManagerService iManagerService)
        {
            this._iShopService = iShopService;
         //   this._iStatisticsService = iStatisticsService;
            this._iManagerService = iManagerService;
        }


        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }


      //  [UnAuthorize]
        public ActionResult Console()
        {
            return base.View(this._iShopService.GetPlatConsoleMode());
        }

    }
}