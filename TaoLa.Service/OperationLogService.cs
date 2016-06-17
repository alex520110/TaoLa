using Himall.Entity;
using Himall.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaoLa.Core;
using TaoLa.IServices;
using TaoLa.IServices.QueryModel;

namespace TaoLa.Service
{
    public class OperationLogService : ServiceBase, IOperationLogService, IService, IDisposable
    {
        public OperationLogService()
        {
        }

        public void AddPlatformOperationLog(LogInfo model)
        {
            model.ShopId = (long)0;
            this.context.LogInfo.Add(model);
            this.context.SaveChanges();
        }

        public void AddSellerOperationLog(LogInfo model)
        {
            if (model.ShopId == (long)0)
            {
                throw new TaoLaException("日志获取店铺ID错误");
            }
            model.ShopId = model.ShopId;
            this.context.LogInfo.Add(model);
            this.context.SaveChanges();
        }

        public void DeletePlatformOperationLog(long id)
        {
            throw new NotImplementedException();
        }

        public PageModel<LogInfo> GetPlatformOperationLogs(OperationLogQuery query)
        {
            int num = 0;
            IQueryable<LogInfo> userName = this.context.LogInfo.FindBy<LogInfo>((LogInfo item) => item.ShopId == query.ShopId);
            if (!string.IsNullOrWhiteSpace(query.UserName))
            {
                userName =
                    from item in userName
                    where query.UserName == item.UserName
                    select item;
            }
            if (query.StartDate.HasValue)
            {
                userName =
                    from item in userName
                    where item.Date >= query.StartDate.Value
                    select item;
            }
            if (query.EndDate.HasValue)
            {
                userName =
                    from item in userName
                    where item.Date <= query.EndDate.Value
                    select item;
            }
            userName = userName.GetPage<LogInfo>(out num, query.PageNo, query.PageSize, null);
            return new PageModel<LogInfo>()
            {
                Models = userName,
                Total = num
            };
        }
    }
}
