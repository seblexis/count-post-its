using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace CountPostIts.ImageRecognition.Tests
{
    [TestClass]
    public class ColourRangesTest
    {
        IColourRange colourRangeMock;

        [TestMethod]
        public void CallsRangeRedOnColourRangeObject()
        {
            colourRangeMock = Substitute.For<IColourRange>();
            ColourRanges colourRanges = new ColourRanges(colourRangeMock);
            colourRangeMock.Received().RangeRed = new int[] { 80, 130 };
        }

        [TestMethod]
        public void ReturnsListWith6Colours()
        {
            colourRangeMock = Substitute.For<IColourRange>();
            ColourRanges colourRanges = new ColourRanges(colourRangeMock);

            Assert.AreEqual(6, colourRanges.RGB.Count);
        }

    }

}
