using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace RoxAssertion.Core.Tests
{
    [TestClass]
    public class PropertyUtilsTests
    {
        [TestMethod]
        public void Given_ValidPropertyAccess_Expect_PropertyInfoReturned()
        {
            var result = PropertyUtils.ExtractProperty<TestClass>(x => x.StrProperty);

            Assert.AreEqual(typeof(TestClass).GetProperty(nameof(TestClass.StrProperty)), result);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Given_MethodAccess_Expect_ExceptionThrown()
        {
            var result = PropertyUtils.ExtractProperty<TestClass>(x => x.Do());
        }

        private class TestClass
        {
            public string StrProperty { get; set; }

            public string Do() => null;
        }
    }
}
