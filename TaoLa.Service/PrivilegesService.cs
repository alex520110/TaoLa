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
        public void AddPlatformRole(RoleInfo model)
        {
            model.ShopId = (long)0;
            if (string.IsNullOrEmpty(model.Description))
            {
                model.Description = model.RoleName;
            }
            this.context.RoleInfo.Add(model);
            this.context.SaveChanges();
        }

        public void DeletePlatformRole(long id)
        {
            RoleInfo roleInfo = (
                from a in this.context.RoleInfo
                where a.Id == id && a.ShopId == (long)0
                select a).FirstOrDefault<RoleInfo>();
            this.context.RoleInfo.Remove(roleInfo);
            this.context.SaveChanges();
        }

        /// <summary>
        /// 根据id 获取平台角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public RoleInfo GetPlatformRole(long id)
        {
            RoleInfo roleInfo = (from a in this.context.RoleInfo
                                 where a.Id == id && a.ShopId == 0
                                 select a).FirstOrDefault<RoleInfo>();

            return roleInfo;
        }

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
