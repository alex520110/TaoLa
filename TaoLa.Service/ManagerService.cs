using Himall.Entity;
using Himall.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaoLa.Core;
using TaoLa.IServices;
using TaoLa.ServiceProvider;
using TaoLa.IServices.QueryModel;

namespace TaoLa.Service
{
    public class ManagerService : ServiceBase, IManagerService, IService, IDisposable
    {
        public ManagerInfo Login(string username, string password, bool isPlatFormManager = false)
        {
            ManagerInfo managerInfo;
            managerInfo = (!isPlatFormManager ? this.context.ManagerInfo.FindBy<ManagerInfo>((ManagerInfo item) => (item.UserName == username) && item.ShopId != (long)0).FirstOrDefault<ManagerInfo>() : this.context.ManagerInfo.FindBy<ManagerInfo>((ManagerInfo item) => (item.UserName == username) && item.ShopId == (long)0).FirstOrDefault<ManagerInfo>());
            if (managerInfo != null)
            {
                if (this.GetPasswrodWithTwiceEncode(password, managerInfo.PasswordSalt).ToLower() != managerInfo.Password)
                {
                    managerInfo = null;
                }
                else if (managerInfo.ShopId > (long)0)
                {
                    ShopInfo shop = Instance<IShopService>.Create.GetShop(managerInfo.ShopId, false);
                    if (shop == null)
                    {
                        throw new TaoLaException("未找到帐户对应的店铺");
                    }
                    if (!shop.IsSelf)
                    {
                        if (shop.ShopStatus == ShopInfo.ShopAuditStatus.Freeze)
                        {
                            throw new TaoLaException("帐户所在店铺已被冻结");
                        }
                    }
                }
            }
            return managerInfo;
        }
        /// <summary>
        /// 根据用户ID 获取 平台用户信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public ManagerInfo GetPlatformManager(long userId)
        {
            ManagerInfo managerInfo;
            ManagerInfo roleName = null;
            string str = CacheKeyCollection.Manager(userId);
            if (Cache.Get(str) == null)
            {
                roleName = this.context.ManagerInfo.FirstOrDefault<ManagerInfo>((ManagerInfo item) => item.Id == userId && item.ShopId == (long)0);
                if (roleName == null)
                {
                    managerInfo = null;
                    return managerInfo;
                }
                if (roleName.RoleId != (long)0)
                {
                    RoleInfo roleInfo = this.context.RoleInfo.FindById<RoleInfo>(roleName.RoleId);
                    if (roleInfo != null)
                    {
                        List<AdminPrivilege> adminPrivileges = new List<AdminPrivilege>();
                        roleInfo.RolePrivilegeInfo.ToList<RolePrivilegeInfo>().ForEach((RolePrivilegeInfo a) => adminPrivileges.Add((AdminPrivilege)a.Privilege));
                        roleName.RoleName = roleInfo.RoleName;
                        roleName.AdminPrivileges = adminPrivileges;
                        roleName.Description = roleInfo.Description;
                    }
                }
                else
                {
                    List<AdminPrivilege> adminPrivileges1 = new List<AdminPrivilege>()
                    {
                        0
                    };
                    roleName.RoleName = "系统管理员";
                    roleName.AdminPrivileges = adminPrivileges1;
                    roleName.Description = "系统管理员";
                }
                Cache.Insert(str, roleName);
            }
            else
            {
                roleName = (ManagerInfo)Cache.Get(str);
            }
            managerInfo = roleName;
            return managerInfo;
        }
        private string GetPasswrodWithTwiceEncode(string password, string salt)
        {
            string str = SecureHelper.MD5(password);
            return SecureHelper.MD5(string.Concat(str, salt));
        }
        /// <summary>
        /// 根据条件 获取平台用户集合
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public PageModel<ManagerInfo> GetPlatformManagers(ManagerQuery query)
        {
            int num = 0;
            IQueryable<ManagerInfo> managerInfos = this.context.ManagerInfo.FindBy<ManagerInfo, long>((ManagerInfo item) => item.ShopId == (long)0, query.PageNo, query.PageSize, out num, (ManagerInfo item) => item.RoleId, true);
            return new PageModel<ManagerInfo>()
            {
                Models = managerInfos,
                Total = num
            };
        }
    }
}
