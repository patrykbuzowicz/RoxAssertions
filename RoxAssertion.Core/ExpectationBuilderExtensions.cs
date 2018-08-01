using System;
using System.Linq.Expressions;

namespace RoxAssertion.Core
{
    public static class ExpectationBuilderExtensions
    {
        public static ExpectationBuilder<T> Not<T>(this ExpectationBuilder<T> builder)
        {
            return new ExpectationBuilderNegated<T>(builder.Value);
        }

        public static ExpectationBuilderProperties<T> Properties<T>(this ExpectationBuilder<T> builder)
        {
            return new ExpectationBuilderProperties<T>(builder.Value);
        }

        public static ExpectationBuilderProperties<T> PropertiesWithout<T>(this ExpectationBuilder<T> builder, Expression<Func<T, object>> selector)
        {
            return new ExpectationBuilderProperties<T>(builder.Value);
        }
        
        public static void Eq(this ExpectationBuilder<int> builder, int expected)
        {
            builder.Process(builder.Value.Equals(expected), $"Expected to receive \"{expected}\", received \"{builder.Value}\" instead");
        }

        public static void IsGreater(this ExpectationBuilder<int> builder, int expected)
        {
            builder.Process(builder.Value > expected, $"Expected to receive value greater than \"{expected}\", received \"{builder.Value}\" which is less or equal");
        }

        public static void RaiseError(this ExpectationBuilder<Action> value)
        {
            throw new NotImplementedException();
        }
    }
}
