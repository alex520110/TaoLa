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

        /// <summary>
        /// 检查用户名是否存在
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="isPlatFormManager"></param>
        /// <returns></returns>
        bool CheckUserNameExist(string userName, bool isPlatFormManager = false);

        /// <summary>
        /// 添加平台用户
        /// </summary>
        /// <param name="model"></param>
        void AddPlatformManager(ManagerInfo model);

        /// <summary>
        /// 单个删除平台用户
        /// </summary>
        /// <param name="id"></param>
        void DeletePlatformManager(long id);

        /// <summary>
        /// 单个删除店铺用户
        /// </summary>
        /// <param name="id"></param>
        /// <param name="shopId"></param>
        void DeleteSellerManager(long id, long shopId);
        /// <summary>
        /// 批量删除平台用户
        /// </summary>
        /// <param name="ids"></param>
        void BatchDeletePlatformManager(long[] ids);
        /// <summary>
        /// 批量删除店铺用户
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="shopId"></param>
        void BatchDeleteSellerManager(long[] ids, long shopId);

        /// <summary>
        /// 修改平台用户密码
        /// </summary>
        /// <param name="id"></param>
        /// <param name="password"></param>
        /// <param name="roleId"></param>
        void ChangePlatformManagerPassword(long id, string password, long roleId);


        IQueryable<ManagerInfo> GetPlatformManagerByRoleId(long roleId);

        IQueryable<ManagerInfo> GetManagers(string keyWords);
    }
}
