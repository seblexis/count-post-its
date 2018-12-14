using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CountPostIts.ImageRecognition.Tests
{
    [TestClass]
    public class ColourRangesTest
    {
        [TestMethod]
        public void ColourRangesHasRGBProperty()
        {
            ColourRanges colourRanges = new ColourRanges();
            Type typeOfRGB = colourRanges.RGB.GetType();
            Assert.AreEqual(typeOfRGB, typeof(Dictionary<Colours, Dictionary<string, int[]>>));
        }
    }

}
