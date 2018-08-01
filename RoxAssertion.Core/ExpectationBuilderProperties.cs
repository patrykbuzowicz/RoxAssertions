using System;
using System.Linq;

namespace RoxAssertion.Core
{
    public class ExpectationBuilderProperties<T> : ExpectationBuilder<T>
    {
        private ExpectationBuilder<T> _innerBuilder;

        internal string[] ExcludedProperties { get; }

        internal override bool IsNegated => _innerBuilder.IsNegated;

        internal ExpectationBuilderProperties(ExpectationBuilder<T> builder)
            : this(builder, Array.Empty<string>())
        {
        }
        
        internal ExpectationBuilderProperties(ExpectationBuilder<T> builder, string[] excludedProperties) 
            : base(builder.Value)
        {
            _innerBuilder = builder;
            ExcludedProperties = excludedProperties;
        }

        public override void Eq(object expected)
        {
            var comparisonResult = PropertiesComparer.Instance.Compare(Value, expected, ExcludedProperties);
            var areEqual = !comparisonResult.Any();

            if (!areEqual ^ IsNegated)
                throw new ExpectationFailedException($"Expected properties {(IsNegated ? "not" : "")} to be equal");
        }
    }
}