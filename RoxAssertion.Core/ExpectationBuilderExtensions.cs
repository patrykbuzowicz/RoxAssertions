using System;
using System.Linq;
using System.Linq.Expressions;

namespace RoxAssertion.Core
{
    public static class ExpectationBuilderExtensions
    {
        public static ExpectationBuilder<T> Not<T>(this ExpectationBuilder<T> builder)
        {
            return new ExpectationBuilderNegated<T>(builder);
        }

        public static ExpectationBuilderProperties<T> Properties<T>(this ExpectationBuilder<T> builder)
        {
            return new ExpectationBuilderProperties<T>(builder);
        }

        public static ExpectationBuilderProperties<T> PropertiesWithout<T>(this ExpectationBuilder<T> builder, params Expression<Func<T, object>>[] selectors)
        {
            var excludedProperties = selectors
                .Select(selector => PropertyUtils.ExtractProperty(selector))
                .Select(property => property.Name)
                .ToArray();
            return new ExpectationBuilderProperties<T>(builder, excludedProperties);
        }
    }
}
