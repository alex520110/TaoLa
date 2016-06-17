using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Himall.Model;
using TaoLa.IServices;
using TaoLa.IServices.QueryModel;
using Himall.Entity;
using TaoLa.ServiceProvider;
using TaoLa.Core;
using System.Net;
using System.IO;

namespace TaoLa.Service
{
    public class MemberService : ServiceBase, IMemberService, IService, IDisposable
    {
        public MemberService()
        {
        }

        //private void AddBindInergral(UserMemberInfo member)
        //{
        //    if (!this.context.MemberIntegralRecord.Any<MemberIntegralRecord>((MemberIntegralRecord a) => a.MemberId == member.Id && (int)a.TypeId == 6))
        //    {
        //        try
        //        {
        //            MemberIntegralRecord memberIntegralRecord = new MemberIntegralRecord()
        //            {
        //                UserName = member.UserName,
        //                MemberId = member.Id,
        //                RecordDate = new DateTime?(DateTime.Now),
        //                TypeId = MemberIntegral.IntegralType.BindWX,
        //                ReMark = "绑定微信"
        //            };
        //            IConversionMemberIntegralBase conversionMemberIntegralBase = Instance<IMemberIntegralConversionFactoryService>.Create.Create(MemberIntegral.IntegralType.BindWX, 0);
        //            Instance<IMemberIntegralService>.Create.AddMemberIntegral(memberIntegralRecord, conversionMemberIntegralBase);
        //        }
        //        catch (Exception exception)
        //        {
        //            Log.Error(exception);
        //        }
        //    }
        //}

        //private void AddIntegel(UserMemberInfo member)
        //{
        //    if (!Instance<IMemberIntegralService>.Create.HasLoginIntegralRecord(member.Id))
        //    {
        //        MemberIntegralRecord memberIntegralRecord = new MemberIntegralRecord()
        //        {
        //            UserName = member.UserName,
        //            MemberId = member.Id,
        //            RecordDate = new DateTime?(DateTime.Now),
        //            ReMark = "每天登录",
        //            TypeId = MemberIntegral.IntegralType.Login
        //        };
        //        IConversionMemberIntegralBase conversionMemberIntegralBase = Instance<IMemberIntegralConversionFactoryService>.Create.Create(MemberIntegral.IntegralType.Login, 0);
        //        Instance<IMemberIntegralService>.Create.AddMemberIntegral(memberIntegralRecord, conversionMemberIntegralBase);
        //    }
        //}

        public void AddMember(UserMemberInfo model)
        {
            throw new NotImplementedException();
        }

        public void BatchDeleteMember(long[] ids)
        {
            this.context.UserMemberInfo.Remove<UserMemberInfo>(new object[] { ids });
            this.context.SaveChanges();
            long[] numArray = ids;
            for (int i = 0; i < (int)numArray.Length; i++)
            {
                Cache.Remove(CacheKeyCollection.Member(numArray[i]));
            }
        }

        public void BatchLock(long[] ids)
        {
            IQueryable<UserMemberInfo> userMemberInfo =
                from item in this.context.UserMemberInfo
                where ids.Contains<long>(item.Id)
                select item;
            foreach (UserMemberInfo userMemberInfo1 in userMemberInfo)
            {
                userMemberInfo1.Disabled = true;
            }
            this.context.SaveChanges();
            long[] numArray = ids;
            for (int i = 0; i < (int)numArray.Length; i++)
            {
                Cache.Remove(CacheKeyCollection.Member(numArray[i]));
            }
        }

        //public void BindMember(long userId, string serviceProvider, string openId, string headImage = null, string unionid = null, string unionopenid = null)
        //{
        //    this.CheckOpenIdHasBeenUsed(serviceProvider, openId, userId);
        //    MemberOpenIdInfo memberOpenIdInfo = new MemberOpenIdInfo()
        //    {
        //        UserId = userId,
        //        OpenId = openId,
        //        ServiceProvider = serviceProvider,
        //        UnionId = (unionid == null ? string.Empty : unionid),
        //        UnionOpenId = (string.IsNullOrWhiteSpace(unionopenid) ? string.Empty : unionopenid)
        //    };
        //    MemberOpenIdInfo memberOpenIdInfo1 = memberOpenIdInfo;
        //    UserMemberInfo userMemberInfo = this.context.UserMemberInfo.FirstOrDefault<UserMemberInfo>((UserMemberInfo item) => item.Id == userId);
        //    if (!string.IsNullOrWhiteSpace(headImage))
        //    {
        //        if (string.IsNullOrWhiteSpace(userMemberInfo.Photo))
        //        {
        //            userMemberInfo.Photo = this.TransferHeadImage(headImage, userId);
        //        }
        //    }
        //    this.context.MemberOpenIdInfo.Add(memberOpenIdInfo1);
        //    this.context.SaveChanges();
        //    Instance<IBonusService>.Create.DepositToRegister(userMemberInfo.Id);
        //    Cache.Remove(CacheKeyCollection.Member(userId));
        //}

        //public void BindMember(long userId, string serviceProvider, string openId, MemberOpenIdInfo.AppIdTypeEnum AppidType, string headImage = null, string unionid = null)
        //{
        //    this.CheckOpenIdHasBeenUsed(serviceProvider, openId, userId);
        //    MemberOpenIdInfo memberOpenIdInfo = new MemberOpenIdInfo()
        //    {
        //        UserId = userId,
        //        OpenId = openId,
        //        ServiceProvider = serviceProvider,
        //        AppIdType = AppidType,
        //        UnionId = (string.IsNullOrWhiteSpace(unionid) ? string.Empty : unionid)
        //    };
        //    MemberOpenIdInfo memberOpenIdInfo1 = memberOpenIdInfo;
        //    UserMemberInfo userMemberInfo = this.context.UserMemberInfo.FirstOrDefault<UserMemberInfo>((UserMemberInfo item) => item.Id == userId);
        //    if (!string.IsNullOrWhiteSpace(headImage))
        //    {
        //        if (string.IsNullOrWhiteSpace(userMemberInfo.Photo))
        //        {
        //            userMemberInfo.Photo = this.TransferHeadImage(headImage, userId);
        //        }
        //    }
        //    this.context.MemberOpenIdInfo.Add(memberOpenIdInfo1);
        //    this.context.SaveChanges();
        //    Instance<IBonusService>.Create.DepositToRegister(userMemberInfo.Id);
        //    if (serviceProvider.ToLower() == "Himall.Plugin.OAuth.WeiXin".ToLower())
        //    {
        //        this.AddBindInergral(userMemberInfo);
        //    }
        //    Cache.Remove(CacheKeyCollection.Member(userId));
        //}

        //public void BindMember(OAuthUserModel model)
        //{
        //    this.CheckOpenIdHasBeenUsed(model.LoginProvider, model.OpenId, model.UserId);
        //    MemberOpenIdInfo memberOpenIdInfo = new MemberOpenIdInfo()
        //    {
        //        UserId = model.UserId,
        //        OpenId = model.OpenId,
        //        ServiceProvider = model.LoginProvider,
        //        AppIdType = model.AppIdType,
        //        UnionId = (string.IsNullOrWhiteSpace(model.UnionId) ? string.Empty : model.UnionId)
        //    };
        //    MemberOpenIdInfo memberOpenIdInfo1 = memberOpenIdInfo;
        //    UserMemberInfo nickName = this.context.UserMemberInfo.FirstOrDefault<UserMemberInfo>((UserMemberInfo item) => item.Id == model.UserId);
        //    if (!string.IsNullOrWhiteSpace(model.Headimgurl))
        //    {
        //        if (string.IsNullOrWhiteSpace(nickName.Photo))
        //        {
        //            nickName.Photo = this.TransferHeadImage(model.Headimgurl, model.UserId);
        //        }
        //    }
        //    if (!string.IsNullOrWhiteSpace(model.NickName))
        //    {
        //        nickName.Nick = model.NickName;
        //    }
        //    if (!string.IsNullOrWhiteSpace(model.Sex))
        //    {
        //        int num = 0;
        //        if (int.TryParse(model.Sex, out num))
        //        {
        //            nickName.Sex = new UserMemberInfo.SexType?((UserMemberInfo.SexType)num);
        //        }
        //    }
        //    this.context.MemberOpenIdInfo.Add(memberOpenIdInfo1);
        //    this.context.SaveChanges();
        //    Instance<IBonusService>.Create.DepositToRegister(nickName.Id);
        //    if (model.LoginProvider == "Himall.Plugin.OAuth.WeiXin".ToLower())
        //    {
        //        this.AddBindInergral(nickName);
        //    }
        //    Cache.Remove(CacheKeyCollection.Member(model.UserId));
        //}

        public void ChangePassWord(long id, string password)
        {
            if (password.Length < 6)
            {
                throw new TaoLaException("密码长度至少6位字符！");
            }
            UserMemberInfo passwrodWithTwiceEncode = this.context.UserMemberInfo.FindById<UserMemberInfo>(id);
            if (passwrodWithTwiceEncode.PasswordSalt.StartsWith("o"))
            {
                UserMemberInfo userMemberInfo = passwrodWithTwiceEncode;
                Guid guid = Guid.NewGuid();
                userMemberInfo.PasswordSalt = guid.ToString("N").Substring(12);
            }
            passwrodWithTwiceEncode.Password = this.GetPasswrodWithTwiceEncode(password, passwrodWithTwiceEncode.PasswordSalt);
            ManagerInfo passwordSalt = this.context.ManagerInfo.FirstOrDefault<ManagerInfo>((ManagerInfo a) => (a.UserName == passwrodWithTwiceEncode.UserName) && a.ShopId != (long)0);
            if (passwordSalt != null)
            {
                passwordSalt.PasswordSalt = passwrodWithTwiceEncode.PasswordSalt;
                passwordSalt.Password = passwrodWithTwiceEncode.Password;
            }
            this.context.SaveChanges();
            Cache.Remove(CacheKeyCollection.Member(passwrodWithTwiceEncode.Id));
            Cache.Remove(CacheKeyCollection.Seller(passwrodWithTwiceEncode.Id));
        }

        public void CheckContactInfoHasBeenUsed(string serviceProvider, string contact, MemberContactsInfo.UserTypes userType = 0)
        {
            if (this.context.MemberContactsInfo.FirstOrDefault<MemberContactsInfo>((MemberContactsInfo item) => (item.ServiceProvider == serviceProvider) && (item.Contact == contact) && (int)item.UserType == (int)userType) != null)
            {
                throw new TaoLaException(string.Format("{0}已经被其它用户绑定", contact));
            }
        }

        private void CheckInputIsValidWhenQuickRegister(string username, string serviceProvider, string openId)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentNullException("用户名不能为空");
            }
            if (string.IsNullOrWhiteSpace(serviceProvider))
            {
                throw new ArgumentNullException("服务提供商不能为空");
            }
            if (string.IsNullOrWhiteSpace(openId))
            {
                throw new ArgumentNullException("OpenId不能为空");
            }
        }

        public bool CheckMemberExist(string username)
        {
            bool flag = this.context.UserMemberInfo.Any<UserMemberInfo>((UserMemberInfo item) => item.UserName == username);
            return flag;
        }

        public bool CheckMobileExist(string mobile)
        {
            bool flag = this.context.UserMemberInfo.Any<UserMemberInfo>((UserMemberInfo item) => item.CellPhone == mobile);
            return flag;
        }

        private void CheckOpenIdHasBeenUsed(string serviceProvider, string openId, long userId = 0L)
        {
            if (this.context.MemberOpenIdInfo.FirstOrDefault<MemberOpenIdInfo>((MemberOpenIdInfo item) => (item.ServiceProvider == serviceProvider) && (item.OpenId == openId)) != null)
            {
                throw new TaoLaException(string.Format("OpenId:{0}已经被使用", openId));
            }
        }

        public void ClearExpiredLinkData()
        {
            this.context.Database.ExecuteSqlCommand("delete from himall_distributionuserlink where TIMESTAMPDIFF(HOUR,LinkTime,NOW())>24 and BuyUserId=0", new object[0]);
        }

        public void DeleteMember(long id)
        {
            this.context.UserMemberInfo.Remove<UserMemberInfo>(new object[] { id });
            string str = CacheKeyCollection.Member(id);
            this.context.SaveChanges();
            Cache.Remove(str);
        }

        public void DeleteMemberOpenId(long userid, string openid)
        {
            IQueryable<MemberOpenIdInfo> memberOpenIdInfo =
                from e in this.context.MemberOpenIdInfo
                where e.UserId == userid
                select e into item
                where string.IsNullOrEmpty(openid) || !string.IsNullOrEmpty(openid) && (openid == item.OpenId)
                select item;
            this.context.MemberOpenIdInfo.RemoveRange(memberOpenIdInfo);
            this.context.SaveChanges();
        }

        public IEnumerable<int> GetAllTopRegion()
        {
            IEnumerable<int> nums = (
                from e in this.context.UserMemberInfo
                select e.TopRegionId).Distinct<int>();
            return nums;
        }

        public string GetLogo()
        {
            string memberLogo = (
                from p in this.context.SiteSettingsInfo
                where p.Key == "MemberLogo"
                select p).FirstOrDefault<SiteSettingsInfo>().MemberLogo;
            return memberLogo;
        }

        public UserMemberInfo GetMember(long id)
        {
            UserMemberInfo member = this.GetMember((UserMemberInfo d) => d.Id == id);
            return member;
        }

        private UserMemberInfo GetMember(Func<UserMemberInfo, bool> predicate)
        {
            UserMemberInfo memberGrade = this.context.UserMemberInfo.Where<UserMemberInfo>(predicate).FirstOrDefault<UserMemberInfo>();
            if (memberGrade != null)
            {
                memberGrade.InitUserIntegralInfo();
                memberGrade.MemberGradeName = this.GetMemberGrade(memberGrade.HistoryIntegral);
            }
            return memberGrade;
        }

        public UserMemberInfo GetMemberByContactInfo(string contact)
        {
            UserMemberInfo userMemberInfo = null;
            MemberContactsInfo memberContactsInfo = this.context.MemberContactsInfo.FirstOrDefault<MemberContactsInfo>((MemberContactsInfo item) => (item.Contact == contact) && (int)item.UserType == 0);
            userMemberInfo = (memberContactsInfo == null ? (
                from a in this.context.UserMemberInfo
                where (a.UserName == contact) && this.context.MemberContactsInfo.Any<MemberContactsInfo>((MemberContactsInfo item) => item.UserId == a.Id)
                select a).FirstOrDefault<UserMemberInfo>() : this.context.UserMemberInfo.FindById<UserMemberInfo>(memberContactsInfo.UserId));
            return userMemberInfo;
        }

        public UserMemberInfo GetMemberByName(string userName)
        {
            UserMemberInfo member = this.GetMember((UserMemberInfo a) => a.UserName == userName);
            return member;
        }

        public UserMemberInfo GetMemberByOpenId(string serviceProvider, string openId)
        {
            UserMemberInfo userMemberInfo = null;
            MemberOpenIdInfo memberOpenIdInfo = this.context.MemberOpenIdInfo.FirstOrDefault<MemberOpenIdInfo>((MemberOpenIdInfo item) => (item.ServiceProvider == serviceProvider) && (item.OpenId == openId));
            if (memberOpenIdInfo != null)
            {
                userMemberInfo = this.context.UserMemberInfo.FindById<UserMemberInfo>(memberOpenIdInfo.UserId);
            }
            return userMemberInfo;
        }

        public UserMemberInfo GetMemberByUnionId(string serviceProvider, string UnionId)
        {
            UserMemberInfo userMemberInfo = null;
            MemberOpenIdInfo memberOpenIdInfo = this.context.MemberOpenIdInfo.FirstOrDefault<MemberOpenIdInfo>((MemberOpenIdInfo item) => (item.ServiceProvider == serviceProvider) && (item.UnionId == UnionId));
            if (memberOpenIdInfo != null)
            {
                userMemberInfo = this.context.UserMemberInfo.FindById<UserMemberInfo>(memberOpenIdInfo.UserId);
            }
            return userMemberInfo;
        }

        private string GetMemberGrade(int historyIntegrals)
        {
            MemberGrade memberGrade = (
                from a in this.context.MemberGrade
                orderby a.Integral descending
                select a).FirstOrDefault<MemberGrade>((MemberGrade a) => a.Integral <= historyIntegrals);
            return (memberGrade != null ? memberGrade.GradeName : "Vip0");
        }

        public IEnumerable<MemberLabelInfo> GetMemberLabels(long memid)
        {
            IEnumerable<MemberLabelInfo> list = (
                from e in this.context.MemberLabelInfo
                where e.MemId == memid
                select e).ToList<MemberLabelInfo>();
            return list;
        }

        public PageModel<UserMemberInfo> GetMembers(MemberQuery query)
        {
            int num = 0;
            IQueryable<UserMemberInfo> disabled = this.context.UserMemberInfo.AsQueryable<UserMemberInfo>();
            if (query.IsHaveEmail.HasValue)
            {
                disabled = (!query.IsHaveEmail.Value ?
                    from u in disabled
                    where u.Email == ""
                    select u :
                    from u in disabled
                    where u.Email != null && (u.Email != "")
                    select u);
            }
            if (!string.IsNullOrWhiteSpace(query.keyWords))
            {
                disabled =
                    from d in disabled
                    where d.UserName.Equals(query.keyWords)
                    select d;
            }
            if (query.Status.HasValue)
            {
                disabled =
                    from d in disabled
                    where d.Disabled
                    select d;
            }
            if ((query.LabelId == null ? false : (int)query.LabelId.Length > 0))
            {
                disabled =
                    from l in this.context.MemberLabelInfo
                    join u in disabled on l.MemId equals u.Id
                    where query.LabelId.Contains<long>(l.LabelId)
                    select u;
            }
            if (query.RegistTimeStart.HasValue)
            {
                disabled =
                    from e in disabled
                    where e.CreateDate >= query.RegistTimeStart.Value
                    select e;
            }
            if (query.RegistTimeEnd.HasValue)
            {
                disabled =
                    from e in disabled
                    where e.CreateDate < query.RegistTimeEnd.Value
                    select e;
            }
            if (query.LoginTimeStart.HasValue)
            {
                disabled =
                    from e in disabled
                    where e.LastLoginDate >= query.LoginTimeStart.Value
                    select e;
            }
            if (query.LoginTimeEnd.HasValue)
            {
                disabled =
                    from e in disabled
                    where e.LastLoginDate < query.LoginTimeEnd.Value
                    select e;
            }
            if (query.IsSeller.HasValue)
            {
                IQueryable<string> managerInfo =
                    from e in this.context.ManagerInfo
                    select e.UserName;
                disabled = (!query.IsSeller.Value ?
                    from e in disabled
                    where !managerInfo.Contains<string>(e.UserName)
                    select e :
                    from e in disabled
                    where managerInfo.Contains<string>(e.UserName)
                    select e);
            }
            if (query.IsFocusWeiXin.HasValue)
            {
                var memberOpenIdInfo =
                    from m in this.context.MemberOpenIdInfo
                    join u in disabled on m.UserId equals u.Id
                    select new { openid = m.OpenId, userid = u.Id };
                IQueryable<long> openIdsInfo =
                    from ids in this.context.OpenIdsInfo
                    join o in memberOpenIdInfo on ids.OpenId equals o.openid
                    where ids.IsSubscribe
                    select o.userid;
                disabled = (!query.IsFocusWeiXin.Value ?
                    from e in disabled
                    where !openIdsInfo.Contains<long>(e.Id)
                    select e :
                    from e in disabled
                    where openIdsInfo.Contains<long>(e.Id)
                    select e);
            }
            disabled = disabled.GetPage<UserMemberInfo>(out num, query.PageNo, query.PageSize, (IQueryable<UserMemberInfo> d) =>
                from o in d
                orderby o.Id
                select o);
            return new PageModel<UserMemberInfo>()
            {
                Models = disabled,
                Total = num
            };
        }

        public IQueryable<UserMemberInfo> GetMembers(bool? status, string keyWords)
        {
            IQueryable<UserMemberInfo> userMemberInfos = this.context.UserMemberInfo.FindBy<UserMemberInfo>((UserMemberInfo item) => item.ParentSellerId == (long)0 && (!status.HasValue || item.Disabled == status.Value) && (keyWords == null || (keyWords == "") || item.UserName.Contains(keyWords)));
            return userMemberInfos;
        }

        public IQueryable<MemberLabelInfo> GetMembersByLabel(long labelid)
        {
            IQueryable<MemberLabelInfo> memberLabelInfo =
                from item in this.context.MemberLabelInfo
                where item.LabelId == labelid
                select item;
            return memberLabelInfo;
        }

        private string GetNewUserName()
        {
            string str = "";
            while (true)
            {
                str = "wx";
                Random random = new Random();
                string[] strArrays = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
                string[] strArrays1 = strArrays;
                int length = (int)strArrays1.Length;
                str = string.Concat(str, strArrays1[random.Next(0, length)]);
                str = string.Concat(str, strArrays1[random.Next(0, length)]);
                str = string.Concat(str, strArrays1[random.Next(0, length)]);
                str = string.Concat(str, strArrays1[random.Next(0, length)]);
                str = string.Concat(str, strArrays1[random.Next(0, length)]);
                str = string.Concat(str, strArrays1[random.Next(0, length)]);
                if (!this.context.UserMemberInfo.Any<UserMemberInfo>((UserMemberInfo d) => d.UserName == str))
                {
                    break;
                }
            }
            return str;
        }

        private string GetPasswrodWithTwiceEncode(string password, string salt)
        {
            string str = SecureHelper.MD5(password);
            return SecureHelper.MD5(string.Concat(str, salt));
        }

        public UserMemberInfo GetUserByCache(long userId)
        {
            UserMemberInfo userMemberInfo = null;
            string str = CacheKeyCollection.Member(userId);
            if (Cache.Get(str) == null)
            {
                userMemberInfo = this.context.UserMemberInfo.FindById<UserMemberInfo>(userId);
                if (userMemberInfo != null)
                {
                    DateTime now = DateTime.Now;
                    Cache.Insert(str, userMemberInfo, now.AddMinutes(15));
                }
            }
            else
            {
                userMemberInfo = (UserMemberInfo)Cache.Get(str);
            }
            return userMemberInfo;
        }

        //public UserCenterModel GetUserCenterModel(long id)
        //{
        //    List<OrderInfo> list = (
        //        from a in this.context.OrderInfo
        //        where a.UserId == id
        //        select a).ToList<OrderInfo>();
        //    UserCenterModel userCenterModel = new UserCenterModel();
        //    int num = (
        //        from a in this.context.MemberIntegral
        //        where a.MemberId == (long?)id
        //        select a.HistoryIntegrals).FirstOrDefault<int>();
        //    userCenterModel.GradeName = this.GetMemberGrade(num);
        //    userCenterModel.Intergral = (
        //        from a in this.context.MemberIntegral
        //        where a.MemberId == (long?)id
        //        select a.AvailableIntegrals).FirstOrDefault<int>();
        //    userCenterModel.UserCoupon = this.context.CouponRecordInfo.Count<CouponRecordInfo>((CouponRecordInfo a) => a.UserId == id && (int)a.CounponStatus == 0 && (a.Himall_Coupon.EndTime > DateTime.Now));
        //    UserCenterModel userCoupon = userCenterModel;
        //    userCoupon.UserCoupon = userCoupon.UserCoupon + this.context.ShopBonusReceiveInfo.Count<ShopBonusReceiveInfo>((ShopBonusReceiveInfo p) => p.UserId == (long?)id && (int)p.State == 1 && (p.Himall_ShopBonusGrant.Himall_ShopBonus.BonusDateEnd > DateTime.Now));
        //    userCenterModel.RefundCount = this.context.OrderRefundInfo.Count<OrderRefundInfo>((OrderRefundInfo a) => a.UserId == id && (int)a.SellerAuditStatus != 4 && (int)a.ManagerConfirmStatus != 7);
        //    userCenterModel.WaitPayOrders = (long)(
        //        from a in list
        //        where a.OrderStatus == OrderInfo.OrderOperateStatus.WaitPay
        //        select a).Count<OrderInfo>();
        //    userCenterModel.WaitReceivingOrders = (long)(
        //        from a in list
        //        where a.OrderStatus == OrderInfo.OrderOperateStatus.WaitReceiving
        //        select a).Count<OrderInfo>();
        //    userCenterModel.WaitEvaluationOrders = (long)(
        //        from a in list
        //        where (a.OrderStatus != OrderInfo.OrderOperateStatus.Finish ? false : a.OrderCommentInfo.Count == 0)
        //        select a).Count<OrderInfo>();
        //    userCenterModel.FollowProductCount = this.context.FavoriteInfo.Count<FavoriteInfo>((FavoriteInfo a) => a.UserId == id);
        //    if (userCenterModel.FollowProductCount > 0)
        //    {
        //        userCenterModel.FollwProducts = (
        //            from a in (IEnumerable<FavoriteInfo>)(
        //                from a in this.context.FavoriteInfo
        //                where a.UserId == id
        //                orderby a.Id descending
        //                select a).ToArray<FavoriteInfo>()
        //            select new FollowProduct()
        //            {
        //                ProductId = a.ProductId,
        //                ProductName = a.ProductInfo.ProductName,
        //                Price = a.ProductInfo.MinSalePrice,
        //                ImagePath = a.ProductInfo.ImagePath
        //            }).Take<FollowProduct>(4).ToList<FollowProduct>();
        //    }
        //    FavoriteShopInfo[] array = (
        //        from a in this.context.FavoriteShopInfo.Include("Himall_Shops")
        //        where a.UserId == id
        //        orderby a.Id descending
        //        select a).ToArray<FavoriteShopInfo>();
        //    userCenterModel.FollowShopsCount = (int)array.Length;
        //    if ((int)array.Length > 0)
        //    {
        //        List<FollowShop> followShops = (
        //            from a in (IEnumerable<FavoriteShopInfo>)array
        //            select new FollowShop()
        //            {
        //                ShopName = a.Himall_Shops.ShopName,
        //                Logo = a.Himall_Shops.Logo,
        //                ShopID = a.ShopId
        //            }).Take<FollowShop>(4).ToList<FollowShop>();
        //        userCenterModel.FollowShops = followShops;
        //    }
        //    userCenterModel.Orders = Instance<IOrderService>.Create.GetTopOrders(3, id);
        //    userCenterModel.FollowShopCartsCount = this.context.ShoppingCartItemInfo.Count<ShoppingCartItemInfo>((ShoppingCartItemInfo a) => a.UserId == id);
        //    if (userCenterModel.FollowShopCartsCount > 0)
        //    {
        //        List<ProductInfo> productInfos = (
        //            from p in this.context.ShoppingCartItemInfo
        //            join o in this.context.ProductInfo on p.ProductId equals o.Id
        //            join x in this.context.ShopInfo on o.ShopId equals x.Id
        //            where p.UserId == id && (int)o.SaleStatus != 4
        //            select o).Distinct<ProductInfo>().Take<ProductInfo>(4).ToList<ProductInfo>();
        //        userCenterModel.FollowShopCarts = (
        //            from o in productInfos
        //            select new FollowShopCart()
        //            {
        //                ImagePath = o.ImagePath,
        //                ProductName = o.ProductName,
        //                ProductId = o.Id
        //            }).ToList<FollowShopCart>();
        //    }
        //    return userCenterModel;
        //}

        public void LockMember(long id)
        {
            UserMemberInfo userMemberInfo = this.context.UserMemberInfo.FindById<UserMemberInfo>(id);
            userMemberInfo.Disabled = true;
            this.context.SaveChanges();
            Cache.Remove(CacheKeyCollection.Member(id));
        }

        //public UserMemberInfo Login(string username, string password)
        //{
        //    UserMemberInfo now = this.context.UserMemberInfo.FindBy<UserMemberInfo>((UserMemberInfo item) => item.UserName == username).FirstOrDefault<UserMemberInfo>();
        //    if (now != null)
        //    {
        //        if (!(this.GetPasswrodWithTwiceEncode(password, now.PasswordSalt).ToLower() != now.Password))
        //        {
        //            if (now.Disabled)
        //            {
        //                throw new TaoLaException("账号已被冻结");
        //            }
        //            now.LastLoginDate = DateTime.Now;
        //            this.context.SaveChanges();
        //            Task.Factory.StartNew(() => this.AddIntegel(now));
        //            Cache.Remove(CacheKeyCollection.Member(now.Id));
        //        }
        //        else
        //        {
        //            now = null;
        //        }
        //    }
        //    return now;
        //}

        //public UserMemberInfo QuickRegister(string username, string realName, string nickName, string serviceProvider, string openId, string headImage = null, MemberOpenIdInfo.AppIdTypeEnum appidtype = MemberOpenIdInfo.AppIdTypeEnum.Normal, string unionid = null, string unionopenid = null)
        //{
        //    username = this.GetNewUserName();
        //    this.CheckInputIsValidWhenQuickRegister(username, serviceProvider, openId);
        //    this.CheckOpenIdHasBeenUsed(serviceProvider, openId, (long)0);
        //    if (string.IsNullOrWhiteSpace(nickName))
        //    {
        //        nickName = username;
        //    }
        //    Guid guid = Guid.NewGuid();
        //    string str = string.Concat("o", guid.ToString("N").Substring(12));
        //    string passwrodWithTwiceEncode = this.GetPasswrodWithTwiceEncode("", str);
        //    UserMemberInfo userMemberInfo = new UserMemberInfo()
        //    {
        //        UserName = username,
        //        PasswordSalt = str,
        //        CreateDate = DateTime.Now,
        //        LastLoginDate = DateTime.Now,
        //        Nick = nickName,
        //        RealName = realName
        //    };
        //    UserMemberInfo userMemberInfo1 = userMemberInfo;
        //    if (this.context.UserMemberInfo.Any<UserMemberInfo>((UserMemberInfo d) => d.UserName == userMemberInfo1.UserName))
        //    {
        //        throw new TaoLaException("用户名被占用");
        //    }
        //    TransactionScope transactionScope = new TransactionScope();
        //    try
        //    {
        //        userMemberInfo1.Password = passwrodWithTwiceEncode;
        //        userMemberInfo1 = this.context.UserMemberInfo.Add(userMemberInfo1);
        //        this.context.SaveChanges();
        //        MemberOpenIdInfo memberOpenIdInfo = new MemberOpenIdInfo()
        //        {
        //            UserId = userMemberInfo1.Id,
        //            OpenId = openId,
        //            ServiceProvider = serviceProvider,
        //            AppIdType = appidtype,
        //            UnionId = (string.IsNullOrWhiteSpace(unionid) ? string.Empty : unionid),
        //            UnionOpenId = (string.IsNullOrWhiteSpace(unionopenid) ? string.Empty : unionopenid)
        //        };
        //        this.context.MemberOpenIdInfo.Add(memberOpenIdInfo);
        //        this.context.SaveChanges();
        //        if (!string.IsNullOrWhiteSpace(headImage))
        //        {
        //            userMemberInfo1.Photo = this.TransferHeadImage(headImage, userMemberInfo1.Id);
        //        }
        //        this.context.SaveChanges();
        //        transactionScope.Complete();
        //    }
        //    finally
        //    {
        //        if (transactionScope != null)
        //        {
        //            ((IDisposable)transactionScope).Dispose();
        //        }
        //    }
        //    return userMemberInfo1;

        //}

        //public UserMemberInfo Register(string username, string password, string mobile = "", long introducer = 0L)
        //{
        //    UserMemberInfo nullable;
        //    if (string.IsNullOrWhiteSpace(username))
        //    {
        //        throw new ArgumentNullException("用户名不能为空");
        //    }
        //    if (this.CheckMemberExist(username))
        //    {
        //        throw new TaoLaException(string.Concat("用户名 ", username, " 已经被其它会员注册"));
        //    }
        //    if (string.IsNullOrWhiteSpace(password))
        //    {
        //        throw new ArgumentNullException("密码不能为空");
        //    }
        //    if ((string.IsNullOrEmpty(mobile) ? false : ValidateHelper.IsMobile(mobile)))
        //    {
        //        if (this.CheckMobileExist(mobile))
        //        {
        //            throw new TaoLaException("手机号已经被其它会员注册");
        //        }
        //    }
        //    password = password.Trim();
        //    Guid guid = Guid.NewGuid();
        //    string str = guid.ToString("N").Substring(12);
        //    password = this.GetPasswrodWithTwiceEncode(password, str);
        //    TransactionScope transactionScope = new TransactionScope();
        //    try
        //    {
        //        UserMemberInfo userMemberInfo = new UserMemberInfo()
        //        {
        //            UserName = username,
        //            PasswordSalt = str,
        //            CreateDate = DateTime.Now,
        //            LastLoginDate = DateTime.Now,
        //            Nick = username,
        //            RealName = username,
        //            CellPhone = mobile
        //        };
        //        nullable = userMemberInfo;
        //        if (introducer != (long)0)
        //        {
        //            nullable.InviteUserId = new long?(introducer);
        //        }
        //        nullable.Password = password;
        //        nullable = this.context.UserMemberInfo.Add(nullable);
        //        this.context.SaveChanges();
        //        if ((string.IsNullOrEmpty(mobile) ? false : ValidateHelper.IsMobile(mobile)))
        //        {
        //            IMessageService create = Instance<IMessageService>.Create;
        //            MemberContactsInfo memberContactsInfo = new MemberContactsInfo()
        //            {
        //                Contact = mobile,
        //                ServiceProvider = "Himall.Plugin.Message.SMS",
        //                UserId = nullable.Id,
        //                UserType = MemberContactsInfo.UserTypes.General
        //            };
        //            create.UpdateMemberContacts(memberContactsInfo);
        //            MemberIntegralRecord memberIntegralRecord = new MemberIntegralRecord()
        //            {
        //                UserName = username,
        //                MemberId = nullable.Id,
        //                RecordDate = new DateTime?(DateTime.Now),
        //                TypeId = MemberIntegral.IntegralType.Reg,
        //                ReMark = "绑定手机"
        //            };
        //            IConversionMemberIntegralBase conversionMemberIntegralBase = Instance<IMemberIntegralConversionFactoryService>.Create.Create(MemberIntegral.IntegralType.Reg, 0);
        //            Instance<IMemberIntegralService>.Create.AddMemberIntegral(memberIntegralRecord, conversionMemberIntegralBase);
        //            IMemberInviteService memberInviteService = Instance<IMemberInviteService>.Create;
        //            if (introducer != (long)0)
        //            {
        //                UserMemberInfo member = this.GetMember(introducer);
        //                if (member != null)
        //                {
        //                    memberInviteService.AddInviteIntegel(nullable, member);
        //                }
        //            }
        //        }
        //        transactionScope.Complete();
        //    }
        //    finally
        //    {
        //        if (transactionScope != null)
        //        {
        //            ((IDisposable)transactionScope).Dispose();
        //        }
        //    }
        //    return nullable;
        //}
        //public UserMemberInfo Register(string username, string password, string serviceProvider, string openId, string headImage = null, long introducer = 0L, string nickname = null, string unionid = null)
        //{
        //    if (string.IsNullOrWhiteSpace(serviceProvider))
        //    {
        //        throw new ArgumentNullException("信任登录提供商不能为空");
        //    }
        //    if (string.IsNullOrWhiteSpace(openId))
        //    {
        //        throw new ArgumentNullException("openId不能为空");
        //    }
        //    this.CheckOpenIdHasBeenUsed(serviceProvider, openId, (long)0);
        //    if (string.IsNullOrWhiteSpace(username))
        //    {
        //        throw new ArgumentNullException("用户名不能为空");
        //    }
        //    if (this.CheckMemberExist(username))
        //    {
        //        throw new TaoLaException(string.Concat("用户名 ", username, " 已经被其它会员注册"));
        //    }
        //    if (string.IsNullOrWhiteSpace(password))
        //    {
        //        throw new ArgumentNullException("密码不能为空");
        //    }
        //    password = password.Trim();
        //    UserMemberInfo userMemberInfo = new UserMemberInfo()
        //    {
        //        UserName = username
        //    };
        //    Guid guid = Guid.NewGuid();
        //    userMemberInfo.PasswordSalt = guid.ToString("N").Substring(12);
        //    userMemberInfo.CreateDate = DateTime.Now;
        //    userMemberInfo.LastLoginDate = DateTime.Now;
        //    userMemberInfo.Nick = (string.IsNullOrWhiteSpace(nickname) ? username : nickname);
        //    UserMemberInfo nullable = userMemberInfo;
        //    if (introducer != (long)0)
        //    {
        //        nullable.InviteUserId = new long?(introducer);
        //    }
        //    TransactionScope transactionScope = new TransactionScope();
        //    try
        //    {
        //        nullable.Password = this.GetPasswrodWithTwiceEncode(password, nullable.PasswordSalt);
        //        nullable = this.context.UserMemberInfo.Add(nullable);
        //        this.context.SaveChanges();
        //        MemberOpenIdInfo memberOpenIdInfo = new MemberOpenIdInfo()
        //        {
        //            UserId = nullable.Id,
        //            OpenId = openId,
        //            ServiceProvider = serviceProvider,
        //            UnionId = (string.IsNullOrWhiteSpace(unionid) ? string.Empty : unionid)
        //        };
        //        this.context.MemberOpenIdInfo.Add(memberOpenIdInfo);
        //        this.context.SaveChanges();
        //        if (!string.IsNullOrWhiteSpace(headImage))
        //        {
        //            nullable.Photo = this.TransferHeadImage(headImage, nullable.Id);
        //        }
        //        this.context.SaveChanges();
        //        transactionScope.Complete();
        //    }
        //    finally
        //    {
        //        if (transactionScope != null)
        //        {
        //            ((IDisposable)transactionScope).Dispose();
        //        }
        //    }
        //    return nullable;
        //}

        //public UserMemberInfo Register(OAuthUserModel model)
        //{
        //    long? nullable;
        //    bool value;
        //    if (string.IsNullOrWhiteSpace(model.LoginProvider))
        //    {
        //        throw new ArgumentNullException("信任登录提供商不能为空");
        //    }
        //    if (string.IsNullOrWhiteSpace(model.OpenId))
        //    {
        //        throw new ArgumentNullException("openId不能为空");
        //    }
        //    this.CheckOpenIdHasBeenUsed(model.LoginProvider, model.OpenId, (long)0);
        //    if (string.IsNullOrWhiteSpace(model.UserName))
        //    {
        //        throw new ArgumentNullException("用户名不能为空");
        //    }
        //    if (this.CheckMemberExist(model.UserName))
        //    {
        //        throw new TaoLaException(string.Concat("用户名 ", model.UserName, " 已经被其它会员注册"));
        //    }
        //    if (string.IsNullOrWhiteSpace(model.Password))
        //    {
        //        throw new ArgumentNullException("密码不能为空");
        //    }
        //    string str = model.Password.Trim();
        //    int num = 0;
        //    if (int.TryParse(model.Sex, out num))
        //    {
        //    }
        //    UserMemberInfo userMemberInfo = new UserMemberInfo()
        //    {
        //        UserName = model.UserName
        //    };
        //    Guid guid = Guid.NewGuid();
        //    userMemberInfo.PasswordSalt = guid.ToString("N").Substring(12);
        //    userMemberInfo.CreateDate = DateTime.Now;
        //    userMemberInfo.LastLoginDate = DateTime.Now;
        //    userMemberInfo.Nick = (string.IsNullOrWhiteSpace(model.NickName) ? model.UserName : model.NickName);
        //    userMemberInfo.Sex = new UserMemberInfo.SexType?((UserMemberInfo.SexType)num);
        //    UserMemberInfo passwrodWithTwiceEncode = userMemberInfo;
        //    if (!model.introducer.HasValue)
        //    {
        //        value = true;
        //    }
        //    else
        //    {
        //        nullable = model.introducer;
        //        value = nullable.Value == (long)0;
        //    }
        //    if (!value)
        //    {
        //        nullable = model.introducer;
        //        passwrodWithTwiceEncode.InviteUserId = new long?(nullable.Value);
        //    }
        //    TransactionScope transactionScope = new TransactionScope();
        //    try
        //    {
        //        passwrodWithTwiceEncode.Password = this.GetPasswrodWithTwiceEncode(str, passwrodWithTwiceEncode.PasswordSalt);
        //        passwrodWithTwiceEncode = this.context.UserMemberInfo.Add(passwrodWithTwiceEncode);
        //        this.context.SaveChanges();
        //        MemberOpenIdInfo memberOpenIdInfo = new MemberOpenIdInfo()
        //        {
        //            UserId = passwrodWithTwiceEncode.Id,
        //            OpenId = model.OpenId,
        //            ServiceProvider = model.LoginProvider,
        //            UnionId = (string.IsNullOrWhiteSpace(model.UnionId) ? string.Empty : model.UnionId)
        //        };
        //        this.context.MemberOpenIdInfo.Add(memberOpenIdInfo);
        //        this.context.SaveChanges();
        //        if (!string.IsNullOrWhiteSpace(model.Headimgurl))
        //        {
        //            passwrodWithTwiceEncode.Photo = this.TransferHeadImage(model.Headimgurl, passwrodWithTwiceEncode.Id);
        //        }
        //        this.context.SaveChanges();
        //        transactionScope.Complete();
        //    }
        //    finally
        //    {
        //        if (transactionScope != null)
        //        {
        //            ((IDisposable)transactionScope).Dispose();
        //        }
        //    }
        //    return passwrodWithTwiceEncode;
        //}

        public void SetMemberLabel(long userid, IEnumerable<long> labelids)
        {
            IQueryable<MemberLabelInfo> memberLabelInfo =
                from e in this.context.MemberLabelInfo
                where e.MemId == userid
                select e;
            this.context.MemberLabelInfo.RemoveRange(memberLabelInfo);
            if (labelids.Count<long>() > 0)
            {
                IEnumerable<MemberLabelInfo> memberLabelInfos =
                    from e in labelids
                    select new MemberLabelInfo()
                    {
                        LabelId = e,
                        MemId = userid
                    };
                this.context.MemberLabelInfo.AddRange(memberLabelInfos);
            }
            this.context.SaveChanges();
        }

        public void SetMembersLabel(long[] userid, IEnumerable<long> labelids)
        {
            List<MemberLabelInfo> list = (
                from e in this.context.MemberLabelInfo
                where userid.Contains<long>(e.MemId) && labelids.Contains<long>(e.LabelId)
                select e).ToList<MemberLabelInfo>();
            long[] numArray = userid;
            Func<long, IEnumerable<long>> func = (long u) => labelids;
            var collection = ((IEnumerable<long>)numArray).SelectMany(func, (long u, long l) => new { uid = u, lid = l });
            IEnumerable<MemberLabelInfo> memberLabelInfos =
                from m in collection
                where !list.Any<MemberLabelInfo>((MemberLabelInfo l) => (m.lid != l.LabelId ? false : m.uid == l.MemId))
                select new MemberLabelInfo()
                {
                    LabelId = m.lid,
                    MemId = m.uid
                };
            this.context.MemberLabelInfo.AddRange(memberLabelInfos);
            this.context.SaveChanges();
        }

        //private string TransferHeadImage(string image, long memberId)
        //{
        //    string str;
        //    DateTime now;
        //    string empty = string.Empty;
        //    if (!string.IsNullOrWhiteSpace(image))
        //    {
        //        if (image.StartsWith("http://"))
        //        {
        //            WebClient webClient = new WebClient();
        //            string str1 = image.Substring(image.LastIndexOf('/'));
        //            string empty1 = string.Empty;
        //            empty1 = (str1.LastIndexOf('.') > 0 ? str1.Substring(str1.LastIndexOf('.')) : string.Empty);
        //            now = DateTime.Now;
        //            str = string.Concat("/temp/", now.ToString("yyMMddHHmmssff"), empty1);
        //            try
        //            {
        //                webClient.DownloadFile(image, IOHelper.GetMapPath(str));
        //            }
        //            catch
        //            {
        //                empty = null;
        //            }
        //            image = str;
        //        }
        //        if (image.StartsWith("/temp/"))
        //        {
        //            if (!image.EndsWith(".jpg"))
        //            {
        //                now = DateTime.Now;
        //                str = string.Concat("/temp/", now.ToString("yyMMddHHmmssffff"), ".jpg");
        //                ImageHelper.TranserImageFormat(IOHelper.GetMapPath(image), IOHelper.GetMapPath(str), ImageFormat.Jpeg);
        //                image = str;
        //            }
        //            string str2 = string.Format("/Storage/Member/{0}", memberId);
        //            string mapPath = IOHelper.GetMapPath(str2);
        //            if (!Directory.Exists(mapPath))
        //            {
        //                Directory.CreateDirectory(mapPath);
        //            }
        //            empty = string.Concat(str2, "/headImage.jpg");
        //            File.Copy(IOHelper.GetMapPath(image), IOHelper.GetMapPath(empty), true);
        //        }
        //    }
        //    return empty;
        //}

        public void UnLockMember(long id)
        {
            UserMemberInfo userMemberInfo = this.context.UserMemberInfo.FindById<UserMemberInfo>(id);
            userMemberInfo.Disabled = false;
            this.context.SaveChanges();
            Cache.Remove(CacheKeyCollection.Member(id));
        }

        public void UpdateDistributionUserLink(IEnumerable<long> ids, long userId)
        {
            if ((ids.Count<long>() <= 0 ? false : userId > (long)0))
            {
                List<DistributionUserLinkInfo> list = (
                    from d in this.context.DistributionUserLinkInfo
                    where ids.Contains<long>(d.Id)
                    select d).ToList<DistributionUserLinkInfo>();
                foreach (DistributionUserLinkInfo distributionUserLinkInfo in list)
                {
                    distributionUserLinkInfo.BuyUserId = userId;
                }
                this.context.SaveChanges();
            }
            this.ClearExpiredLinkData();
        }

        public void UpdateMember(UserMemberInfo model)
        {
            UserMemberInfo nick = this.context.UserMemberInfo.FindById<UserMemberInfo>(model.Id);
            nick.Nick = model.Nick;
            nick.RealName = model.RealName;
            nick.Email = model.Email;
            nick.QQ = model.QQ;
            nick.CellPhone = model.CellPhone;
            this.context.SaveChanges();
            Cache.Remove(CacheKeyCollection.Member(model.Id));
        }

        public long UpdateShareUserId(long id, long shareUserId, long shopId)
        {
            DistributionUserLinkInfo distributionUserLinkInfo;
            long num = (long)0;
            if ((shopId <= (long)0 ? false : shareUserId > (long)0))
            {
                bool flag = true;
                if (id > (long)0)
                {
                    distributionUserLinkInfo = this.context.DistributionUserLinkInfo.FirstOrDefault<DistributionUserLinkInfo>((DistributionUserLinkInfo d) => d.BuyUserId == id && d.ShopId == shopId);
                    if (distributionUserLinkInfo != null)
                    {
                        flag = false;
                        if (distributionUserLinkInfo.PartnerId != shareUserId)
                        {
                            distributionUserLinkInfo.PartnerId = shareUserId;
                            this.context.SaveChanges();
                        }
                    }
                }
                if (flag)
                {
                    distributionUserLinkInfo = new DistributionUserLinkInfo()
                    {
                        PartnerId = shareUserId,
                        ShopId = shopId,
                        BuyUserId = id,
                        LinkTime = new DateTime?(DateTime.Now)
                    };
                    this.context.DistributionUserLinkInfo.Add(distributionUserLinkInfo);
                    this.context.SaveChanges();
                    if (id == (long)0)
                    {
                        num = distributionUserLinkInfo.Id;
                    }
                }
            }
            return num;
        }

        public UserMemberInfo Register(string username, string password, string mobile = "", long introducer = 0)
        {
            throw new NotImplementedException();
        }

        public UserMemberInfo Register(string username, string password, string serviceProvider, string openId, string headImage = null, long introducer = 0, string nickname = null, string unionid = null)
        {
            throw new NotImplementedException();
        }

        public UserMemberInfo Register(OAuthUserModel model)
        {
            throw new NotImplementedException();
        }

        public UserMemberInfo QuickRegister(string username, string realName, string nickName, string serviceProvider, string openId, string headImage = null, MemberOpenIdInfo.AppIdTypeEnum appidtype = MemberOpenIdInfo.AppIdTypeEnum.Normal, string unionid = null, string unionopenid = null)
        {
            throw new NotImplementedException();
        }

        public void BindMember(long userId, string serviceProvider, string openId, string headImage = null, string unionid = null, string unionopenid = null)
        {
            throw new NotImplementedException();
        }

        public void BindMember(long userId, string serviceProvider, string openId, MemberOpenIdInfo.AppIdTypeEnum AppidType, string headImage = null, string unionid = null)
        {
            throw new NotImplementedException();
        }

        public void BindMember(OAuthUserModel model)
        {
            throw new NotImplementedException();
        }

        public UserMemberInfo Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public UserCenterModel GetUserCenterModel(long id)
        {
            throw new NotImplementedException();
        }
    }
}
