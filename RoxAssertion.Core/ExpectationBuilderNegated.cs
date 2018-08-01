namespace RoxAssertion.Core
{
    internal class ExpectationBuilderNegated<T> : ExpectationBuilder<T>
    {
        private ExpectationBuilder<T> _innerBuilder;

        public ExpectationBuilderNegated(ExpectationBuilder<T> builder)
            : base(builder.Value)
        {
            _innerBuilder = builder;
        }

        internal override bool IsNegated => !_innerBuilder.IsNegated;
    }
}
