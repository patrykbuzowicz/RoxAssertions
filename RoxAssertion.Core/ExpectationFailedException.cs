using System;

namespace RoxAssertion.Core
{
    public class ExpectationFailedException : Exception
    {
        public ExpectationFailedException(string message) 
            : base(message)
        {
        }
    }
}
