using Himall.Entity;
using Himall.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaoLa.Core;
using TaoLa.IServices;

namespace TaoLa.Service
{
    public class BrandService : ServiceBase, IBrandService, IService, IDisposable
    {
        public BrandService()
        {
        }

        public void AddBrand(BrandInfo model)
        {
            this.context.BrandInfo.Add(model);
            this.context.SaveChanges();
            model.Logo = this.MoveImages(model.Id, model.Logo, 0);
            this.context.SaveChanges();
        }

        public void ApplyBrand(ShopBrandApplysInfo model)
        {
            char[] chrArray;
            this.context.ShopBrandApplysInfo.Add(model);
            this.context.SaveChanges();
            if (model.ApplyMode == 2)
            {
                model.Logo = this.MoveImages(model.Id, model.ShopId, model.Logo, "logo", 1);
            }
            string authCertificate = model.AuthCertificate;
            string empty = string.Empty;
            if (!string.IsNullOrEmpty(authCertificate))
            {
                chrArray = new char[] { ',' };
                string[] strArrays = authCertificate.Split(chrArray);
                int num = 0;
                string[] strArrays1 = strArrays;
                for (int i = 0; i < (int)strArrays1.Length; i++)
                {
                    string str = strArrays1[i];
                    num++;
                    empty = string.Concat(empty, this.MoveImages(model.Id, model.ShopId, str, "auth", num), ",");
                }
            }
            if (!string.IsNullOrEmpty(empty))
            {
                chrArray = new char[] { ',' };
                model.AuthCertificate = empty.TrimEnd(chrArray);
            }
            this.context.SaveChanges();
        }

        public void AuditBrand(long id, ShopBrandApplysInfo.BrandAuditStatus status)
        {
            ShopBrandsInfo shopBrandsInfo;
            ShopBrandApplysInfo nullable = this.context.ShopBrandApplysInfo.FindById<ShopBrandApplysInfo>(id);
            nullable.AuditStatus = (int)status;
            if (status == ShopBrandApplysInfo.BrandAuditStatus.Audited)
            {
                if (nullable.ApplyMode != 2)
                {
                    shopBrandsInfo = new ShopBrandsInfo()
                    {
                        BrandId = nullable.BrandId.Value,
                        ShopId = nullable.ShopId
                    };
                    this.context.ShopBrandsInfo.Add(shopBrandsInfo);
                    this.context.SaveChanges();
                }
                else
                {
                    BrandInfo brandInfo = (
                        from r in this.context.BrandInfo
                        where r.Name.ToLower() == nullable.BrandName.ToLower()
                        select r).FirstOrDefault<BrandInfo>();
                    if (brandInfo != null)
                    {
                        shopBrandsInfo = new ShopBrandsInfo()
                        {
                            BrandId = brandInfo.Id,
                            ShopId = nullable.ShopId
                        };
                        this.context.ShopBrandsInfo.Add(shopBrandsInfo);
                        this.context.SaveChanges();
                    }
                    else
                    {
                        BrandInfo brandInfo1 = new BrandInfo()
                        {
                            Name = nullable.BrandName.Trim(),
                            Logo = nullable.Logo,
                            Description = nullable.Description
                        };
                        BrandInfo brandInfo2 = brandInfo1;
                        this.context.BrandInfo.Add(brandInfo2);
                        this.context.SaveChanges();
                        nullable.BrandId = new long?(brandInfo2.Id);
                        BrandInfo brand = this.GetBrand(brandInfo2.Id);
                        brand.Logo = this.MoveImages(brand.Id, brand.Logo, 1);
                        shopBrandsInfo = new ShopBrandsInfo()
                        {
                            BrandId = brand.Id,
                            ShopId = nullable.ShopId
                        };
                        this.context.ShopBrandsInfo.Add(shopBrandsInfo);
                        this.context.SaveChanges();
                    }
                }
            }
            this.context.SaveChanges();
        }

        public bool BrandInUse(long id)
        {
            bool flag = this.context.ProductInfo.Any<ProductInfo>((ProductInfo item) => (int)item.SaleStatus == 1 && item.BrandId.Equals(id));
            return flag;
        }

        public void DeleteApply(int id)
        {
            ShopBrandApplysInfo shopBrandApplysInfo = this.context.ShopBrandApplysInfo.FindById<ShopBrandApplysInfo>(id);
            this.context.ShopBrandApplysInfo.Remove(shopBrandApplysInfo);
            if (shopBrandApplysInfo.ApplyMode == 2)
            {
                string mapPath = IOHelper.GetMapPath(shopBrandApplysInfo.Logo);
                if (File.Exists(mapPath))
                {
                    File.Delete(mapPath);
                }
            }
            string str = IOHelper.GetMapPath(shopBrandApplysInfo.AuthCertificate);
            if (File.Exists(str))
            {
                File.Delete(str);
            }
            this.context.SaveChanges();
        }

        public void DeleteBrand(long id)
        {
            BrandInfo brandInfo = this.context.BrandInfo.FindById<BrandInfo>(id);
            if ((brandInfo.Himall_ShopBrandApplys.Any<ShopBrandApplysInfo>((ShopBrandApplysInfo p) => p.AuditStatus != 2) ? true : brandInfo.Himall_ShopBrands.Count<ShopBrandsInfo>() != 0))
            {
                throw new TaoLaException("该品牌已有商家使用，或已有商家申请，不能删除！");
            }
            if ((brandInfo.TypeBrandInfo.Count<TypeBrandInfo>() != 0 ? true : brandInfo.FloorBrandInfo.Count<FloorBrandInfo>() != 0))
            {
                throw new TaoLaException("该品牌被使用中，不能删除！");
            }
            this.context.BrandInfo.Remove(brandInfo);
            this.context.SaveChanges();
            File.Delete(IOHelper.GetMapPath(brandInfo.Logo));
        }

        public BrandInfo GetBrand(long id)
        {
            return this.context.BrandInfo.FindById<BrandInfo>(id);
        }

        public ShopBrandApplysInfo GetBrandApply(long id)
        {
            ShopBrandApplysInfo description = this.context.ShopBrandApplysInfo.FindById<ShopBrandApplysInfo>(id);
            if (description.ApplyMode == 1)
            {
                description.Description = description.Himall_Brands.Description;
            }
            return description;
        }

        public PageModel<BrandInfo> GetBrands(string keyWords, int pageNo, int pageSize)
        {
            int num = 0;
            IQueryable<BrandInfo> brandInfos = this.context.BrandInfo.FindBy<BrandInfo, long>((BrandInfo item) => keyWords == null || (keyWords == "") || item.Name.Contains(keyWords), pageNo, pageSize, out num, (BrandInfo a) => a.Id, false);
            return new PageModel<BrandInfo>()
            {
                Models = brandInfos,
                Total = num
            };
        }

        public IQueryable<BrandInfo> GetBrands(string keyWords)
        {
            IQueryable<BrandInfo> brandInfos = this.context.BrandInfo.FindBy<BrandInfo>((BrandInfo item) => keyWords == null || (keyWords == "") || item.Name.Contains(keyWords) || item.RewriteName.Contains(keyWords));
            return brandInfos;
        }

        public IEnumerable<BrandInfo> GetBrandsByCategoryIds(params long[] categoryIds)
        {
            IQueryable<CategoryInfo> categoryInfo =
                from item in this.context.CategoryInfo
                where categoryIds.Contains<long>(item.Id)
                select item;
            IQueryable<ProductTypeInfo> productTypeInfo =
                from item in categoryInfo
                select item.ProductTypeInfo;
            IQueryable<IEnumerable<BrandInfo>> enumerables =
                from item in productTypeInfo
                select item.TypeBrandInfo.Select<TypeBrandInfo, BrandInfo>((TypeBrandInfo t) => t.BrandInfo);
            List<BrandInfo> brandInfos = new List<BrandInfo>();
            foreach (IEnumerable<BrandInfo> list in enumerables.ToList<IEnumerable<BrandInfo>>())
            {
                brandInfos.AddRange(list);
            }
            IEnumerable<BrandInfo> brandInfos1 = brandInfos.DistinctBy<BrandInfo, long>((BrandInfo item) => item.Id);
            return brandInfos1;
        }

        public IEnumerable<BrandInfo> GetBrandsByCategoryIds(long shopId, params long[] categoryIds)
        {
            ShopInfo shopInfo = this.context.ShopInfo.FirstOrDefault<ShopInfo>((ShopInfo d) => d.Id == shopId);
            IEnumerable<long> shopBrandsInfo =
                from item in this.context.ShopBrandsInfo
                where item.ShopId == shopId
                select item into r
                select r.BrandId;
            IQueryable<CategoryInfo> categoryInfo =
                from item in this.context.CategoryInfo
                where categoryIds.Contains<long>(item.Id)
                select item;
            IQueryable<ProductTypeInfo> productTypeInfo =
                from item in categoryInfo
                select item.ProductTypeInfo;
            IQueryable<IEnumerable<BrandInfo>> enumerables =
                from item in productTypeInfo
                select item.TypeBrandInfo.Select<TypeBrandInfo, BrandInfo>((TypeBrandInfo t) => t.BrandInfo);
            List<BrandInfo> brandInfos = new List<BrandInfo>();
            foreach (IEnumerable<BrandInfo> list in enumerables.ToList<IEnumerable<BrandInfo>>())
            {
                foreach (BrandInfo brandInfo in list)
                {
                    bool flag = false;
                    if (shopBrandsInfo.Contains<long>(brandInfo.Id))
                    {
                        flag = true;
                    }
                    if (shopInfo.IsSelf)
                    {
                        flag = true;
                    }
                    if (flag)
                    {
                        brandInfos.Add(brandInfo);
                    }
                }
            }
            IEnumerable<BrandInfo> brandInfos1 = brandInfos.DistinctBy<BrandInfo, long>((BrandInfo item) => item.Id);
            return brandInfos1;
        }

        public PageModel<ShopBrandApplysInfo> GetShopBrandApplys(long? shopId, int? auditStatus, int pageNo, int pageSize, string keyWords)
        {
            int num = 0;
            IQueryable<ShopBrandApplysInfo> shopBrandApplysInfos = this.context.ShopBrandApplysInfo.FindAll<ShopBrandApplysInfo>();
            if (auditStatus.HasValue)
            {
                shopBrandApplysInfos =
                    from item in shopBrandApplysInfos
                    where item.AuditStatus == (int)auditStatus
                    select item;
            }
            if (shopId.HasValue)
            {
                shopBrandApplysInfos =
                    from item in shopBrandApplysInfos
                    where (long?)item.ShopId == shopId
                    select item;
            }
            if (!string.IsNullOrEmpty(keyWords))
            {
                shopBrandApplysInfos =
                    from item in shopBrandApplysInfos
                    where item.Himall_Shops.ShopName.Contains(keyWords)
                    select item;
            }
            shopBrandApplysInfos = shopBrandApplysInfos.FindBy<ShopBrandApplysInfo, int>((ShopBrandApplysInfo item) => true, pageNo, pageSize, out num, (ShopBrandApplysInfo a) => a.Id, false);
            return new PageModel<ShopBrandApplysInfo>()
            {
                Models = shopBrandApplysInfos,
                Total = num
            };
        }

        public IQueryable<ShopBrandApplysInfo> GetShopBrandApplys(long shopId)
        {
            IQueryable<ShopBrandApplysInfo> shopBrandApplysInfos = this.context.ShopBrandApplysInfo.FindBy<ShopBrandApplysInfo>((ShopBrandApplysInfo item) => item.ShopId == shopId);
            return shopBrandApplysInfos;
        }

        public PageModel<BrandInfo> GetShopBrands(long shopId, int pageNo, int pageSize)
        {
            int num = 0;
            IQueryable<BrandInfo> brandInfos = this.context.BrandInfo.FindBy<BrandInfo, long>((BrandInfo item) => (
                from r in this.context.ShopBrandsInfo
                where r.ShopId == shopId
                select r.BrandId).Contains<long>(item.Id), pageNo, pageSize, out num, (BrandInfo a) => a.Id, false);
            return new PageModel<BrandInfo>()
            {
                Models = brandInfos,
                Total = num
            };
        }

        public IQueryable<BrandInfo> GetShopBrands(long shopId)
        {
            IQueryable<BrandInfo> brandInfo =
                from item in this.context.BrandInfo
                where this.context.ShopBrandsInfo.Where<ShopBrandsInfo>((ShopBrandsInfo r) => r.ShopId == shopId).Select<ShopBrandsInfo, long>((ShopBrandsInfo r) => r.BrandId).Contains<long>(item.Id)
                select item;
            return brandInfo;
        }

        public bool IsExistApply(long shopId, string brandName)
        {
            bool flag;
            flag = ((
                from item in this.context.ShopBrandApplysInfo
                where item.ShopId == shopId && (item.BrandName.ToLower().Trim() == brandName.ToLower().Trim()) && item.AuditStatus != 2
                select item).FirstOrDefault<ShopBrandApplysInfo>() == null ? false : true);
            return flag;
        }

        public bool IsExistBrand(string brandName)
        {
            bool flag;
            flag = ((
                from item in this.context.BrandInfo
                where item.Name.ToLower().Trim() == brandName.ToLower().Trim()
                select item).FirstOrDefault<BrandInfo>() == null ? false : true);
            return flag;
        }

        private string MoveImages(long brandId, string image, int type = 0)
        {
            string str;
            string mapPath = IOHelper.GetMapPath(image);
            string extension = (new FileInfo(mapPath)).Extension;
            string empty = string.Empty;
            empty = IOHelper.GetMapPath("/Storage/Plat/Brand");
            string str1 = "/Storage/Plat/Brand/";
            string str2 = string.Concat("logo_", brandId, extension);
            if (!Directory.Exists(empty))
            {
                Directory.CreateDirectory(empty);
            }
            if ((image.Replace("\\", "/").Contains("/temp/") ? false : type != 1))
            {
                str = image;
            }
            else
            {
                IOHelper.CopyFile(mapPath, empty, false, str2);
                str = string.Concat(str1, str2);
            }
            return str;
        }

        private string MoveImages(int id, long shopId, string image, string name, int index = 1)
        {
            string str;
            if (!string.IsNullOrEmpty(image))
            {
                string mapPath = IOHelper.GetMapPath(image);
                string str1 = ".png";
                string empty = string.Empty;
                string str2 = string.Concat("/Storage/Shop/", shopId, "/Brand");
                empty = IOHelper.GetMapPath(str2);
                if (!Directory.Exists(empty))
                {
                    Directory.CreateDirectory(empty);
                }
                object[] objArray = new object[] { name, "_", id, "_", index, str1 };
                string str3 = string.Concat(objArray);
                if (image.Replace("\\", "/").Contains("/temp/"))
                {
                    IOHelper.CopyFile(mapPath, empty, false, str3);
                }
                str = string.Concat(str2, "/", str3);
            }
            else
            {
                str = "";
            }
            return str;
        }

        public void UpdateBrand(BrandInfo model)
        {
            model.Logo = this.MoveImages(model.Id, model.Logo, 0);
            BrandInfo brand = this.GetBrand(model.Id);
            brand.Name = model.Name.Trim();
            brand.Description = model.Description;
            brand.Logo = model.Logo;
            brand.Meta_Description = model.Meta_Description;
            brand.Meta_Keywords = model.Meta_Keywords;
            brand.Meta_Title = model.Meta_Title;
            brand.RewriteName = model.RewriteName;
            brand.IsRecommend = model.IsRecommend;
            ShopBrandApplysInfo name = this.context.ShopBrandApplysInfo.FirstOrDefault<ShopBrandApplysInfo>((ShopBrandApplysInfo p) => p.BrandId == (long?)model.Id);
            if (name != null)
            {
                name.BrandName = model.Name;
                name.Description = model.Description;
                name.Logo = model.Logo;
            }
            this.context.SaveChanges();
        }

        public void UpdateSellerBrand(ShopBrandApplysInfo model)
        {
            ShopBrandApplysInfo brandName = this.context.ShopBrandApplysInfo.FindBy<ShopBrandApplysInfo>((ShopBrandApplysInfo a) => a.Id == model.Id && a.ShopId != (long)0 && a.AuditStatus == 0).FirstOrDefault<ShopBrandApplysInfo>();
            if (brandName == null)
            {
                throw new TaoLaException("该品牌已被审核或删除，不能修改！");
            }
            brandName.Logo = this.MoveImages((long)model.Id, model.Logo, 0);
            brandName.BrandName = model.BrandName;
            brandName.Description = model.Description;
            this.context.SaveChanges();
        }
    }
}
