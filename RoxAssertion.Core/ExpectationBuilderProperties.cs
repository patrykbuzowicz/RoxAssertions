﻿namespace RoxAssertion.Core
{
    public class ExpectationBuilderProperties<T> : ExpectationBuilder<T>
    {
        internal ExpectationBuilderProperties(T value) 
            : base(value)
        {
        }
    }
}