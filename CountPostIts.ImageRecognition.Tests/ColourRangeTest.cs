using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CountPostIts.ImageRecognition.Tests
{
    [TestClass]
    public class ColourRangeTest
    {

        [TestMethod]
        public void SetsColourRange()
        {
            ColourRange testColour = new ColourRange();            
            int[] expected = new int[] { 100, 120 };

            testColour.RangeBlue = new int[] { 100, 120 };

            Assert.AreEqual(expected[0], testColour.RangeBlue[0]);
            Assert.AreEqual(expected[1], testColour.RangeBlue[1]);
        }

    }
}
