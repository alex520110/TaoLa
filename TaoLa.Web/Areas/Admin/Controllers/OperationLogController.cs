using Himall.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaoLa.IServices;
using TaoLa.IServices.QueryModel;
using TaoLa.Web.Framework;

namespace TaoLa.Web.Areas.Admin.Controllers
{
    public class OperationLogController : BaseAdminController
    {
        private IOperationLogService _iOperationLogService;

        private IManagerService _iManagerService;

        public OperationLogController(IOperationLogService iOperationLogService, IManagerService iManagerService)
        {
            this._iOperationLogService = iOperationLogService;
            this._iManagerService = iManagerService;
        }
        // [Description("关键字获取管理员用户名列表")]
        //[UnAuthorize]
        public JsonResult GetManagers(string keyWords)
        {
            IQueryable<ManagerInfo> managers =
                from item in this._iManagerService.GetManagers(keyWords)
                where item.ShopId == (long)0
                select item;
            var variable =
                from item in managers
                select new { key = item.Id, @value = item.UserName };
            return base.Json(variable);
        }

        //  [Description("分页获取日志的JSON数据")]
        // [UnAuthorize]
        public JsonResult List(int page, string userName, int rows, DateTime? startDate, DateTime? endDate)
        {
            OperationLogQuery operationLogQuery = new OperationLogQuery()
            {
                UserName = userName,
                PageNo = page,
                PageSize = rows,
                StartDate = startDate,
                EndDate = endDate
            };
            PageModel<LogInfo> platformOperationLogs = this._iOperationLogService.GetPlatformOperationLogs(operationLogQuery);
            var list =
                from item in platformOperationLogs.Models.ToList<LogInfo>()
                select new { Id = item.Id, UserName = item.UserName, PageUrl = item.PageUrl, Description = item.Description, Date = item.Date.ToString("yyyy-MM-dd HH:mm"), IPAddress = item.IPAddress };
            var variable = new { rows = list, total = platformOperationLogs.Total };
            return base.Json(variable);
        }

        // [Description("平台日志管理页面")]
        public ActionResult Management()
        {
            return base.View();
        }
    }
}