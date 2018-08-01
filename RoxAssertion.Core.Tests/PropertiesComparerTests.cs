using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoxAssertion.Core.Comparison;
using System.Collections.Generic;

namespace RoxAssertion.Core.Tests
{
    [TestClass]
    public class PropertiesComparerTests
    {
        private PropertiesComparer _subject;

        [TestInitialize]
        public void Init()
        {
            _subject = new PropertiesComparer();
        }

        [TestMethod]
        public void Given_EqualAnonymousObjects_Expect_NoDiff()
        {
            var result = _subject.Compare(
                new { IntProp = 3, StrProp = "test" },
                new { IntProp = 3, StrProp = "test" });

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void Given_SinglePropertyNotEqual_Expect_ThatPropertyReturned()
        {
            var result = _subject.Compare(
                new { IntProp = 4, StrProp = "test" },
                new { IntProp = 3, StrProp = "test" });

            CollectionAssert.AreEquivalent(new Dictionary<string, DiffPair> {
                { "IntProp", new DiffPair(4, 3) }
            }, result);
        }

        [TestMethod]
        public void Given_MultiplePropertiesNotEqual_Expect_BothPropertiesReturned()
        {
            var result = _subject.Compare(
                new { IntProp = 4, StrProp = "test" },
                new { IntProp = 3, StrProp = "test2" });

            CollectionAssert.AreEquivalent(new Dictionary<string, DiffPair> {
                { "IntProp", new DiffPair(4, 3) },
                { "StrProp", new DiffPair("test", "test2") },
            }, result);
        }

        [TestMethod]
        public void Given_PropertyDoesNotExistInReceived_Expect_ThatPropertyReturned()
        {
            var result = _subject.Compare(
                new { IntProp = 3 },
                new { IntProp = 3, StrProp = "test" });

            CollectionAssert.AreEquivalent(new Dictionary<string, DiffPair> {
                { "StrProp", new DiffPair(null, "test") }
            }, result);
        }

        [TestMethod]
        public void Given_PropertyDoesNotExistInExpected_Expect_ThatPropertyReturned()
        {
            var result = _subject.Compare(
                new { IntProp = 3, StrProp = "test" },
                new { IntProp = 3 });

            CollectionAssert.AreEquivalent(new Dictionary<string, DiffPair> {
                { "StrProp", new DiffPair("test", null) }
            }, result);
        }

        [TestMethod]
        public void Given_ReferencePropertyNullInReceived_Expect_ThatPropertyReturned()
        {
            var result = _subject.Compare(
                new { IntProp = 3, StrProp = "test" },
                new { IntProp = 3, StrProp = (string)null });

            CollectionAssert.AreEquivalent(new Dictionary<string, DiffPair> {
                { "StrProp", new DiffPair("test", null) }
            }, result);
        }

        [TestMethod]
        public void Given_ReferencePropertyNullInExpected_Expect_ThatPropertyReturned()
        {
            var result = _subject.Compare(
                new { IntProp = 3, StrProp = (string)null },
                new { IntProp = 3, StrProp = "test" });

            CollectionAssert.AreEquivalent(new Dictionary<string, DiffPair> {
                { "StrProp", new DiffPair(null, "test") }
            }, result);
        }

        [TestMethod]
        public void Given_ReferencePropertyNullInBoth_Expect_EmptyResult()
        {
            var result = _subject.Compare(
                new { IntProp = 3, StrProp = (string)null },
                new { IntProp = 3, StrProp = (string)null });

            Assert.AreEqual(0, result.Count);
        }
    }
}
