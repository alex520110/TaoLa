using Himall.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaoLa.IServices;
using TaoLa.IServices.QueryModel;

namespace TaoLa.Web.Areas.Admin.Controllers
{
    public class ManagerController : Controller
    {
        private IManagerService _iManagerService;

        private IPrivilegesService _iPrivilegesService;

        public ManagerController(IManagerService iManagerService, IPrivilegesService iPrivilegesService)
        {
            this._iManagerService = iManagerService;
            this._iPrivilegesService = iPrivilegesService;
        }
        // GET: Admin/Manager
        public ActionResult Management()
        {
            return View();
        }
        /// <summary>
        /// 获取管理员列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="keywords"></param>
        /// <param name="rows"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        //[UnAuthorize]
        public JsonResult List(int page, string keywords, int rows, bool? status = null)
        {
            IManagerService managerService = this._iManagerService;
            ManagerQuery managerQuery = new ManagerQuery()
            {
                PageNo = page,
                PageSize = rows
            };
            PageModel<ManagerInfo> platformManagers = managerService.GetPlatformManagers(managerQuery);
            List<RoleInfo> list = this._iPrivilegesService.GetPlatformRoles().ToList<RoleInfo>();
            var collection =
                from item in platformManagers.Models.ToList<ManagerInfo>()
                select new
                {
                    Id = item.Id,
                    UserName = item.UserName,
                    CreateDate = item.CreateDate.ToString("yyyy-MM-dd HH:mm"),
                    RoleName = (item.RoleId == (long)0 ? "系统管理员" : (
                    from a in list
                    where a.Id == item.RoleId
                    select a).FirstOrDefault<RoleInfo>().RoleName),
                    RoleId = item.RoleId
                };
            var variable = new { rows = collection, total = platformManagers.Total };
            return base.Json(variable);
        }


        [HttpPost]
        public JsonResult RoleList()
        {
            var platformRoles =
                from item in this._iPrivilegesService.GetPlatformRoles()
                select new { Id = item.Id, RoleName = item.RoleName };
            return base.Json(platformRoles);
        }
    }
}