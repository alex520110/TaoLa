using Himall.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TaoLa.Core;
using TaoLa.IServices;
using TaoLa.Web.Framework;

namespace TaoLa.Web.Areas.Admin.Controllers
{
    public class CategoryController : BaseAdminController
    {
        private ICategoryService _iCategoryService;

        private ITypeService _iTypeService;

        public CategoryController(ICategoryService iCategoryService, ITypeService iTypeService)
        {
            this._iCategoryService = iCategoryService;
            this._iTypeService = iTypeService;
        }

        [UnAuthorize]
        public ActionResult Add()
        {
            if (null == base.TempData["Categories"])
            {
                base.TempData["Categories"] = this.GetCatgegotyList();
            }
            if (null == base.TempData["Types"])
            {
                base.TempData["Types"] = this.GetTypesList((long)-1);
            }
            if (null == base.TempData["Depth"])
            {
                base.TempData["Depth"] = 1;
            }
            return base.View();
        }

        [HttpPost]
        [OperationLog(Message = "添加平台分类")]
        [UnAuthorize]
        public ActionResult Add(CategoryModel category)
        {
            ActionResult action;
            if (!base.ModelState.IsValid)
            {
                ((dynamic)base.ViewBag).Categories = this._iCategoryService.GetFirstAndSecondLevelCategories();
                ((dynamic)base.ViewBag).Types = this._iTypeService.GetTypes();
                action = base.View(category);
            }
            else
            {
                ICategoryService categoryService = this._iCategoryService;
                this.ProcessingParentCategoryId(category);
                this.ProcessingDepth(category, categoryService);
                this.ProcessingPath(category, categoryService);
                this.ProcessingDisplaySequence(category, categoryService);
                this.ProcessingIcon(category, categoryService);
                categoryService.AddCategory(category);
                action = base.RedirectToAction("Management");
            }
            return action;
        }

        [UnAuthorize]
        public ActionResult AddByParent(long Id)
        {
            List<SelectListItem> catgegotyList = this.GetCatgegotyList();
            catgegotyList.FirstOrDefault<SelectListItem>((SelectListItem c) => c.Value.Equals(Id.ToString())).Selected = true;
            base.TempData["Categories"] = catgegotyList;
            CategoryInfo category = this._iCategoryService.GetCategory(Id);
            string str = category.TypeId.ToString();
            List<SelectListItem> typesList = this.GetTypesList((long)-1);
            SelectListItem selectListItem = typesList.FirstOrDefault<SelectListItem>((SelectListItem c) => c.Value.Equals(str));
            if (selectListItem != null)
            {
                selectListItem.Selected = true;
            }
            else
            {
                typesList.FirstOrDefault<SelectListItem>().Selected = true;
            }
            base.TempData["Types"] = typesList;
            base.TempData["Depth"] = category.Depth;
            return base.RedirectToAction("Add");
        }

        [HttpPost]
        [OperationLog("删除平台分类", "Ids")]
        public JsonResult BatchDeleteCategory(string Ids)
        {
            int num;
            string[] strArrays = Ids.Split(new char[] { '|' });
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                string str = strArrays[i];
                if (!string.IsNullOrWhiteSpace(str))
                {
                    if (int.TryParse(str, out num))
                    {
                        this._iCategoryService.DeleteCategory((long)num);
                    }
                }
            }
            JsonResult jsonResult = base.Json(new { Successful = true }, JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        [HttpPost]
        [OperationLog("删除平台分类", "Id")]
        public JsonResult DeleteCategoryById(long id)
        {
            this._iCategoryService.DeleteCategory(id);
            JsonResult jsonResult = base.Json(new { Successful = true }, JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        public ActionResult Edit(long Id = 0L)
        {
            CategoryInfo category = this._iCategoryService.GetCategory(Id);
            ((dynamic)base.ViewBag).Depth = category.Depth;
            ((dynamic)base.ViewBag).Types = this.GetTypesList(category.TypeId);
            category.CommisRate = Math.Round(category.CommisRate, 2);
            return base.View(new CategoryModel(category));
        }

        [HttpPost]
        [OperationLog("修改平台分类", "Id")]
        public ActionResult Edit(CategoryModel category)
        {
            ActionResult action;
            if (!base.ModelState.IsValid)
            {
                ((dynamic)base.ViewBag).Types = this.GetTypesList(category.TypeId);
                ((dynamic)base.ViewBag).Depth = category.Depth;
                action = base.View(category);
            }
            else
            {
                ICategoryService categoryService = this._iCategoryService;
                this.ProcessingIcon(category, categoryService);
                categoryService.UpdateCategory(category);
                action = base.RedirectToAction("Management");
            }
            return action;
        }

        public JsonResult GetCateDepth(long id)
        {
            JsonResult jsonResult = base.Json(new { successful = true, depth = this._iCategoryService.GetCategory(id).Depth }, JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        [HttpPost]
        [UnAuthorize]
        public JsonResult GetCategory(long? key = null, int? level = -1)
        {
            if (level == -1)
            {
                key = new long?(0L);
            }
            System.Web.Mvc.JsonResult result;
            if (key.HasValue)
            {
                System.Collections.Generic.IEnumerable<CategoryInfo> categoryByParentId = this._iCategoryService.GetCategoryByParentId(key.Value);
                System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<long, string>> data = from item in categoryByParentId
                                                                                                                     select new System.Collections.Generic.KeyValuePair<long, string>(item.Id, item.Name);
                result = base.Json(data);
            }
            else
            {
                result = base.Json(new object[0]);
            }
            return result;
        }

        public ActionResult GetCategoryById(long id)
        {
            CategoryModel categoryModel = new CategoryModel(this._iCategoryService.GetCategory(id));
            ActionResult actionResult = base.Json(new { Successful = true, category = categoryModel }, JsonRequestBehavior.AllowGet);
            return actionResult;
        }

        [UnAuthorize]
        public ActionResult GetCategoryByParentId(int id)
        {
            List<CategoryModel> categoryModels = new List<CategoryModel>();
            foreach (CategoryInfo categoryByParentId in this._iCategoryService.GetCategoryByParentId((long)id))
            {
                categoryModels.Add(new CategoryModel(categoryByParentId));
            }
            ActionResult actionResult = base.Json(new { Successfly = true, Category = categoryModels }, JsonRequestBehavior.AllowGet);
            return actionResult;
        }

        private List<SelectListItem> GetCatgegotyList()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            SelectListItem selectListItem = new SelectListItem()
            {
                Selected = false,
                Text = "请选择...",
                Value = "0"
            };
            selectListItems.Add(selectListItem);
            List<SelectListItem> selectListItems1 = selectListItems;
            foreach (CategoryInfo firstAndSecondLevelCategory in this._iCategoryService.GetFirstAndSecondLevelCategories())
            {
                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 1; i < firstAndSecondLevelCategory.Depth; i++)
                {
                    stringBuilder.Append("&nbsp;&nbsp;&nbsp;");
                }
                SelectListItem selectListItem1 = new SelectListItem()
                {
                    Selected = false,
                    Text = string.Concat(stringBuilder, firstAndSecondLevelCategory.Name),
                    Value = firstAndSecondLevelCategory.Id.ToString()
                };
                selectListItems1.Add(selectListItem1);
            }
            return selectListItems1;
        }

        [UnAuthorize]
        public ActionResult GetNonLeafCategoryList()
        {
            IEnumerable<CategoryInfo> firstAndSecondLevelCategories = this._iCategoryService.GetFirstAndSecondLevelCategories();
            List<CategoryDropListModel> categoryDropListModels = new List<CategoryDropListModel>();
            foreach (CategoryInfo firstAndSecondLevelCategory in firstAndSecondLevelCategories)
            {
                CategoryDropListModel categoryDropListModel = new CategoryDropListModel()
                {
                    Id = firstAndSecondLevelCategory.Id,
                    ParentCategoryId = firstAndSecondLevelCategory.ParentCategoryId,
                    Name = firstAndSecondLevelCategory.Name,
                    Depth = firstAndSecondLevelCategory.Depth
                };
                categoryDropListModels.Add(categoryDropListModel);
            }
            ActionResult actionResult = base.Json(new
            {
                Successful = true,
                list = (
                from d in categoryDropListModels
                orderby d.ParentCategoryId, d.Depth, d.Id
                select d).ToList<CategoryDropListModel>()
            }, JsonRequestBehavior.AllowGet);
            return actionResult;
        }

        [UnAuthorize]
        public JsonResult GetSecondAndThirdCategoriesByTopId(long id)
        {
            ICategoryService categoryService = this._iCategoryService;
            CategoryTreeModel[] array = (
                from item in categoryService.GetCategoryByParentId(id)
                select new CategoryTreeModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    ParentCategoryId = item.ParentCategoryId,
                    Depth = item.Depth
                }).ToArray<CategoryTreeModel>();
            CategoryTreeModel[] categoryTreeModelArray = array;
            for (int i = 0; i < (int)categoryTreeModelArray.Length; i++)
            {
                CategoryTreeModel categoryByParentId = categoryTreeModelArray[i];
                categoryByParentId.Children =
                    from item in categoryService.GetCategoryByParentId(categoryByParentId.Id)
                    select new CategoryTreeModel()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        ParentCategoryId = item.ParentCategoryId,
                        Depth = item.Depth
                    };
            }
            JsonResult jsonResult = base.Json(new { success = true, categoies = array }, JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        private List<SelectListItem> GetTypesList(long selectId = -1L)
        {
            IQueryable<ProductTypeInfo> types = this._iTypeService.GetTypes();
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            SelectListItem selectListItem = new SelectListItem()
            {
                Selected = false,
                Text = "请选择...",
                Value = "-1"
            };
            selectListItems.Add(selectListItem);
            List<SelectListItem> selectListItems1 = selectListItems;
            foreach (ProductTypeInfo type in types)
            {
                if (type.Id == selectId)
                {
                    SelectListItem selectListItem1 = new SelectListItem()
                    {
                        Selected = true,
                        Text = type.Name,
                        Value = type.Id.ToString()
                    };
                    selectListItems1.Add(selectListItem1);
                }
                else
                {
                    SelectListItem selectListItem2 = new SelectListItem()
                    {
                        Selected = false,
                        Text = type.Name,
                        Value = type.Id.ToString()
                    };
                    selectListItems1.Add(selectListItem2);
                }
            }
            return selectListItems1;
        }

        [HttpPost]
        public JsonResult GetValidCategories(long? key = null, int? level = -1)
        {
            IEnumerable<CategoryInfo> validBusinessCategoryByParentId = this._iCategoryService.GetValidBusinessCategoryByParentId(key.GetValueOrDefault());
            IEnumerable<KeyValuePair<long, string>> keyValuePair =
                from item in validBusinessCategoryByParentId
                select new KeyValuePair<long, string>(item.Id, item.Name);
            return base.Json(keyValuePair);
        }

        public ActionResult Index()
        {
            return base.View();
        }

        public ActionResult Management()
        {
            IOrderedEnumerable<CategoryInfo> mainCategory =
                from c in this._iCategoryService.GetMainCategory()
                orderby c.DisplaySequence
                select c;
            List<CategoryModel> categoryModels = new List<CategoryModel>();
            foreach (CategoryInfo categoryInfo in mainCategory)
            {
                categoryModels.Add(new CategoryModel(categoryInfo));
            }
            return base.View(categoryModels);
        }

        private void ProcessingDepth(CategoryModel model, ICategoryService IProductCategory)
        {
            if (model.ParentCategoryId != (long)0)
            {
                CategoryInfo category = IProductCategory.GetCategory(model.ParentCategoryId);
                model.Depth = category.Depth + 1;
            }
            else
            {
                model.Depth = 1;
            }
        }

        private void ProcessingDisplaySequence(CategoryModel model, ICategoryService IProductCategory)
        {
            int num = IProductCategory.GetCategoryByParentId(model.ParentCategoryId).Count<CategoryInfo>() + 1;
            model.DisplaySequence = (long)num;
        }

        private void ProcessingIcon(CategoryModel model, ICategoryService IProductCategory)
        {
            if (!string.IsNullOrWhiteSpace(model.Icon))
            {
                string str = base.Server.MapPath(model.Icon);
                string str1 = "/Storage/Plat/Category/";
                string mapPath = IOHelper.GetMapPath(str1);
                if (!Directory.Exists(mapPath))
                {
                    Directory.CreateDirectory(mapPath);
                }
                if (model.Icon.Contains("/temp/"))
                {
                    IOHelper.CopyFile(str, base.Server.MapPath(str1), true, "");
                    model.Icon = Path.Combine(str1, Path.GetFileName(str));
                }
            }
        }

        private void ProcessingParentCategoryId(CategoryModel model)
        {
        }

        private void ProcessingPath(CategoryModel model, ICategoryService IProductCategory)
        {
            long maxCategoryId = IProductCategory.GetMaxCategoryId() + (long)1;
            model.Id = maxCategoryId;
            if (model.ParentCategoryId != (long)0)
            {
                CategoryInfo category = IProductCategory.GetCategory(model.ParentCategoryId);
                model.Path = string.Format("{0}|{1}", category.Path, maxCategoryId);
            }
            else
            {
                model.Path = maxCategoryId.ToString();
            }
        }

        [UnAuthorize]
        public JsonResult UpdateName(string name, long id)
        {
            this._iCategoryService.UpdateCategoryName(id, name);
            JsonResult jsonResult = base.Json(new { Successful = true }, JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        [UnAuthorize]
        public JsonResult UpdateOrder(long order, long id)
        {
            this._iCategoryService.UpdateCategoryDisplaySequence(id, order);
            JsonResult jsonResult = base.Json(new { Successful = true }, JsonRequestBehavior.AllowGet);
            return jsonResult;
        }
    }
}