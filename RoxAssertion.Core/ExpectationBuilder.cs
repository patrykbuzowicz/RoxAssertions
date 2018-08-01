namespace RoxAssertion.Core
{
    public class ExpectationBuilder<T>
    {
        internal T Value { get; }

        internal virtual bool IsNegated { get; } = false;

        internal ExpectationBuilder(T value)
        {
            Value = value;
        }

        public virtual void Eq(object expected)
        {
            if (!Value.Equals(expected) ^ IsNegated)
                throw new ExpectationFailedException($"Expected {(IsNegated ? "not " : "")}to receive \"{expected}\", received \"{Value}\" instead");
        }
    }
}