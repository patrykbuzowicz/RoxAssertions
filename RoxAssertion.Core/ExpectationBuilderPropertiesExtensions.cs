using System.Linq;

namespace RoxAssertion.Core
{
    public static class ExpectationBuilderPropertiesExtensions
    {
        private static readonly PropertiesComparer Comparer = new PropertiesComparer();

        public static void Eq<T>(this ExpectationBuilderProperties<T> builder, object expected)
        {
            var comparisonResult = Comparer.Compare(builder.Value, expected);
            var areEqual = !comparisonResult.Any();
            // TODO include diff result in message
            builder.Process(areEqual, "Expected properties to be equal");
        }
    }
}
