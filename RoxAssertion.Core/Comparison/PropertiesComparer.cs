using RoxAssertion.Core.Comparison;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RoxAssertion.Core
{
    internal class PropertiesComparer
    {
        public Dictionary<string, DiffPair> Compare(object expected, object received)
        {
            if (expected == null)
                throw new ArgumentNullException(nameof(expected));
            if (received == null)
                throw new ArgumentNullException(nameof(received));

            var result = new Dictionary<string, DiffPair>();
            var receivedPropsWithValues = GetPropertiesWithValues(received);
            var expectedPropsWithValues = GetPropertiesWithValues(expected);
            
            foreach (var receivedItem in receivedPropsWithValues)
            {
                if (expectedPropsWithValues.ContainsKey(receivedItem.Key))
                {
                    var expectedItemValue = expectedPropsWithValues[receivedItem.Key];
                    expectedPropsWithValues.Remove(receivedItem.Key);

                    if (receivedItem.Value == null && expectedItemValue == null)
                        continue;

                    if (receivedItem.Value == null || expectedItemValue == null || !receivedItem.Value.Equals(expectedItemValue))
                    {
                        result.Add(receivedItem.Key, new DiffPair(expectedItemValue, receivedItem.Value));
                    }
                }
                else
                {
                    result.Add(receivedItem.Key, new DiffPair(null, receivedItem.Value));
                }
            }

            foreach (var expectedItem in expectedPropsWithValues)
            {
                result.Add(expectedItem.Key, new DiffPair(expectedItem.Value, null));
            }

            return result;
        }
        
        private Dictionary<string, object> GetPropertiesWithValues(object value)
        {
            return value.GetType()
                .GetProperties()
                .ToDictionary(property => property.Name, property => property.GetValue(value));
        }
    }
}