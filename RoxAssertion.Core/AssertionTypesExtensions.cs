namespace RoxAssertion.Core
{
    public static class AssertionTypesExtensions
    {
        public static ExpectationBuilder<T> Expect<T>(this T value)
        {
            return new ExpectationBuilder<T>(value);
        }
    }
}
