using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace Awesomely.Extensions
{
    public static class ExpressionExtensions
    {
        public static MemberExpression GetMember(this Expression method)
        {
            var lambda = method as LambdaExpression;
            if (lambda == null) throw new ArgumentNullException("method");

            MemberExpression memberExpr = null;
            if (lambda.Body.NodeType == ExpressionType.Convert)
            {
                memberExpr = ((UnaryExpression) lambda.Body).Operand as MemberExpression;
            }
            else if (lambda.Body.NodeType == ExpressionType.MemberAccess)
            {
                memberExpr = lambda.Body as MemberExpression;
            }

            return memberExpr;
        }
    }
}
