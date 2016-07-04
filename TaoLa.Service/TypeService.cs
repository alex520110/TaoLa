using Himall.Entity;
using Himall.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaoLa.Core;
using TaoLa.IServices;

namespace TaoLa.Service
{
    public class TypeService : ServiceBase, ITypeService, IService, IDisposable
    {
        private Dictionary<SpecificationType, string> _SpecKeyValue = new Dictionary<SpecificationType, string>();

        public TypeService()
        {
        }

        public void AddType(ProductTypeInfo model)
        {
            this.context.ProductTypeInfo.Add(model);
            this.context.SaveChanges();
        }

        public void DeleteType(long id)
        {
            ProductTypeInfo productTypeInfo = this.context.ProductTypeInfo.FindById<ProductTypeInfo>(id);
            if (productTypeInfo.CategoryInfo.Count<CategoryInfo>() > 0)
            {
                throw new TaoLaException("该类型已经有分类关联，不能删除.");
            }
            this.context.ProductTypeInfo.Remove(productTypeInfo);
            this.context.SaveChanges();
        }

        public ProductTypeInfo GetType(long id)
        {
            return this.context.ProductTypeInfo.FindById<ProductTypeInfo>(id);
        }

        public IQueryable<ProductTypeInfo> GetTypes()
        {
            return this.context.ProductTypeInfo.FindAll<ProductTypeInfo>();
        }
        /// <summary>
        /// 获取产品类型列表
        /// </summary>
        /// <param name="search"></param>
        /// <param name="pageNo"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public PageModel<ProductTypeInfo> GetTypes(string search, int pageNo, int pageSize)
        {
            bool flag = string.IsNullOrWhiteSpace(search);
            int num = 0;

            IQueryable<ProductTypeInfo> productTypeInfos = this.context.ProductTypeInfo.FindBy<ProductTypeInfo, long>((ProductTypeInfo t) => t.Name.Contains(search) || flag, pageNo, pageSize, out num, (ProductTypeInfo t) => t.Id, false);
            productTypeInfos.ToList<ProductTypeInfo>();
            return new PageModel<ProductTypeInfo>()
            {
                Total = num,
                Models = productTypeInfos
            };
        }

        private void ProcessingAttr(ProductTypeInfo model)
        {
            this.ProcessingAttrDeleteAndAdd(model);
            this.ProcessingAttrUpdate(model);
        }

        private void ProcessingAttrDeleteAndAdd(ProductTypeInfo model)
        {
            ProductTypeInfo productTypeInfo = this.context.ProductTypeInfo.FindById<ProductTypeInfo>(model.Id);
            List<AttributeInfo> list = productTypeInfo.AttributeInfo.Except<AttributeInfo>(model.AttributeInfo, new AttrComparer()).ToList<AttributeInfo>();
            foreach (AttributeInfo attributeInfo in list)
            {
                IQueryable<AttributeValueInfo> attributeValueInfos = this.context.AttributeValueInfo.FindBy<AttributeValueInfo>((AttributeValueInfo a) => a.AttributeId.Equals(attributeInfo.Id));
                foreach (AttributeValueInfo attributeValueInfo in attributeValueInfos.ToList<AttributeValueInfo>())
                {
                    this.context.AttributeValueInfo.Remove(attributeValueInfo);
                }
                this.context.AttributeInfo.Remove(attributeInfo);
            }
            List<AttributeInfo> attributeInfos = model.AttributeInfo.Except<AttributeInfo>(productTypeInfo.AttributeInfo, new AttrComparer()).ToList<AttributeInfo>();
            if ((attributeInfos == null ? false : attributeInfos.Count<AttributeInfo>() > 0))
            {
                foreach (AttributeInfo attributeInfo1 in attributeInfos)
                {
                    this.context.AttributeInfo.Add(attributeInfo1);
                }
            }
        }

        private void ProcessingAttrUpdate(ProductTypeInfo model)
        {
            AttributeValueInfo list = null;
            ProductTypeInfo productTypeInfo = this.context.ProductTypeInfo.FindById<ProductTypeInfo>(model.Id);
            foreach (AttributeInfo attributeInfo in model.AttributeInfo.ToList<AttributeInfo>())
            {
                if (productTypeInfo.AttributeInfo.Any<AttributeInfo>((AttributeInfo a) => (!a.Id.Equals(attributeInfo.Id) ? false : attributeInfo.Id != (long)0)))
                {
                    AttributeInfo name = productTypeInfo.AttributeInfo.FirstOrDefault<AttributeInfo>((AttributeInfo a) => a.Id.Equals(attributeInfo.Id));
                    name.Name = attributeInfo.Name;
                    name.IsMulti = attributeInfo.IsMulti;
                    IEnumerable<AttributeValueInfo> attributeValueInfos = name.AttributeValueInfo.Except<AttributeValueInfo>(attributeInfo.AttributeValueInfo, new AttrValueComparer());
                    if ((attributeValueInfos == null ? false : 0 < attributeValueInfos.Count<AttributeValueInfo>()))
                    {
                        foreach (AttributeValueInfo list2 in attributeValueInfos.ToList<AttributeValueInfo>())
                        {
                            this.context.AttributeValueInfo.Remove(list2);
                        }
                    }
                    IEnumerable<AttributeValueInfo> attributeValueInfos1 = attributeInfo.AttributeValueInfo.Except<AttributeValueInfo>(name.AttributeValueInfo, new AttrValueComparer());
                    if ((attributeValueInfos1 == null ? false : 0 < attributeValueInfos1.Count<AttributeValueInfo>()))
                    {
                        foreach (AttributeValueInfo id in attributeValueInfos1.ToList<AttributeValueInfo>())
                        {
                            id.AttributeId = attributeInfo.Id;
                            this.context.AttributeValueInfo.Add(id);
                        }
                    }
                }
            }
        }

        private void ProcessingBrand(ProductTypeInfo model)
        {
            ProductTypeInfo productTypeInfo = this.context.ProductTypeInfo.FindById<ProductTypeInfo>(model.Id);
            foreach (TypeBrandInfo list in productTypeInfo.TypeBrandInfo.ToList<TypeBrandInfo>())
            {
                this.context.TypeBrandInfo.Remove(list);
            }
            foreach (TypeBrandInfo typeBrandInfo in model.TypeBrandInfo)
            {
                this.context.TypeBrandInfo.Add(typeBrandInfo);
            }
        }

        private void ProcessingCommon(ProductTypeInfo model)
        {
            ProductTypeInfo name = this.context.ProductTypeInfo.FindById<ProductTypeInfo>(model.Id);
            name.Name = model.Name;
        }

        private void ProcessingSpecificationValues(ProductTypeInfo model)
        {
            if (model.IsSupportColor)
            {
                this.UpdateSpecificationValues(model, SpecificationType.Color);
            }
            if (model.IsSupportSize)
            {
                this.UpdateSpecificationValues(model, SpecificationType.Size);
            }
            if (model.IsSupportVersion)
            {
                this.UpdateSpecificationValues(model, SpecificationType.Version);
            }
            ProductTypeInfo isSupportVersion = this.context.ProductTypeInfo.FindById<ProductTypeInfo>(model.Id);
            isSupportVersion.IsSupportVersion = model.IsSupportVersion;
            isSupportVersion.IsSupportColor = model.IsSupportColor;
            isSupportVersion.IsSupportSize = model.IsSupportSize;
        }

        private void UpdateSpecificationValues(ProductTypeInfo model, SpecificationType specEnum)
        {
            SpecificationValueInfo list = null;
            IEnumerable<SpecificationValueInfo> specificationValueInfo =
                from s in model.SpecificationValueInfo
                where s.Specification == specEnum
                select s;
            IEnumerable<SpecificationValueInfo> specificationValueInfos = (
                from s in this.context.SpecificationValueInfo
                where s.TypeId.Equals(model.Id) && (int)s.Specification == (int)specEnum
                select s).AsEnumerable<SpecificationValueInfo>();
            IEnumerable<SpecificationValueInfo> specificationValueInfos1 = specificationValueInfos.Except<SpecificationValueInfo>(specificationValueInfo, new SpecValueComparer());
            foreach (SpecificationValueInfo list2 in specificationValueInfos1.ToList<SpecificationValueInfo>())
            {
                this.context.SpecificationValueInfo.Remove(list2);
            }
            IEnumerable<SpecificationValueInfo> specificationValueInfos2 = specificationValueInfo.Except<SpecificationValueInfo>(specificationValueInfos, new SpecValueComparer());
            foreach (SpecificationValueInfo list1 in specificationValueInfos2.ToList<SpecificationValueInfo>())
            {
                this.context.SpecificationValueInfo.Add(list1);
            }
        }

        public void UpdateType(ProductTypeInfo model)
        {
            this.ProcessingBrand(model);
            this.ProcessingAttr(model);
            this.ProcessingSpecificationValues(model);
            this.ProcessingCommon(model);
            this.context.SaveChanges();
        }

        public IQueryable<ProductTypeInfo> GetTypes(string keyWords)
        {
            IQueryable<ProductTypeInfo> TypeInfos = this.context.ProductTypeInfo.FindBy<ProductTypeInfo>((ProductTypeInfo item) => keyWords == null || (keyWords == "") || item.Name.Contains(keyWords));
            return TypeInfos;
        }
    }
}
