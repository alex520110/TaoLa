using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TaoLa.Core
{
    public class ParameterRebinder : ExpressionVisitor
    {
        private readonly System.Collections.Generic.Dictionary<ParameterExpression, ParameterExpression> map;

        public ParameterRebinder(System.Collections.Generic.Dictionary<ParameterExpression, ParameterExpression> map)
        {
            this.map = (map ?? new System.Collections.Generic.Dictionary<ParameterExpression, ParameterExpression>());
        }

        public static Expression ReplaceParameters(System.Collections.Generic.Dictionary<ParameterExpression, ParameterExpression> map, Expression exp)
        {
            return new ParameterRebinder(map).Visit(exp);
        }

        protected override Expression VisitParameter(ParameterExpression p)
        {
            ParameterExpression parameterExpression;
            if (this.map.TryGetValue(p, out parameterExpression))
            {
                p = parameterExpression;
            }
            return base.VisitParameter(p);
        }
    }
}
