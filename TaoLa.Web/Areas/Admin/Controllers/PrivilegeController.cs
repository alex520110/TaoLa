using Himall.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaoLa.IServices;
using TaoLa.Web.Framework;

namespace TaoLa.Web.Areas.Admin.Controllers
{
    public class PrivilegeController : BaseAdminController
    {
        private IPrivilegesService _iPrivilegesService;

        private IManagerService _iManagerService;

        public PrivilegeController(IPrivilegesService iPrivilegesService, IManagerService iManagerService)
        {
            this._iPrivilegesService = iPrivilegesService;
            this._iManagerService = iManagerService;
        }
        // GET: Admin/Privilege
        public ActionResult management()
        {
            return View();
        }

       // [Description("角色列表显示")]
        [HttpPost]
       // [UnAuthorize]
        public JsonResult List()
        {
            IQueryable<RoleInfo> platformRoles = this._iPrivilegesService.GetPlatformRoles();
            var variable =
                from item in platformRoles
                select new { Id = item.Id, Name = item.RoleName };
            return base.Json(new { rows = variable });
        }
    }
}