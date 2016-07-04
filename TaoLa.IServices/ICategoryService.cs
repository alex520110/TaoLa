using Himall.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaoLa.IServices
{
    public interface ICategoryService : IService, IDisposable
    {
        string GetEffectCategoryName(long shopId, long typeId);

        IEnumerable<CategoryInfo> GetMainCategory();

        IEnumerable<CategoryInfo> GetCategoryByParentId(long id);

        IEnumerable<CategoryInfo> GetValidBusinessCategoryByParentId(long id);

        void AddCategory(CategoryInfo model);

        CategoryInfo GetCategory(long id);

        IQueryable<CategoryInfo> GetCategories();

        void UpdateCategoryName(long id, string name);

        void UpdateCategoryDisplaySequence(long id, long displaySequence);

        IEnumerable<CategoryInfo> GetFirstAndSecondLevelCategories();

        IEnumerable<CategoryInfo> GetSecondAndThirdLevelCategories(params long[] ids);

        IEnumerable<CategoryInfo> GetTopLevelCategories(IEnumerable<long> categoryIds);

        long GetMaxCategoryId();

        void UpdateCategory(CategoryInfo model);

        void DeleteCategory(long id);

        PageModel<CategoryInfo> GetCategoryByName(string name, int pageNo, int pageSize);
    }
}
