using System;

namespace RoxAssertion.Core
{
    public class ExpectationBuilderProperties<T> : ExpectationBuilder<T>
    {
        internal string[] ExcludedProperties { get; }

        internal ExpectationBuilderProperties(T value)
            : this(value, Array.Empty<string>())
        {
        }
        
        internal ExpectationBuilderProperties(T value, string[] excludedProperties) 
            : base(value)
        {
            ExcludedProperties = excludedProperties;
        }
    }
}