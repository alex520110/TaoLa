using Himall.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaoLa.IServices;
using TaoLa.Web.Areas.Admin.Models;
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
        public ActionResult add()
        {
            this.SetPrivileges();
            return View();
        }

        //    [Description("角色添加")]
        [HttpPost]
        //   [UnAuthorize]
        public JsonResult Add(string roleJson)
        {
            JsonResult jsonResult;
            if (!base.ModelState.IsValid)
            {
                jsonResult = base.Json(new { success = true, msg = "验证失败" });
            }
            else
            {
                JsonSerializerSettings jsonSerializerSetting = new JsonSerializerSettings()
                {
                    MissingMemberHandling = MissingMemberHandling.Ignore,
                    NullValueHandling = NullValueHandling.Ignore
                };
                RoleInfo roleInfo = JsonConvert.DeserializeObject<RoleInfo>(roleJson, jsonSerializerSetting);
                this._iPrivilegesService.AddPlatformRole(roleInfo);
                jsonResult = base.Json(new { success = true });
            }
            return jsonResult;
        }

        [UnAuthorize]
        public JsonResult Delete(long id)
        {
            JsonResult jsonResult;
            //   this._iPrivilegesService.GetPlatformRole(id);
            if (this._iManagerService.GetPlatformManagerByRoleId(id).Count<ManagerInfo>() <= 0)
            {
                this._iPrivilegesService.DeletePlatformRole(id);
                BaseController.Result result = new BaseController.Result()
                {
                    success = true,
                    msg = "删除成功！"
                };
                jsonResult = base.Json(result);
            }
            else
            {
                BaseController.Result result1 = new BaseController.Result()
                {
                    success = false,
                    msg = "该角色下还有管理员，不允许删除！"
                };
                jsonResult = base.Json(result1);
            }
            return jsonResult;
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

        public ActionResult Edit(long id)
        {
            this.SetPrivileges();
            RoleInfo platformRole = this._iPrivilegesService.GetPlatformRole(id);
            RoleInfoModel roleInfoModel = new RoleInfoModel()
            {
                ID = platformRole.Id,
                RoleName = platformRole.RoleName
            };
            RoleInfoModel roleInfoModel1 = roleInfoModel;
            JsonSerializerSettings jsonSerializerSetting = new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            dynamic viewBag = base.ViewBag;
            ICollection<RolePrivilegeInfo> rolePrivilegeInfo = platformRole.RolePrivilegeInfo;
            viewBag.RolePrivilegeInfo = JsonConvert.SerializeObject(
                from item in rolePrivilegeInfo
                select new { Privilege = item.Privilege }, jsonSerializerSetting);
            return base.View(roleInfoModel1);
        }

        private void SetPrivileges()
        {
            ((dynamic)base.ViewBag).Privileges = PrivilegeHelper.AdminPrivileges;
        }
    }
}