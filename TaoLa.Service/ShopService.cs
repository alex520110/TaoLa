using Himall.Entity;
using Himall.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaoLa.IServices;

namespace TaoLa.Service
{
    public class ShopService : ServiceBase, IShopService, IService, IDisposable
    {
        public ShopInfo GetShop(long id, bool businessCategoryOn = false)
        {
            ShopInfo shopInfo;
            ShopInfo nums = this.context.ShopInfo.FindById<ShopInfo>(id);
            if (null != nums)
            {
                ManagerInfo managerInfo = this.context.ManagerInfo.FirstOrDefault<ManagerInfo>((ManagerInfo m) => m.ShopId.Equals(nums.Id));
                nums.ShopAccount = (managerInfo == null ? "" : managerInfo.UserName);
                if (businessCategoryOn)
                {
                    nums.BusinessCategory = new Dictionary<long, decimal>();
                    foreach (BusinessCategoryInfo list in this.GetBusinessCategory(id).ToList<BusinessCategoryInfo>())
                    {
                        if (!nums.BusinessCategory.ContainsKey(list.CategoryId))
                        {
                            nums.BusinessCategory.Add(list.CategoryId, list.CommisRate);
                        }
                    }
                }
                shopInfo = nums;
            }
            else
            {
                shopInfo = null;
            }
            return shopInfo;
        }

        public IQueryable<BusinessCategoryInfo> GetBusinessCategory(long id)
        {
            IQueryable<BusinessCategoryInfo> businessCategoryInfos = this.context.BusinessCategoryInfo.FindBy<BusinessCategoryInfo>((BusinessCategoryInfo b) => b.ShopId.Equals(id));
            foreach (BusinessCategoryInfo list in businessCategoryInfos.ToList<BusinessCategoryInfo>())
            {
                list.CategoryName = this.GetCategoryNameByPath(list.CategoryId);
            }
            return businessCategoryInfos;
        }
        private string GetCategoryNameByPath(long id)
        {
            string str;
            CategoryInfo categoryInfo = this.context.CategoryInfo.FindById<CategoryInfo>(id);
            str = ((categoryInfo.Depth != 1 ? true : categoryInfo.ParentCategoryId != (long)0) ? string.Concat(this.GetCategoryNameByPath(categoryInfo.ParentCategoryId), " > ", categoryInfo.Name) : categoryInfo.Name);
            return str;
        }


        public PlatConsoleModel GetPlatConsoleMode()
        {
            DbSet<ShopInfo> shopInfo = this.context.ShopInfo;
            DbSet<OrderInfo> orderInfo = this.context.OrderInfo;
            IQueryable<ProductInfo> productInfo =
                from item in this.context.ProductInfo
                where (int)item.SaleStatus != 4
                select item;
            DbSet<OrderRefundInfo> orderRefundInfo = this.context.OrderRefundInfo;
            DbSet<ProductCommentInfo> productCommentInfo = this.context.ProductCommentInfo;
            DbSet<ProductConsultationInfo> productConsultationInfo = this.context.ProductConsultationInfo;
            DbSet<OrderComplaintInfo> orderComplaintInfo = this.context.OrderComplaintInfo;
            DbSet<UserMemberInfo> userMemberInfo = this.context.UserMemberInfo;
            PlatConsoleModel platConsoleModel = new PlatConsoleModel();
            DateTime date = DateTime.Now.Date;
            DateTime dateTime = DateTime.Now.Date.AddDays(-1);
            int num = 0;
            decimal? nullable = (
                from a in orderInfo
                where (int)a.OrderStatus != 4 && (int)a.OrderStatus != 1 && (a.PayDate >= (DateTime?)date)
                select a).Sum<OrderInfo>((OrderInfo a) => (decimal?)(a.ProductTotalAmount + a.Freight + a.Tax - a.DiscountAmount));
            platConsoleModel.TodaySaleAmount = new decimal?(nullable.GetValueOrDefault());
            platConsoleModel.TodayMemberIncrease = (long)(
                from a in userMemberInfo
                where a.CreateDate >= date
                select a).Count<UserMemberInfo>();
            platConsoleModel.TodayShopIncrease = (long)(
                from a in shopInfo
                where (a.CreateDate >= date) && (int)a.ShopStatus == 7 && (int?)a.Stage == (int?)ShopInfo.ShopStage.Finish
                select a).Count<ShopInfo>();
            platConsoleModel.YesterdayShopIncrease = (long)(
                from a in shopInfo
                where (a.CreateDate >= dateTime) && (a.CreateDate < date) && (int)a.ShopStatus == 7 && (int?)a.Stage == (int?)ShopInfo.ShopStage.Finish
                select a).Count<ShopInfo>();
            platConsoleModel.WaitAuditShops = (long)(
                from a in shopInfo
                where (int)a.ShopStatus == 2 || (int)a.ShopStatus == 5
                select a).Count<ShopInfo>();
            platConsoleModel.ExpiredShops = (long)(
                from a in shopInfo
                where a.EndDate < (DateTime?)date
                select a).Count<ShopInfo>();
            platConsoleModel.ShopNum = (long)shopInfo.Count<ShopInfo>((ShopInfo a) => (int)a.ShopStatus == 7 && (int?)a.Stage == (int?)ShopInfo.ShopStage.Finish);
            platConsoleModel.WaitForAuditingBrands = this.context.ShopBrandApplysInfo.Count<ShopBrandApplysInfo>((ShopBrandApplysInfo a) => a.AuditStatus == num);
            platConsoleModel.ProductNum = (long)productInfo.Count<ProductInfo>();
            platConsoleModel.OnSaleProducts = (
                from a in productInfo
                where (int)a.SaleStatus == 1 && (int)a.AuditStatus == 2
                select a).Count<ProductInfo>();
            platConsoleModel.WaitForAuditingProducts = (
                from a in productInfo
                where (int)a.AuditStatus == 1 && (int)a.SaleStatus == 1
                select a).Count<ProductInfo>();
            platConsoleModel.ProductComments = (long)productCommentInfo.Count<ProductCommentInfo>();
            platConsoleModel.ProductConsultations = (long)productConsultationInfo.Count<ProductConsultationInfo>();
            platConsoleModel.WaitPayTrades = (long)(
                from a in orderInfo
                where (int)a.OrderStatus == 1
                select a).Count<OrderInfo>();
            platConsoleModel.RefundTrades = (long)(
                from a in orderRefundInfo
                where (int)a.RefundMode != 3 && (int)a.SellerAuditStatus == 5 && (int)a.ManagerConfirmStatus == 6
                select a).Count<OrderRefundInfo>();
            platConsoleModel.OrderWithRefundAndRGoods = (long)(
                from a in orderRefundInfo
                where (int)a.RefundMode == 3 && (int)a.SellerAuditStatus == 5 && (int)a.ManagerConfirmStatus == 6
                select a).Count<OrderRefundInfo>();
            platConsoleModel.WaitDeliveryTrades = (long)(
                from a in orderInfo
                where (int)a.OrderStatus == 2
                select a).Count<OrderInfo>();
            platConsoleModel.Complaints = (long)orderComplaintInfo.Count<OrderComplaintInfo>((OrderComplaintInfo a) => (int)a.Status == 3);
            platConsoleModel.OrderCounts = (
                from a in orderInfo
                where (int)a.OrderStatus == 5
                select a).Count<OrderInfo>();
            platConsoleModel.Cash = (long)(
                from a in this.context.ApplyWithDrawInfo
                where (int)a.ApplyStatus == 1
                select a).Count<ApplyWithDrawInfo>();
            platConsoleModel.GiftSend = (long)(
                from a in this.context.GiftOrderInfo
                where (int)a.OrderStatus == 2
                select a).Count<GiftOrderInfo>();
            return platConsoleModel;
        }

    }
}
