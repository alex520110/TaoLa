using Himall.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaoLa.IServices
{
    public interface ITypeService : IService, IDisposable
    {
        PageModel<ProductTypeInfo> GetTypes(string search, int pageNo, int pageSize);

        IQueryable<ProductTypeInfo> GetTypes();

        ProductTypeInfo GetType(long id);

        void UpdateType(ProductTypeInfo model);

        void DeleteType(long id);

        void AddType(ProductTypeInfo model);

        IQueryable<ProductTypeInfo> GetTypes(string keyWords);
    }
}
