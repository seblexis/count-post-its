using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CountPostIts.ImageRecognition.Tests
{
    [TestClass]
    public class ColorRangeTest
    {
        private ColorRange _testColor;

        [TestInitialize]
        public void BeforeEachTest()
        {
            _testColor = new ColorRange();
        }

        [TestMethod]
        public void SetsColorRange()
        {         
            int[] expected = { 100, 120 };

            _testColor.RangeBlue = new[] { 100, 120 };

            Assert.AreEqual(expected[0], _testColor.RangeBlue[0]);
            Assert.AreEqual(expected[1], _testColor.RangeBlue[1]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DoesNotAcceptValuesBelow0()
        {
            _testColor.RangeBlue = new[] { -10, 100 };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DoesNotAcceptValuesAbove255()
        {
            _testColor.RangeBlue = new[] { 0, 300 };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DoesNotAcceptValuesInWrongOrder()
        {
            _testColor.RangeBlue = new[] { 200, 100 };
        }

    }
}
