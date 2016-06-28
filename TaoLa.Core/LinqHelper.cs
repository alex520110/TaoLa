using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TaoLa.Core
{
    public static class LinqHelper
    {
        public static System.Collections.Generic.IEnumerable<TSource> DistinctBy<TSource, TKey>(this System.Collections.Generic.IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> hashSet = new HashSet<TKey>();
            foreach (TSource current in source)
            {
                if (hashSet.Add(keySelector(current)))
                {
                    yield return current;
                }
            }
            yield break;
        }

        public static Expression<Func<T, bool>> GetDefaultPredicate<T>(this IQueryable<T> source, bool defultPredicate)
        {
            Expression<Func<T, bool>> result;
            if (defultPredicate)
            {
                result = PredicateExtensions.True<T>();
            }
            else
            {
                result = PredicateExtensions.False<T>();
            }
            return result;
        }

        public static Func<IQueryable<T>, IOrderedQueryable<T>> GetOrderBy<T>(this IQueryable<T> source, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy)
        {
            if (orderBy == null)
            {
                throw new System.ArgumentNullException("初始排序不可为空");
            }
            return orderBy;
        }
    }
}
