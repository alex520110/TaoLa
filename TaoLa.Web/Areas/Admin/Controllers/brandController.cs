using Himall.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaoLa.IServices;
using TaoLa.Web.Areas.Admin.Models;
using TaoLa.Web.Framework;
using TaoLa.Web.Models;

namespace TaoLa.Web.Areas.Admin.Controllers
{
    public class BrandController : BaseAdminController
    {
        private IBrandService _iBrandService;

        public BrandController(IBrandService iBrandService)
        {
            this._iBrandService = iBrandService;
        }

        public ActionResult Add()
        {
            return base.View();
        }

        [HttpPost]
        public ActionResult Add(BrandModel brand)
        {
            ActionResult action;
            if (!base.ModelState.IsValid)
            {
                action = base.View(brand);
            }
            else
            {
                BrandInfo brandInfo = new BrandInfo()
                {
                    Name = brand.BrandName.Trim(),
                    Description = brand.BrandDesc,
                    Logo = brand.BrandLogo,
                    Meta_Description = brand.MetaDescription,
                    Meta_Keywords = brand.MetaKeyWord,
                    Meta_Title = brand.MetaTitle,
                    IsRecommend = brand.IsRecommend
                };
                BrandInfo brandInfo1 = brandInfo;
                if (!this._iBrandService.IsExistBrand(brand.BrandName))
                {
                    this._iBrandService.AddBrand(brandInfo1);
                }
                action = base.RedirectToAction("Management");
            }
            return action;
        }

        public JsonResult ApplyList(int page, int rows, string keyWords)
        {
            keyWords = keyWords.Trim();
            long? nullable = null;
            PageModel<ShopBrandApplysInfo> shopBrandApplys = this._iBrandService.GetShopBrandApplys(nullable, new int?(0), page, rows, keyWords);
            IEnumerable<BrandApplyModel> array =
                from item in (IEnumerable<ShopBrandApplysInfo>)shopBrandApplys.Models.ToArray<ShopBrandApplysInfo>()
                select new BrandApplyModel()
                {
                    Id = (long)item.Id,
                    BrandId = (!item.BrandId.HasValue ? (long)0 : item.BrandId.Value),
                    ShopId = item.ShopId,
                    BrandName = item.BrandName,
                    BrandLogo = item.Logo,
                    BrandDesc = (item.Description == null ? "" : item.Description),
                    BrandAuthPic = item.AuthCertificate,
                    Remark = item.Remark,
                    BrandMode = item.ApplyMode,
                    AuditStatus = item.AuditStatus,
                    ApplyTime = item.ApplyTime.ToString("yyyy-MM-dd"),
                    ShopName = item.Himall_Shops.ShopName
                };
            DataGridModel<BrandApplyModel> dataGridModel = new DataGridModel<BrandApplyModel>()
            {
                rows = array,
                total = shopBrandApplys.Total
            };
            return base.Json(dataGridModel);
        }

        [HttpPost]
        public JsonResult Audit(int id)
        {
            this._iBrandService.AuditBrand((long)id, ShopBrandApplysInfo.BrandAuditStatus.Audited);
            BaseController.Result result = new BaseController.Result()
            {
                success = true,
                msg = "审核成功！"
            };
            return base.Json(result);
        }

        [Description("删除品牌")]
        [HttpPost]
        public JsonResult Delete(int id)
        {
            this._iBrandService.DeleteBrand((long)id);
            BaseController.Result result = new BaseController.Result()
            {
                success = true,
                msg = "删除成功！"
            };
            return base.Json(result);
        }

        [Description("删除品牌申请")]
        [HttpPost]
        public JsonResult DeleteApply(int id)
        {
            this._iBrandService.DeleteApply(id);
            BaseController.Result result = new BaseController.Result()
            {
                success = true,
                msg = "删除成功！"
            };
            return base.Json(result);
        }

        public ActionResult Edit(long id)
        {
            BrandInfo brand = this._iBrandService.GetBrand(id);
            BrandModel brandModel = new BrandModel()
            {
                ID = brand.Id,
                BrandName = brand.Name,
                BrandDesc = brand.Description,
                BrandLogo = brand.Logo,
                MetaDescription = brand.Meta_Description,
                MetaKeyWord = brand.Meta_Keywords,
                MetaTitle = brand.Meta_Title,
                IsRecommend = brand.IsRecommend
            };
            return base.View(brandModel);
        }

        [HttpPost]
        [OperationLog(Message = "编辑品牌")]
        public ActionResult Edit(BrandModel brand)
        {
            ActionResult action;
            if (!base.ModelState.IsValid)
            {
                action = base.View(brand);
            }
            else
            {
                BrandInfo brandInfo = new BrandInfo()
                {
                    Id = brand.ID,
                    Name = brand.BrandName.Trim(),
                    Description = brand.BrandDesc,
                    Logo = brand.BrandLogo,
                    Meta_Description = brand.MetaDescription,
                    Meta_Keywords = brand.MetaKeyWord,
                    Meta_Title = brand.MetaTitle,
                    IsRecommend = brand.IsRecommend
                };
                this._iBrandService.UpdateBrand(brandInfo);
                action = base.RedirectToAction("Management");
            }
            return action;
        }

        [HttpPost]
        public JsonResult GetBrands(string keyWords, int? AuditStatus = 2)
        {
            IQueryable<BrandInfo> brands = this._iBrandService.GetBrands(keyWords);
            var variable =
                from item in brands
                select new { key = item.Id, @value = item.Name, envalue = item.RewriteName };
            return base.Json(variable);
        }

        [HttpPost]
        public JsonResult IsExist(string name)
        {
            JsonResult jsonResult;
            if (this._iBrandService.IsExistBrand(name))
            {
                BaseController.Result result = new BaseController.Result()
                {
                    success = true,
                    msg = "该品牌已存在，请不要重复添加！"
                };
                jsonResult = base.Json(result);
            }
            else
            {
                BaseController.Result result1 = new BaseController.Result()
                {
                    success = false,
                    msg = null
                };
                jsonResult = base.Json(result1);
            }
            return jsonResult;
        }

        [HttpPost]
        public JsonResult IsInUse(long id)
        {
            JsonResult jsonResult;
            if (this._iBrandService.BrandInUse(id))
            {
                BaseController.Result result = new BaseController.Result()
                {
                    success = true,
                    msg = "该品牌已使用！"
                };
                jsonResult = base.Json(result);
            }
            else
            {
                BaseController.Result result1 = new BaseController.Result()
                {
                    success = false,
                    msg = "该品牌尚未使用！"
                };
                jsonResult = base.Json(result1);
            }
            return jsonResult;
        }

        [Description("分页获取品牌列表JSON数据")]
        [HttpPost]
        public JsonResult List(int page, int rows, string keyWords)
        {
            keyWords = keyWords.Trim();
            PageModel<BrandInfo> brands = this._iBrandService.GetBrands(keyWords, page, rows);
            IEnumerable<BrandModel> array =
                from item in (IEnumerable<BrandInfo>)brands.Models.ToArray<BrandInfo>()
                select new BrandModel()
                {
                    BrandName = item.Name,
                    BrandLogo = item.Logo,
                    ID = item.Id
                };
            DataGridModel<BrandModel> dataGridModel = new DataGridModel<BrandModel>()
            {
                rows = array,
                total = brands.Total
            };
            return base.Json(dataGridModel);
        }

        [Description("品牌管理页面")]
        public ActionResult Management()
        {
            return base.View();
        }

        [HttpPost]
        public JsonResult Refuse(int id)
        {
            this._iBrandService.AuditBrand((long)id, ShopBrandApplysInfo.BrandAuditStatus.Refused);
            BaseController.Result result = new BaseController.Result()
            {
                success = true,
                msg = "拒绝成功！"
            };
            return base.Json(result);
        }

        public ActionResult Show(long id)
        {
            return base.View(this._iBrandService.GetBrandApply(id));
        }

        public ActionResult Verify()
        {
            return base.View();
        }
    }
}