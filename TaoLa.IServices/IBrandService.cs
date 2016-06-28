using Himall.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaoLa.IServices
{
    public interface IBrandService : IService, IDisposable
    {

        void AddBrand(BrandInfo model);

        void ApplyBrand(ShopBrandApplysInfo model);

        void UpdateBrand(BrandInfo model);

        void UpdateSellerBrand(ShopBrandApplysInfo model);

        void DeleteBrand(long id);

        PageModel<BrandInfo> GetBrands(string keyWords, int pageNo, int pageSize);

        void AuditBrand(long id, ShopBrandApplysInfo.BrandAuditStatus status);

        IQueryable<BrandInfo> GetBrands(string keyWords);

        BrandInfo GetBrand(long id);

        IEnumerable<BrandInfo> GetBrandsByCategoryIds(params long[] categoryIds);

        IEnumerable<BrandInfo> GetBrandsByCategoryIds(long shopId, params long[] categoryIds);

        PageModel<BrandInfo> GetShopBrands(long shopId, int pageNo, int pageSize);

        IQueryable<BrandInfo> GetShopBrands(long shopId);

        PageModel<ShopBrandApplysInfo> GetShopBrandApplys(long? shopId, int? auditStatus, int pageNo, int pageSize, string keyWords);

        IQueryable<ShopBrandApplysInfo> GetShopBrandApplys(long shopId);

        ShopBrandApplysInfo GetBrandApply(long id);

        void DeleteApply(int id);

        bool IsExistApply(long shopId, string brandName);

        bool IsExistBrand(string brandName);

        bool BrandInUse(long id);
    }
}
