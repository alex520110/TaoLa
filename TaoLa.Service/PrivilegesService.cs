using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Himall.Model;
using TaoLa.IServices;
using Himall.Entity;

namespace TaoLa.Service
{
    public class PrivilegesService : ServiceBase, IPrivilegesService, IService, IDisposable
    {
        /// <summary>
        /// 获取平台角色
        /// </summary>
        /// <returns></returns>
        public IQueryable<RoleInfo> GetPlatformRoles()
        {
            IQueryable<RoleInfo> roleInfos = this.context.RoleInfo.FindBy<RoleInfo>((RoleInfo item) => item.ShopId == (long)0);
            return roleInfos;
        }
    }
}
