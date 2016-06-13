using Himall.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaoLa.IServices
{
    public interface IPrivilegesService : IService, IDisposable
    {
        //   void AddPlatformRole(RoleInfo model);

        // void AddSellerRole(RoleInfo model);

        //  void UpdatePlatformRole(RoleInfo model);

        //   void UpdateSellerRole(RoleInfo model);

        // void DeletePlatformRole(long id);

        // RoleInfo GetPlatformRole(long id);

        // RoleInfo GetSellerRole(long id, long shopId);

        //  IQueryable<RoleInfo> GetSellerRoles(long shopId);
        /// <summary>
        /// 获取平台角色
        /// </summary>
        /// <returns></returns>
        IQueryable<RoleInfo> GetPlatformRoles();

        // void DeleteSellerRole(long id, long shopId);
    }
}
