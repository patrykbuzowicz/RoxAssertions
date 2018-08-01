namespace RoxAssertion.Core
{
    public class ExpectationBuilder<T>
    {
        internal T Value { get; }

        internal ExpectationBuilder(T value)
        {
            Value = value;
        }
    }
}