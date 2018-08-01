namespace RoxAssertion.Core.Comparison
{
    internal struct DiffPair
    {
        public object Expected { get; }

        public object Received { get; }

        public DiffPair(object expected, object received)
        {
            Expected = expected;
            Received = received;
        }
    }
}