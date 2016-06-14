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
        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="isPlatFormManager"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 检查用户是否存在
        /// </summary>
        /// <param name="username"></param>
        /// <param name="isPlatFormManager">是否为平台用户  false 不是， true 为是</param>
        /// <returns></returns>
        public bool CheckUserNameExist(string username, bool isPlatFormManager = false)
        {
            bool flag;
            if (!isPlatFormManager)
            {
                bool flag1 = this.context.ManagerInfo.Any<ManagerInfo>((ManagerInfo item) => (item.UserName.ToLower() == username.ToLower()) && item.ShopId != (long)0);


                flag = (this.context.UserMemberInfo.Any<UserMemberInfo>((UserMemberInfo item) => item.UserName.ToLower() == username.ToLower()) ? true : flag1);
            }
            else
            {
                flag = this.context.ManagerInfo.Any<ManagerInfo>((ManagerInfo item) => (item.UserName.ToLower() == username.ToLower()) && item.ShopId == (long)0);
            }
            return flag;
        }
        /// <summary>
        /// 添加平台用户
        /// </summary>
        /// <param name="model"></param>
        public void AddPlatformManager(ManagerInfo model)
        {
            if (model.RoleId == (long)0)
            {
                throw new TaoLaException("权限组选择不正确!");
            }
            if (this.CheckUserNameExist(model.UserName, true))
            {
                throw new TaoLaException("该用户名已存在！");
            }
            model.ShopId = (long)0;
            model.PasswordSalt = Guid.NewGuid().ToString();
            model.CreateDate = DateTime.Now;
            string str = SecureHelper.MD5(model.Password);
            model.Password = SecureHelper.MD5(string.Concat(str, model.PasswordSalt));
            this.context.ManagerInfo.Add(model);
            this.context.SaveChanges();
        }
        /// <summary>
        /// 批量删除平台用户
        /// </summary>
        /// <param name="ids"></param>
        public void BatchDeletePlatformManager(long[] ids)
        {
            IQueryable<ManagerInfo> managerInfos = this.context.ManagerInfo.FindBy<ManagerInfo>((ManagerInfo item) => item.ShopId == (long)0 && item.RoleId != (long)0 && ids.Contains<long>(item.Id));
            this.context.ManagerInfo.RemoveRange(managerInfos);
            this.context.SaveChanges();
        }
        /// <summary>
        /// 批量删除店铺用户
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="shopId"></param>
        public void BatchDeleteSellerManager(long[] ids, long shopId)
        {
            IQueryable<ManagerInfo> managerInfos = this.context.ManagerInfo.FindBy<ManagerInfo>((ManagerInfo item) => item.ShopId == shopId && item.RoleId != (long)0 && ids.Contains<long>(item.Id));
            this.context.ManagerInfo.RemoveRange(managerInfos);
            this.context.SaveChanges();
        }
        /// <summary>
        /// 单个删除平台用户
        /// </summary>
        /// <param name="id"></param>
        public void DeletePlatformManager(long id)
        {
            ManagerInfo managerInfo = this.context.ManagerInfo.FindBy<ManagerInfo>((ManagerInfo item) => item.Id == id && item.ShopId == (long)0 && item.RoleId != (long)0).FirstOrDefault<ManagerInfo>();
            this.context.ManagerInfo.Remove(managerInfo);
            this.context.SaveChanges();
        }
        /// <summary>
        /// 单个删除店铺用户
        /// </summary>
        /// <param name="id"></param>
        /// <param name="shopId"></param>
        public void DeleteSellerManager(long id, long shopId)
        {
            ManagerInfo managerInfo = this.context.ManagerInfo.FindBy<ManagerInfo>((ManagerInfo item) => item.Id == id && item.ShopId == shopId && item.RoleId != (long)0).FirstOrDefault<ManagerInfo>();
            this.context.ManagerInfo.Remove(managerInfo);
            this.context.SaveChanges();
        }
        /// <summary>
        /// 修改平台用户密码
        /// </summary>
        /// <param name="id"></param>
        /// <param name="password"></param>
        /// <param name="roleId"></param>
        public void ChangePlatformManagerPassword(long id, string password, long roleId)
        {
            ManagerInfo managerInfo = this.context.ManagerInfo.FindBy<ManagerInfo>((ManagerInfo item) => item.Id == id && item.ShopId == (long)0).FirstOrDefault<ManagerInfo>();
            if (managerInfo == null)
            {
                throw new TaoLaException("该管理员不存在，或者已被删除!");
            }
            if ((roleId == (long)0 ? false : managerInfo.RoleId != (long)0))
            {
                managerInfo.RoleId = roleId;
            }
            if (!string.IsNullOrWhiteSpace(password))
            {
                string str = SecureHelper.MD5(password);
                managerInfo.Password = SecureHelper.MD5(string.Concat(str, managerInfo.PasswordSalt));
            }
            this.context.SaveChanges();
            Cache.Remove(CacheKeyCollection.Manager(id));
        }
    }
}
