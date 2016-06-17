using Himall.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaoLa.IServices.QueryModel;

namespace TaoLa.IServices
{
    public interface IOperationLogService : IService, IDisposable
    {
        PageModel<LogInfo> GetPlatformOperationLogs(OperationLogQuery query);

        void AddPlatformOperationLog(LogInfo info);

        void AddSellerOperationLog(LogInfo info);

        void DeletePlatformOperationLog(long id);
    }
}
