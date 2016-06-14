using Himall.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaoLa.IServices;
using TaoLa.IServices.QueryModel;
using TaoLa.Web.Areas.Admin.Models;
using TaoLa.Web.Framework;

namespace TaoLa.Web.Areas.Admin.Controllers
{
    public class ManagerController : BaseAdminController
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

        /// <summary>
        /// 获取 平台角色
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult RoleList()
        {
            var platformRoles =
                from item in this._iPrivilegesService.GetPlatformRoles()
                select new { Id = item.Id, RoleName = item.RoleName };
            return base.Json(platformRoles);
        }
        /// <summary>
        /// 检查 用户名是否存在
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public JsonResult IsExistsUserName(string userName)
        {
            JsonResult jsonResult = base.Json(new { Exists = this._iManagerService.CheckUserNameExist(userName, false) });
            return jsonResult;
        }
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult Add(ManagerInfoModel model)
        {
            ManagerInfo managerInfo = new ManagerInfo()
            {
                UserName = model.UserName,
                Password = model.Password,
                RoleId = model.RoleId
            };
            this._iManagerService.AddPlatformManager(managerInfo);
            BaseController.Result result = new BaseController.Result()
            {
                success = true,
                msg = "添加成功！"
            };
            return base.Json(result);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult BatchDelete(string ids)
        {
            string[] strArrays = ids.Split(new char[] { ',' });
            List<long> nums = new List<long>();
            string[] strArrays1 = strArrays;
            for (int i = 0; i < (int)strArrays1.Length; i++)
            {
                nums.Add(Convert.ToInt64(strArrays1[i]));
            }
            this._iManagerService.BatchDeletePlatformManager(nums.ToArray());
            BaseController.Result result = new BaseController.Result()
            {
                success = true,
                msg = "批量删除成功！"
            };
            return base.Json(result);
        }
        /// <summary>
        /// 单个删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Delete(long id)
        {
            this._iManagerService.DeletePlatformManager(id);
            BaseController.Result result = new BaseController.Result()
            {
                success = true,
                msg = "删除成功！"
            };
            return base.Json(result);
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="id"></param>
        /// <param name="password"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public JsonResult ChangePassWord(long id, string password, long roleId)
        {
            this._iManagerService.ChangePlatformManagerPassword(id, password, roleId);
            BaseController.Result result = new BaseController.Result()
            {
                success = true,
                msg = "修改成功！"
            };
            return base.Json(result);
        }
    }
}