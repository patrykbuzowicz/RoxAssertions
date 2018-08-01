namespace RoxAssertion.Core
{
    public class ExpectationBuilder<T>
    {
        internal T Value { get; }

        internal ExpectationBuilder(T value)
        {
            Value = value;
        }

        internal virtual void Process(bool result, string message)
        {
            if (!result)
                throw new ExpectationFailedException(message);
        }
    }
}