using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TaoLa.Core
{
    public static class PredicateExtensions
    {
        public static Expression<Func<T, bool>> True<T>()
        {
            return (T f) => true;
        }

        public static Expression<Func<T, bool>> False<T>()
        {
            return (T f) => false;
        }

        public static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
        {
            System.Collections.Generic.Dictionary<ParameterExpression, ParameterExpression> map = first.Parameters.Select((ParameterExpression f, int i) => new
            {
                f = f,
                s = second.Parameters[i]
            }).ToDictionary(p => p.s, p => p.f);
            Expression arg = ParameterRebinder.ReplaceParameters(map, second.Body);
            return Expression.Lambda<T>(merge(first.Body, arg), first.Parameters);
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, new Func<Expression, Expression, Expression>(Expression.And));
        }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, new Func<Expression, Expression, Expression>(Expression.Or));
        }
    }
}
