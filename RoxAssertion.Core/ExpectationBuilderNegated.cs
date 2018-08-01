namespace RoxAssertion.Core
{
    internal class ExpectationBuilderNegated<T> : ExpectationBuilder<T>
    {
        public ExpectationBuilderNegated(T value)
            : base(value)
        {
        }

        internal override void Process(bool result, string message)
        {
            if (result)
                // TODO expose the negation in the message
                throw new ExpectationFailedException(message);
        }
    }
}
