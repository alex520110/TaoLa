using Himall.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TaoLa.IServices;
using TaoLa.Web.Areas.Admin.Models;
using TaoLa.Web.Framework;
using TaoLa.Web.Models;

namespace TaoLa.Web.Areas.Admin.Controllers
{
    public class ProductTypeController : BaseAdminController
    {
        private ITypeService _iTypeService;

        private IOperationLogService _iOperationLogService;

        private IBrandService _iBrandService;

        public ProductTypeController(ITypeService iTypeService, IOperationLogService iOperationLogService, IBrandService iBrandService)
        {
            this._iTypeService = iTypeService;
            this._iOperationLogService = iOperationLogService;
            this._iBrandService = iBrandService;
        }
        public ActionResult Management()
        {
            return base.View();
        }


        [HttpPost]
        public JsonResult DataGridJson(string searchKeyWord, int page, int rows)
        {
            PageModel<ProductTypeInfo> types = this._iTypeService.GetTypes(searchKeyWord, page, rows);
            IEnumerable<ProductTypeInfo> list =
                from item in types.Models.ToList<ProductTypeInfo>()
                select new ProductTypeInfo()
                {
                    Id = item.Id,
                    Name = item.Name
                };
            DataGridModel<ProductTypeInfo> dataGridModel = new DataGridModel<ProductTypeInfo>()
            {
                rows = list,
                total = types.Total
            };
            return base.Json(dataGridModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getTypes(string keyWords)
        {
            IQueryable<ProductTypeInfo> Types = this._iTypeService.GetTypes(keyWords);
            var variable =
                from item in Types
                select new { key = item.Id, @value = item.Name };
            return base.Json(variable);
        }
        public ActionResult Edit(long id = 0L)
        {
            ActionResult actionResult;
            IQueryable<BrandInfo> brands = this._iBrandService.GetBrands("");
            ((dynamic)base.ViewBag).Brands = brands.ToList<BrandInfo>();
            if (id != (long)0)
            {
                ProductTypeInfo type = this._iTypeService.GetType(id);
                this.TransformAttrs(type);
                this.TransformSpec(type);
                actionResult = base.View(type);
            }
            else
            {
                actionResult = base.View(new ProductTypeInfo(true));
            }
            return actionResult;
        }
        public JsonResult GetBrandsAjax(long id)
        {
            ProductTypeInfo type;
            IQueryable<BrandInfo> brands = this._iBrandService.GetBrands("");
            if (id == (long)0)
            {
                type = null;
            }
            else
            {
                type = this._iTypeService.GetType(id);
            }
            ProductTypeInfo productTypeInfo = type;
            List<BrandViewModel> brandViewModels = new List<BrandViewModel>();
            foreach (BrandInfo brand in brands)
            {
                List<BrandViewModel> brandViewModels1 = brandViewModels;
                BrandViewModel brandViewModel = new BrandViewModel()
                {
                    id = brand.Id,
                    isChecked = (productTypeInfo == null ? false : productTypeInfo.TypeBrandInfo.Any<TypeBrandInfo>((TypeBrandInfo b) => b.BrandId.Equals(brand.Id))),
                    @value = brand.Name
                };
                brandViewModels1.Add(brandViewModel);
            }
            JsonResult jsonResult = base.Json(new { data = brandViewModels }, JsonRequestBehavior.AllowGet);
            return jsonResult;
        }
        private void TransformAttrs(ProductTypeInfo model)
        {
            foreach (AttributeInfo attributeInfo in model.AttributeInfo)
            {
                StringBuilder stringBuilder = new StringBuilder();
                foreach (string str in
                    from c in attributeInfo.AttributeValueInfo
                    select c.Value)
                {
                    stringBuilder.Append(str);
                    stringBuilder.Append(',');
                }
                string str1 = stringBuilder.ToString();
                char[] chrArray = new char[] { ',' };
                attributeInfo.AttrValue = str1.TrimEnd(chrArray);
            }
        }

        private void TransformSpec(ProductTypeInfo model)
        {
            StringBuilder stringBuilder;
            SpecificationValueInfo specificationValueInfo = null;
            char[] chrArray;
            if (model.IsSupportColor)
            {
                stringBuilder = new StringBuilder();
                foreach (SpecificationValueInfo specificationValueInfo2 in
                    from s in model.SpecificationValueInfo
                    where (s.Specification != SpecificationType.Color ? false : s.TypeId.Equals(model.Id))
                    select s)
                {
                    stringBuilder.Append(specificationValueInfo2.Value);
                    stringBuilder.Append(',');
                }
                ProductTypeInfo productTypeInfo = model;
                string str = stringBuilder.ToString();
                chrArray = new char[] { ',' };
                productTypeInfo.ColorValue = str.TrimEnd(chrArray);
            }
            if (model.IsSupportSize)
            {
                stringBuilder = new StringBuilder();
                foreach (SpecificationValueInfo specificationValueInfo1 in
                    from s in model.SpecificationValueInfo
                    where (s.Specification != SpecificationType.Size ? false : s.TypeId.Equals(model.Id))
                    select s)
                {
                    stringBuilder.Append(specificationValueInfo1.Value);
                    stringBuilder.Append(',');
                }
                ProductTypeInfo productTypeInfo1 = model;
                string str1 = stringBuilder.ToString();
                chrArray = new char[] { ',' };
                productTypeInfo1.SizeValue = str1.TrimEnd(chrArray);
            }
            if (model.IsSupportVersion)
            {
                stringBuilder = new StringBuilder();
                foreach (SpecificationValueInfo specificationValueInfo2 in
                    from s in model.SpecificationValueInfo
                    where (s.Specification != SpecificationType.Version ? false : s.TypeId.Equals(model.Id))
                    select s)
                {
                    stringBuilder.Append(specificationValueInfo2.Value);
                    stringBuilder.Append(',');
                }
                ProductTypeInfo productTypeInfo2 = model;
                string str2 = stringBuilder.ToString();
                chrArray = new char[] { ',' };
                productTypeInfo2.VersionValue = str2.TrimEnd(chrArray);
            }
        }

    }
}