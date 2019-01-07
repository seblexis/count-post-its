using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CountPostIts.ImageRecognition.Tests
{
    [TestClass]
    public class ColourRangeTest
    {
        ColorRange _testColor;

        [TestInitialize]
        public void BeforeEachTest()
        {
            _testColor = new ColorRange();
        }

        [TestMethod]
        public void SetsColourRange()
        {
            ColorRange testColor = new ColorRange();            
            int[] expected = new int[] { 100, 120 };

            testColor.RangeBlue = new int[] { 100, 120 };

            Assert.AreEqual(expected[0], testColor.RangeBlue[0]);
            Assert.AreEqual(expected[1], testColor.RangeBlue[1]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DoesNotAcceptValuesBelow0()
        {
            _testColor.RangeBlue = new int[] { -10, 100 };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DoesNotAcceptValuesAbove255()
        {
            _testColor.RangeBlue = new int[] { 0, 300 };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DoesNotAcceptValuesInWrongOrder()
        {
            _testColor.RangeBlue = new int[] { 200, 100 };
        }

    }
}
