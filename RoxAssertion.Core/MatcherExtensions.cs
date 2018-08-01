using System;

namespace RoxAssertion.Core
{
    public static class MatcherExtensions
    {
        public static void IsGreater(this ExpectationBuilder<int> builder, int expected)
        {
            if (builder.Value <= expected ^ builder.IsNegated)
                throw new ExpectationFailedException($"Expected {(builder.IsNegated ? "not " : "")}to receive value greater than \"{expected}\", received \"{builder.Value}\" which is less or equal");
        }

        public static void RaiseError(this ExpectationBuilder<Action> builder)
        {
            bool result;
            try
            {
                builder.Value.Invoke();
                result = false;
            }
            catch
            {
                result = true;
            }

            if (!result ^ builder.IsNegated)
                throw new ExpectationFailedException($"Expected action {(builder.IsNegated ? "not " : "")}to fail");
        }
    }
}
