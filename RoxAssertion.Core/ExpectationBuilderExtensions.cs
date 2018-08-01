﻿using System;
using System.Linq.Expressions;

namespace RoxAssertion.Core
{
    public static class ExpectationBuilderExtensions
    {
        public static ExpectationBuilder<T> Not<T>(this ExpectationBuilder<T> value)
        {
            throw new NotImplementedException();
        }

        public static ExpectationBuilder<T> Properties<T>(this ExpectationBuilder<T> value)
        {
            throw new NotImplementedException();
        }

        public static ExpectationBuilder<T> PropertiesWithout<T>(this ExpectationBuilder<T> value, Expression<Func<T, object>> selector)
        {
            throw new NotImplementedException();
        }

        public static void Eq<T>(this ExpectationBuilder<T> value, object expected)
        {
            throw new NotImplementedException();
        }

        public static void Eq(this ExpectationBuilder<int> builder, int expected)
        {
            if (!builder.Value.Equals(expected))
                throw new ExpectationFailedException($"Expected to receive \"{expected}\", received \"{builder.Value}\" instead");
        }

        public static void IsGreater(this ExpectationBuilder<int> builder, int expected)
        {
            if (builder.Value <= expected)
                throw new ExpectationFailedException($"Expected to receive value greater than \"{expected}\", received \"{builder.Value}\" which is less or equal");
        }

        public static void RaiseError(this ExpectationBuilder<Action> value)
        {
            throw new NotImplementedException();
        }
    }
}
