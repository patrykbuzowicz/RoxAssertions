using System;

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
    }
}