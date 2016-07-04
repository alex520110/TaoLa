using Himall.Entity;
using Himall.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaoLa.Core;
using TaoLa.IServices;
using TaoLa.IServices.QueryModel;
using TaoLa.ServiceProvider;

namespace TaoLa.Service
{
    public class CashDepositsService : ServiceBase, ICashDepositsService, IService, IDisposable
    {
        public CashDepositsService()
        {
        }

        public void AddCashDeposit(CashDepositInfo cashDeposit)
        {
            this.context.CashDepositInfo.Add(cashDeposit);
            this.context.SaveChanges();
        }

        public void AddCashDepositDetails(CashDepositDetailInfo cashDepositDetail)
        {
            this.context.CashDepositDetailInfo.Add(cashDepositDetail);
            CashDepositInfo currentBalance = this.context.CashDepositInfo.FindById<CashDepositInfo>(cashDepositDetail.CashDepositId);
            if ((cashDepositDetail.Balance >= new decimal(0) ? false : (currentBalance.CurrentBalance + cashDepositDetail.Balance) < new decimal(0)))
            {
                TaoLaException exception = new TaoLaException("扣除金额不能多余店铺可用余额");
            }
            currentBalance.CurrentBalance = currentBalance.CurrentBalance + cashDepositDetail.Balance;
            if (cashDepositDetail.Balance > new decimal(0))
            {
                currentBalance.EnableLabels = true;
            }
            if (cashDepositDetail.Balance > new decimal(0))
            {
                currentBalance.TotalBalance = currentBalance.TotalBalance + cashDepositDetail.Balance;
                currentBalance.Date = DateTime.Now;
            }
            this.context.SaveChanges();
        }

        public void AddCategoryCashDeposits(CategoryCashDepositInfo model)
        {
            this.context.CategoryCashDepositInfo.Add(model);
            this.context.SaveChanges();
        }

        public void CloseNoReasonReturn(long categoryId)
        {
            CategoryCashDepositInfo categoryCashDepositInfo = (
                from item in this.context.CategoryCashDepositInfo
                where item.CategoryId == categoryId
                select item).FirstOrDefault<CategoryCashDepositInfo>();
            categoryCashDepositInfo.EnableNoReasonReturn = false;
            this.context.SaveChanges();
        }

        public void DeleteCategoryCashDeposits(long categoryId)
        {
            CategoryCashDepositInfo categoryCashDepositInfo = (
                from item in this.context.CategoryCashDepositInfo
                where item.CategoryId == categoryId
                select item).FirstOrDefault<CategoryCashDepositInfo>();
            if (categoryCashDepositInfo != null)
            {
                this.context.CategoryCashDepositInfo.Remove(categoryCashDepositInfo);
                this.context.SaveChanges();
            }
        }

        public CashDepositInfo GetCashDeposit(long id)
        {
            return this.context.CashDepositInfo.FindById<CashDepositInfo>(id);
        }

        public CashDepositInfo GetCashDepositByShopId(long shopId)
        {
            CashDepositInfo cashDepositInfo = (
                from item in this.context.CashDepositInfo
                where item.ShopId == shopId
                select item).FirstOrDefault<CashDepositInfo>();
            return cashDepositInfo;
        }

        public PageModel<CashDepositDetailInfo> GetCashDepositDetails(CashDepositDetailQuery query)
        {
            int num;
            IQueryable<CashDepositDetailInfo> startDate = this.context.CashDepositDetailInfo.AsQueryable<CashDepositDetailInfo>();
            if (query.StartDate.HasValue)
            {
                startDate =
                    from item in startDate
                    where query.StartDate <= (DateTime?)item.AddDate
                    select item;
            }
            if (query.EndDate.HasValue)
            {
                startDate =
                    from item in startDate
                    where query.EndDate >= (DateTime?)item.AddDate
                    select item;
            }
            if (!string.IsNullOrWhiteSpace(query.Operator))
            {
                startDate =
                    from item in startDate
                    where item.Operator.Contains(query.Operator)
                    select item;
            }
            startDate = startDate.FindBy<CashDepositDetailInfo, DateTime>((CashDepositDetailInfo item) => item.CashDepositId == query.CashDepositId, query.PageNo, query.PageSize, out num, (CashDepositDetailInfo item) => item.AddDate, false);
            return new PageModel<CashDepositDetailInfo>()
            {
                Models = startDate,
                Total = num
            };
        }

        public PageModel<CashDepositInfo> GetCashDeposits(CashDepositQuery query)
        {
            throw new NotImplementedException();
        }

        public CashDepositsObligation GetCashDepositsObligation(long productId)
        {
            throw new NotImplementedException();
        }

        //public PageModel<CashDepositInfo> GetCashDeposits(CashDepositQuery query)
        //{
        //    int num;
        //    IQueryable<CashDepositInfo> page = this.context.CashDepositInfo.AsQueryable<CashDepositInfo>();
        //    if (!string.IsNullOrWhiteSpace(query.ShopName))
        //    {
        //        page =
        //            from item in page
        //            where item.Himall_Shops.ShopName.Contains(query.ShopName)
        //            select item;
        //    }
        //    List<CashDepositInfo> list = page.ToList<CashDepositInfo>();
        //    List<long> nums = new List<long>();
        //    foreach (CashDepositInfo cashDepositInfo in list)
        //    {
        //        if (this.GetNeedPayCashDepositByShopId(cashDepositInfo.ShopId) > new decimal(0))
        //        {
        //            nums.Add(cashDepositInfo.ShopId);
        //        }
        //    }
        //    if (query.Type.HasValue)
        //    {
        //        page = (query.Type.Value ?
        //            from item in page
        //            where !nums.Contains(item.ShopId)
        //            select item :
        //            from item in page
        //            where nums.Contains(item.ShopId)
        //            select item);
        //    }
        //    page = page.GetPage<CashDepositInfo>(out num, query.PageNo, query.PageSize, (IQueryable<CashDepositInfo> d) =>
        //        from o in d
        //        orderby o.Date descending
        //        select o);
        //    return new PageModel<CashDepositInfo>()
        //    {
        //        Models = page,
        //        Total = num
        //    };
        //}

        //public CashDepositsObligation GetCashDepositsObligation(long productId)
        //{
        //    bool flag;
        //    CashDepositsObligation cashDepositsObligation = new CashDepositsObligation()
        //    {
        //        IsCustomerSecurity = false,
        //        IsSevenDayNoReasonReturn = false,
        //        IsTimelyShip = false
        //    };
        //    CashDepositsObligation enableNoReasonReturn = cashDepositsObligation;
        //    IProductService create = Instance<IProductService>.Create;
        //    IShopService shopService = Instance<IShopService>.Create;
        //    IShopCategoryService shopCategoryService = Instance<IShopCategoryService>.Create;
        //    ICategoryService categoryService = Instance<ICategoryService>.Create;
        //    ProductInfo product = create.GetProduct(productId);
        //    ShopInfo shop = shopService.GetShop(product.ShopId, false);
        //    CashDepositInfo cashDepositInfo = (
        //        from item in this.context.CashDepositInfo
        //        where item.ShopId == shop.Id
        //        select item).FirstOrDefault<CashDepositInfo>();
        //    List<CategoryInfo> list = shopCategoryService.GetBusinessCategory(shop.Id).ToList<CategoryInfo>();
        //    IEnumerable<long> parentCategoryId =
        //        from item in list
        //        where item.ParentCategoryId == (long)0
        //        select item.Id;
        //    decimal num = this.context.CategoryCashDepositInfo.FindBy<CategoryCashDepositInfo>((CategoryCashDepositInfo item) => parentCategoryId.Contains<long>(item.CategoryId)).Max<CategoryCashDepositInfo, decimal>((CategoryCashDepositInfo item) => item.NeedPayCashDeposit);
        //    if (shop.IsSelf || cashDepositInfo != null && cashDepositInfo.CurrentBalance >= num)
        //    {
        //        flag = false;
        //    }
        //    else
        //    {
        //        flag = (cashDepositInfo == null || !(cashDepositInfo.CurrentBalance < num) ? true : !cashDepositInfo.EnableLabels);
        //    }
        //    if (!flag)
        //    {
        //        List<long> nums = new List<long>()
        //        {
        //            product.CategoryId
        //        };
        //        CategoryInfo categoryInfo = categoryService.GetTopLevelCategories(nums).FirstOrDefault<CategoryInfo>();
        //        CategoryCashDepositInfo categoryCashDepositInfo = (
        //            from item in this.context.CategoryCashDepositInfo
        //            where item.CategoryId == categoryInfo.Id
        //            select item).FirstOrDefault<CategoryCashDepositInfo>();
        //        enableNoReasonReturn.IsSevenDayNoReasonReturn = categoryCashDepositInfo.EnableNoReasonReturn;
        //        enableNoReasonReturn.IsCustomerSecurity = true;
        //        if (product.Himall_FreightTemplate != null)
        //        {
        //            if (!string.IsNullOrEmpty(product.Himall_FreightTemplate.SendTime))
        //            {
        //                enableNoReasonReturn.IsTimelyShip = true;
        //            }
        //        }
        //    }
        //    return enableNoReasonReturn;
        //}

        public IEnumerable<CategoryCashDepositInfo> GetCategoryCashDeposits()
        {
            IEnumerable<CategoryCashDepositInfo> categoryCashDepositInfos = null;
            categoryCashDepositInfos = this.context.CategoryCashDepositInfo.Include("CategoriesInfo").DefaultIfEmpty<CategoryCashDepositInfo>();
            return categoryCashDepositInfos;
        }

        public decimal GetNeedPayCashDepositByShopId(long shopId)
        {
            throw new NotImplementedException();
        }

        //public decimal GetNeedPayCashDepositByShopId(long shopId)
        //{
        //    decimal num = new decimal(0, 0, 0, false, 2);
        //    IShopService create = Instance<IShopService>.Create;
        //    IShopCategoryService shopCategoryService = Instance<IShopCategoryService>.Create;
        //    List<CategoryInfo> list = shopCategoryService.GetBusinessCategory(shopId).ToList<CategoryInfo>();
        //    IEnumerable<long> parentCategoryId =
        //        from item in list
        //        where item.ParentCategoryId == (long)0
        //        select item.Id;
        //    decimal num1 = this.context.CategoryCashDepositInfo.FindBy<CategoryCashDepositInfo>((CategoryCashDepositInfo item) => parentCategoryId.Contains<long>(item.CategoryId)).Max<CategoryCashDepositInfo, decimal>((CategoryCashDepositInfo item) => item.NeedPayCashDeposit);
        //    CashDepositInfo cashDepositInfo = (
        //        from item in this.context.CashDepositInfo
        //        where item.ShopId == shopId
        //        select item).FirstOrDefault<CashDepositInfo>();
        //    if ((cashDepositInfo == null ? false : cashDepositInfo.CurrentBalance < num1))
        //    {
        //        num = num1 - cashDepositInfo.CurrentBalance;
        //    }
        //    if (cashDepositInfo == null)
        //    {
        //        num = num1;
        //    }
        //    return num;
        //}

        public void OpenNoReasonReturn(long categoryId)
        {
            CategoryCashDepositInfo categoryCashDepositInfo = (
                from item in this.context.CategoryCashDepositInfo
                where item.CategoryId == categoryId
                select item).FirstOrDefault<CategoryCashDepositInfo>();
            categoryCashDepositInfo.EnableNoReasonReturn = true;
            this.context.SaveChanges();
        }

        public void UpdateEnableLabels(long id, bool enableLabels)
        {
            CashDepositInfo cashDepositInfo = this.context.CashDepositInfo.FindById<CashDepositInfo>(id);
            cashDepositInfo.EnableLabels = enableLabels;
            this.context.SaveChanges();
        }

        public void UpdateNeedPayCashDeposit(long categoryId, decimal cashDeposit)
        {
            CategoryCashDepositInfo categoryCashDepositInfo = (
                from item in this.context.CategoryCashDepositInfo
                where item.CategoryId == categoryId
                select item).FirstOrDefault<CategoryCashDepositInfo>();
            categoryCashDepositInfo.NeedPayCashDeposit = cashDeposit;
            this.context.SaveChanges();
        }
    }
}
