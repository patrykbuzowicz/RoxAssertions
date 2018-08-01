using System;
using System.Linq.Expressions;
using System.Reflection;

namespace RoxAssertion.Core
{
    internal class PropertyUtils
    {
        public static PropertyInfo ExtractProperty<T>(Expression<Func<T, object>> selector)
        {
            if (selector.Body.NodeType != ExpressionType.MemberAccess)
                throw new ArgumentException("Invalid property access expression", nameof(selector));

            if (!(selector.Body is MemberExpression body))
                throw new ArgumentException("Invalid property access expression", nameof(selector));

            if (!(body.Member is PropertyInfo property))
                throw new ArgumentException("Invalid property access expression", nameof(selector));

            return property;
        }
    }
}