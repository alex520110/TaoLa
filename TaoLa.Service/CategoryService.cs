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

namespace TaoLa.Service
{
    public class CategoryService : ServiceBase, ICategoryService, IService, IDisposable
    {
        private const char CATEGORY_PATH_SEPERATOR = '|';

        public CategoryService()
        {
        }

        public void AddCategory(CategoryInfo model)
        {
            if (null == model)
            {
                throw new ArgumentNullException("model", "添加一个分类时，Model为空");
            }
            if (model.ParentCategoryId == (long)0)
            {
                CategoryCashDepositInfo categoryCashDepositInfo = new CategoryCashDepositInfo()
                {
                    Id = (long)0,
                    CategoryId = model.Id
                };
                model.Himall_CategoryCashDeposit = categoryCashDepositInfo;
            }
            this.context.CategoryInfo.Add(model);
            this.context.SaveChanges();
            Cache.Remove("Cache-Categories");
        }

        public void DeleteCategory(long id)
        {
            if (this.context.CategoryInfo.FindById<CategoryInfo>(id).Depth != 3)
            {
                IEnumerable<CategoryInfo> secondAndThirdLevelCategories = this.GetSecondAndThirdLevelCategories(new long[] { id });
                if (secondAndThirdLevelCategories.Any<CategoryInfo>((CategoryInfo c) => this.context.BusinessCategoryInfo.Any<BusinessCategoryInfo>((BusinessCategoryInfo b) => b.CategoryId.Equals(c.Id))))
                {
                    throw new TaoLaException("删除失败，因为有店铺在经营该分类下的子分类");
                }
                if (secondAndThirdLevelCategories.Any<CategoryInfo>((CategoryInfo c) => this.context.ProductInfo.Any<ProductInfo>((ProductInfo p) => p.CategoryId == c.Id)))
                {
                    throw new TaoLaException("删除失败，因为有商品与该分类或子级分类关联");
                }
            }
            else
            {
                if (this.context.BusinessCategoryInfo.Any<BusinessCategoryInfo>((BusinessCategoryInfo b) => b.CategoryId.Equals(id)))
                {
                    throw new TaoLaException("删除失败，因为有店铺在经营该分类");
                }
                if (this.context.ProductInfo.Any<ProductInfo>((ProductInfo p) => p.CategoryId == id))
                {
                    throw new TaoLaException("删除失败，因为有商品与该分类关联");
                }
            }
            this.ProcessingDeleteCategory(id);
            this.context.SaveChanges();
            Cache.Remove("Cache-Categories");
        }

        private IEnumerable<CategoryInfo> GetCategories()
        {
            IEnumerable<CategoryInfo> array = null;
            if (Cache.Get("Cache-Categories") == null)
            {
                array = this.context.CategoryInfo.FindAll<CategoryInfo>().ToArray<CategoryInfo>();
                Cache.Insert("Cache-Categories", array);
            }
            else
            {
                array = (IEnumerable<CategoryInfo>)Cache.Get("Cache-Categories");
            }
            return array;
        }

        public CategoryInfo GetCategory(long id)
        {
            CategoryInfo categoryInfo;
            if (id > (long)0)
            {
                CategoryInfo categoryInfo1 = (
                    from t in this.GetCategories()
                    where t.Id == id
                    select t).FirstOrDefault<CategoryInfo>();
                categoryInfo = categoryInfo1;
            }
            else
            {
                categoryInfo = null;
            }
            return categoryInfo;
        }

        public PageModel<CategoryInfo> GetCategoryByName(string name, int pageNo, int pageSize)
        {
            int num = 0;
            IQueryable<CategoryInfo> categoryInfos = this.context.CategoryInfo.FindBy<CategoryInfo, long>((CategoryInfo item) => name == null || (name == "") || item.Name.Contains(name), pageNo, pageSize, out num, (CategoryInfo a) => a.Id, false);
            return new PageModel<CategoryInfo>()
            {
                Models = categoryInfos,
                Total = num
            };
        }

        public IEnumerable<CategoryInfo> GetCategoryByParentId(long id)
        {
            IEnumerable<CategoryInfo> list;
            if (id < (long)0)
            {
                throw new ArgumentNullException("id", string.Format("获取子级分类时，id={0}", id));
            }
            if (id != (long)0)
            {
                IEnumerable<CategoryInfo> categories =
                    from c in this.GetCategories()
                    where c.ParentCategoryId == id
                    select c;
                if (categories != null)
                {
                    list = (
                        from c in categories
                        orderby c.DisplaySequence descending
                        select c).ToList<CategoryInfo>();
                }
                else
                {
                    list = null;
                }
            }
            else
            {
                list =
                    from c in this.GetCategories()
                    where c.ParentCategoryId == (long)0
                    select c;
            }
            return list;
        }

        public string GetEffectCategoryName(long shopId, long typeId)
        {
            StringBuilder stringBuilder = new StringBuilder();
            IQueryable<CategoryInfo> categoryInfos = this.context.CategoryInfo.FindBy<CategoryInfo>((CategoryInfo c) => c.TypeId == typeId);
            IQueryable<BusinessCategoryInfo> businessCategoryInfos = this.context.BusinessCategoryInfo.FindBy<BusinessCategoryInfo>((BusinessCategoryInfo b) => b.ShopId == shopId);
            foreach (CategoryInfo list in categoryInfos.ToList<CategoryInfo>())
            {
                if (businessCategoryInfos.Any<BusinessCategoryInfo>((BusinessCategoryInfo b) => b.CategoryId == list.Id))
                {
                    stringBuilder.Append(list.Name);
                    stringBuilder.Append(',');
                }
            }
            return stringBuilder.ToString().TrimEnd(new char[] { ',' });
        }

        public IEnumerable<CategoryInfo> GetFirstAndSecondLevelCategories()
        {
            IEnumerable<CategoryInfo> list = (
                from c in this.GetCategories()
                where (this.GetCategories().Any<CategoryInfo>((CategoryInfo cc) => cc.ParentCategoryId == c.Id) ? true : c.Depth < 3)
                select c).ToList<CategoryInfo>();
            return list;
        }

        public IEnumerable<CategoryInfo> GetMainCategory()
        {
            IEnumerable<CategoryInfo> categories =
                from t in this.GetCategories()
                where t.ParentCategoryId == (long)0
                select t;
            return categories;
        }

        public long GetMaxCategoryId()
        {
            return (this.GetCategories().Count<CategoryInfo>() == 0 ? (long)0 : this.GetCategories().Max<CategoryInfo>((CategoryInfo c) => c.Id));
        }

        public IEnumerable<CategoryInfo> GetSecondAndThirdLevelCategories(params long[] ids)
        {
            IEnumerable<CategoryInfo> categories =
                from item in this.GetCategories()
                where ids.Contains<long>(item.ParentCategoryId)
                select item;
            List<CategoryInfo> categoryInfos = new List<CategoryInfo>(categories);
            foreach (long list in (
                from item in categories
                select item.Id).ToList<long>())
            {
                IEnumerable<CategoryInfo> categories1 =
                    from item in this.GetCategories()
                    where item.ParentCategoryId == list
                    select item;
                categoryInfos.AddRange(categories1);
            }
            return categoryInfos;
        }

        public IEnumerable<CategoryInfo> GetTopLevelCategories(IEnumerable<long> categoryIds)
        {
            IEnumerable<CategoryInfo> categories =
                from item in this.GetCategories()
                where categoryIds.Contains<long>(item.Id)
                select item;
            List<long> nums = new List<long>();
            foreach (CategoryInfo list in categories.ToList<CategoryInfo>())
            {
                if (list.Depth != 1)
                {
                    string path = list.Path;
                    char[] chrArray = new char[] { '|' };
                    long num = long.Parse(path.Split(chrArray)[0]);
                    nums.Add(num);
                }
                else
                {
                    nums.Add(list.Id);
                }
            }
            IEnumerable<CategoryInfo> categoryInfos =
                from item in this.GetCategories()
                where nums.Contains(item.Id)
                select item;
            return categoryInfos;
        }

        public IEnumerable<CategoryInfo> GetValidBusinessCategoryByParentId(long id)
        {
            CategoryInfo[] array = this.GetCategories().ToArray<CategoryInfo>();
            CategoryInfo[] categoryInfoArray = (
                from item in array
                where item.ParentCategoryId == id
                select item).ToArray<CategoryInfo>();
            if (id != (long)0)
            {
                CategoryInfo categoryInfo = ((IEnumerable<CategoryInfo>)array).FirstOrDefault<CategoryInfo>((CategoryInfo item) => item.Id == id);
                if ((categoryInfo == null ? false : categoryInfo.Depth == 1))
                {
                    IEnumerable<long> length =
                        from item in (IEnumerable<CategoryInfo>)array
                        where (int)item.Path.Split(new char[] { '|' }).Length == 3
                        select long.Parse(item.Path.Split(new char[] { '|' })[1]);
                    categoryInfoArray = (
                        from item in categoryInfoArray
                        where length.Contains<long>(item.Id)
                        select item).ToArray<CategoryInfo>();
                }
            }
            else
            {
                IEnumerable<long> nums =
                    from item in (IEnumerable<CategoryInfo>)array
                    where (int)item.Path.Split(new char[] { '|' }).Length == 3
                    select long.Parse(item.Path.Split(new char[] { '|' })[0]);
                categoryInfoArray = (
                    from item in categoryInfoArray
                    where nums.Contains<long>(item.Id)
                    select item).ToArray<CategoryInfo>();
            }
            return categoryInfoArray;
        }

        IQueryable<CategoryInfo> ICategoryService.GetCategories()
        {
            return this.context.CategoryInfo.FindAll<CategoryInfo>();
        }

        private void ProcessingDeleteCategory(long id)
        {
            IQueryable<long> nums =
                from c in this.context.CategoryInfo.FindBy<CategoryInfo>((CategoryInfo c) => c.ParentCategoryId == id)
                select c.Id;
            if (nums.Count<long>() != 0)
            {
                foreach (long list in nums.ToList<long>())
                {
                    this.ProcessingDeleteCategory(list);
                }
                Instance<ICashDepositsService>.Create.DeleteCategoryCashDeposits(id);
                this.context.CategoryInfo.Remove(this.context.CategoryInfo.FindById<CategoryInfo>(id));
            }
            else
            {
                this.context.CategoryInfo.Remove(this.context.CategoryInfo.FindById<CategoryInfo>(id));
            }
        }

        public void UpdateCategory(CategoryInfo model)
        {
            CategoryInfo icon = this.context.CategoryInfo.FindById<CategoryInfo>(model.Id);
            icon.Icon = model.Icon;
            icon.Meta_Description = model.Meta_Description;
            icon.Meta_Keywords = model.Meta_Keywords;
            icon.Meta_Title = model.Meta_Title;
            icon.Name = model.Name;
            icon.RewriteName = model.RewriteName;
            icon.TypeId = model.TypeId;
            icon.CommisRate = model.CommisRate;
            this.context.SaveChanges();
            Cache.Remove("Cache-Categories");
        }

        public void UpdateCategoryDisplaySequence(long id, long displaySequence)
        {
            if (id <= (long)0)
            {
                throw new ArgumentNullException("id", string.Format("更新一个分类的显示顺序时，id={0}", id));
            }
            if ((long)0 >= displaySequence)
            {
                throw new ArgumentNullException("displaySequence", "更新一个分类的显示顺序时，displaySequence小于等于零");
            }
            CategoryInfo categoryInfo = this.context.CategoryInfo.FindById<CategoryInfo>(id);
            if ((categoryInfo == null ? true : categoryInfo.Id != id))
            {
                throw new Exception(string.Format("更新一个分类的显示顺序时，找不到id={0} 的分类", id));
            }
            categoryInfo.DisplaySequence = displaySequence;
            this.context.SaveChanges();
            Cache.Remove("Cache-Categories");
        }

        public void UpdateCategoryName(long id, string name)
        {
            if (id <= (long)0)
            {
                throw new ArgumentNullException("id", string.Format("更新一个分类的名称时，id={0}", id));
            }
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("name", "更新一个分类的名称时，name为空");
            }
            CategoryInfo categoryInfo = this.context.CategoryInfo.FindById<CategoryInfo>(id);
            if ((categoryInfo == null ? true : categoryInfo.Id != id))
            {
                throw new Exception(string.Format("更新一个分类的名称时，找不到id={0} 的分类", id));
            }
            categoryInfo.Name = name;
            this.context.SaveChanges();
            Cache.Remove("Cache-Categories");
        }
    }
}
