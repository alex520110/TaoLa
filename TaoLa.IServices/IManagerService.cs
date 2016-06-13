using Himall.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaoLa.IServices.QueryModel;

namespace TaoLa.IServices
{
    public interface  IManagerService : IService, IDisposable
    {
        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="isPlatFormManager"></param>
        /// <returns></returns>
        ManagerInfo Login(string username, string password, bool isPlatFormManager = false);
        /// <summary>
        /// 根据用户ID 获取 平台用户信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        ManagerInfo GetPlatformManager(long userId);

        /// <summary>
        /// 获取管理员集合
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        PageModel<ManagerInfo> GetPlatformManagers(ManagerQuery query);
    }
}
