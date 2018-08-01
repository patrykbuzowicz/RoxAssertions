using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoxAssertion.Core;
using System;
using Unit.Tests;

namespace RoxAssertion.Tests
{
    [TestClass]
    public class ExtraNotTests
    {
        [TestMethod]
        public void Test_Not_Properties()
        {
            var tested = new FizBar() { Bar = "Bar", Fiz = String.Empty };
            var expected = new { Bar = "Bar2", Fiz = String.Empty };
            tested.Expect().Not().Properties().Eq(expected);
        }

        [TestMethod]
        public void Test_Not_PropertiesWithout()
        {
            var tested = new FizBar() { Bar = "Bar", Fiz = "Fiz" };
            var expected = new { Bar = "Bar2", Fiz = "Fiz2" };
            tested.Expect().Not().PropertiesWithout(x => x.Fiz).Eq(expected);
        }

        [TestMethod]
        public void Test_Not_RaiseError_Fails()
        {
            (new Action(() => FizBar.SampleMethod())).Expect().Not().RaiseError();
        }
    }
}
