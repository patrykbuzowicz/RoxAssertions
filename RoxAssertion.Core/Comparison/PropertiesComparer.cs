﻿using RoxAssertion.Core.Comparison;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RoxAssertion.Core
{
    internal class PropertiesComparer
    {
        public static readonly PropertiesComparer Instance = new PropertiesComparer();

        public Dictionary<string, DiffPair> Compare(object expected, object received)
        {
            return Compare(expected, received, Array.Empty<string>());
        }

        public Dictionary<string, DiffPair> Compare(object expected, object received, string[] excluded)
        {
            if (expected == null)
                throw new ArgumentNullException(nameof(expected));
            if (received == null)
                throw new ArgumentNullException(nameof(received));

            var result = new Dictionary<string, DiffPair>();
            var receivedPropsWithValues = GetPropertiesWithValues(received, excluded);
            var expectedPropsWithValues = GetPropertiesWithValues(expected, excluded);

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

        private Dictionary<string, object> GetPropertiesWithValues(object value, string[] excluded)
        {
            return value.GetType()
                .GetProperties()
                .Where(property => !excluded.Contains(property.Name))
                .ToDictionary(property => property.Name, property => property.GetValue(value));
        }
    }
}