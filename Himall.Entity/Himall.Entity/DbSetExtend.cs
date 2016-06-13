using Himall.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Himall.Entity
{
	public static class DbSetExtend
	{
		public static IQueryable<TEntity> FindAll<TEntity>(this DbSet<TEntity> dbSet) where TEntity : BaseModel
		{
			return from item in dbSet
			where true
			select item;
		}

		public static IQueryable<TEntity> FindAll<TEntity, TKey>(this DbSet<TEntity> dbSet, int pageNumber, int pageSize, out int total, Expression<Func<TEntity, TKey>> orderBy, bool isAsc = true) where TEntity : BaseModel
		{
			total = dbSet.Count<TEntity>();
			IQueryable<TEntity> source = from item in dbSet
			where true
			select item;
			if (isAsc)
			{
				source = source.OrderBy(orderBy);
			}
			else
			{
				source = source.OrderByDescending(orderBy);
			}
			return source.Skip((pageNumber - 1) * pageSize).Take(pageSize);
		}

		public static TEntity FindById<TEntity>(this DbSet<TEntity> dbSet, object id) where TEntity : BaseModel
		{
			return dbSet.FirstOrDefault((TEntity p) => p.Id == id);
		}

		public static IQueryable<TEntity> FindBy<TEntity>(this DbSet<TEntity> dbSet, Expression<Func<TEntity, bool>> where) where TEntity : BaseModel
		{
			return dbSet.Where(where);
		}

		public static IQueryable<TEntity> FindBy<TEntity>(this IQueryable<TEntity> entities, Expression<Func<TEntity, bool>> where) where TEntity : BaseModel
		{
			return entities.Where(where);
		}

		public static IQueryable<TEntity> FindBy<TEntity>(this DbSet<TEntity> dbSet, Expression<Func<TEntity, bool>> where, int pageNumber, int pageSize, out int total) where TEntity : BaseModel
		{
			total = dbSet.Count(where);
			return (from item in dbSet.Where(@where)
			orderby item.Id
			select item).Skip((pageNumber - 1) * pageSize).Take(pageSize);
		}

		public static IQueryable<TEntity> FindBy<TEntity>(this IQueryable<TEntity> entities, Expression<Func<TEntity, bool>> where, int pageNumber, int pageSize, out int total) where TEntity : BaseModel
		{
			total = entities.Count(where);
			return (from item in entities.Where(@where)
			orderby item.Id
			select item).Skip((pageNumber - 1) * pageSize).Take(pageSize);
		}

		public static IQueryable<TEntity> FindBy<TEntity, TKey>(this DbSet<TEntity> dbSet, Expression<Func<TEntity, bool>> where, int pageNumber, int pageSize, out int total, Expression<Func<TEntity, TKey>> orderBy, bool isAsc = true) where TEntity : BaseModel
		{
			total = dbSet.Count(where);
			IQueryable<TEntity> result;
			if (isAsc)
			{
				result = dbSet.Where(where).OrderBy(orderBy).Skip((pageNumber - 1) * pageSize).Take(pageSize);
			}
			else
			{
				result = dbSet.Where(where).OrderByDescending(orderBy).Skip((pageNumber - 1) * pageSize).Take(pageSize);
			}
			return result;
		}

		public static IQueryable<TEntity> FindBy<TEntity, TKey>(this IQueryable<TEntity> entities, Expression<Func<TEntity, bool>> where, int pageNumber, int pageSize, out int total, Expression<Func<TEntity, TKey>> orderBy, bool isAsc = true)
		{
			total = entities.Count(where);
			IQueryable<TEntity> result;
			if (isAsc)
			{
				result = entities.Where(where).OrderBy(orderBy).Skip((pageNumber - 1) * pageSize).Take(pageSize);
			}
			else
			{
				result = entities.Where(where).OrderByDescending(orderBy).Skip((pageNumber - 1) * pageSize).Take(pageSize);
			}
			return result;
		}

		public static IQueryable<TEntity> GetPage<TEntity>(this IQueryable<TEntity> entities, out int total, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, int pageNumber = 1, int pageSize = 20)
		{
			if (orderBy == null)
			{
				throw new ArgumentNullException("排序条件不能为空");
			}
			total = entities.Count<TEntity>();
			entities = orderBy(entities);
			return entities.Skip((pageNumber - 1) * pageSize).Take(pageSize);
		}

		public static IQueryable<TEntity> GetPage<TEntity>(this IQueryable<TEntity> entities, out int total, int pageNumber = 1, int pageSize = 20, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null) where TEntity : BaseModel
		{
			if (orderBy == null)
			{
				orderBy = delegate(IQueryable<TEntity> d)
				{
					return from o in d
					orderby o.Id descending
					select o;
				};
			}
			total = entities.Count<TEntity>();
			entities = orderBy(entities);
			return entities.Skip((pageNumber - 1) * pageSize).Take(pageSize);
		}

		public static void Remove<TEntity>(this DbSet<TEntity> dbSet, params object[] ids) where TEntity : BaseModel
		{
			List<TEntity> list = new List<TEntity>();
			for (int i = 0; i < ids.Length; i++)
			{
				object id = ids[i];
				list.Add(dbSet.FindById(id));
			}
			dbSet.RemoveRange(list);
		}

		public static void Remove<TEntity>(this DbSet<TEntity> dbSet, Expression<Func<TEntity, bool>> where) where TEntity : BaseModel
		{
			IEnumerable<TEntity> entities = dbSet.FindBy(where);
			dbSet.RemoveRange(entities);
		}

		public static bool Exist<TEntity>(this DbSet<TEntity> dbSet, Expression<Func<TEntity, bool>> where) where TEntity : BaseModel
		{
			return dbSet.Count(where) > 0;
		}
	}
}
