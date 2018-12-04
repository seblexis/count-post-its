using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace CountPostIts.ImageRecognition.Tests
{
    [TestFixture]
    public class ImageColouringTest
    {
      

        [Test]
        public void SetFiltersSetsColours()
        {
            ImageColouring imageColouring = new ImageColouring();
            Dictionary<string, int> rgb = new Dictionary<string, int>();  
            IColorFiltering colorFilterMock = Substitute.For<IColorFiltering>();
            rgb.Add("R", 100);
            rgb.Add("G", 150);
            rgb.Add("B", 200);
            imageColouring.setFilters(rgb, colorFilterMock);
            colorFilterMock.Received().AddRedValue(75, 125);
            colorFilterMock.Received().AddGreenValue(125, 175);
            colorFilterMock.Received().AddBlueValue(175, 225);
        }


        [Test]
        public void ReturnRangeOfFiftyForRGBValue()
        {
            ImageColouring imageColouring = new ImageColouring();
            Assert.AreEqual(imageColouring.RGBRange(100)[0], 75);
            Assert.AreEqual(imageColouring.RGBRange(100)[1], 125);
        }

        [Test]
        public void DoesntReturnRangeBelowPossibleRGBValue()
        {
            ImageColouring imageColouring = new ImageColouring();
            Assert.AreEqual(imageColouring.RGBRange(24)[0], 0);
        }

        [Test]
        public void DoesntReturnRangeAbovePossibleRGBValue()
        {
            ImageColouring imageColouring = new ImageColouring();
            Assert.AreEqual(imageColouring.RGBRange(231)[1], 255);
        }

    }
}
