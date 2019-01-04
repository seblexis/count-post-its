using System;
using System.Collections.Generic;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace CountPostIts.ImageRecognition.Tests
{
    [TestClass]
    public class ImageFilterTest
    {
        IColorFilteringWrapper colorFilteringWrapperMock;
        Dictionary<string, int[]> rgbRangeMock = new Dictionary<string, int[]>();
        Bitmap test_image1;
        ImageFilter imageFilter;

        [TestInitialize()]
        public void BeforeEachTest()
        {
            colorFilteringWrapperMock = Substitute.For<IColorFilteringWrapper>();
            int[] mockRange = { 1, 2 };
            rgbRangeMock.Add("R", mockRange);
            rgbRangeMock.Add("G", mockRange);
            rgbRangeMock.Add("B", mockRange);
            test_image1 = (Bitmap)Bitmap.FromFile("../../TestImages/test1.jpg");
            imageFilter = new ImageFilter(colorFilteringWrapperMock);
        }


        [TestMethod]
        public void GetFilteretedImageSetsFilter()
        {
            imageFilter.GetFilteredImage(test_image1, rgbRangeMock);
            colorFilteringWrapperMock.Received().OwnRed(1,2);
            colorFilteringWrapperMock.Received().OwnGreen(1, 2);
            colorFilteringWrapperMock.Received().OwnBlue(1, 2);
        }

        [TestMethod]
        public void GetFilteretedAppliesFiltersToImage()
        {
            imageFilter.GetFilteredImage(test_image1, rgbRangeMock);
            
        }

        [TestMethod]
        public void SetRangesWithinRGBRange()
        {
            Dictionary<string, int[]> rgbRangeOutOfBoundsMock = new Dictionary<string, int[]>();
            int[] mockRangeOutOfBound = { -2, 10 };
            rgbRangeOutOfBoundsMock.Add("R", mockRangeOutOfBound);
            rgbRangeOutOfBoundsMock.Add("G", mockRangeOutOfBound);
            rgbRangeOutOfBoundsMock.Add("B", mockRangeOutOfBound);
            Assert.ThrowsException<ArgumentException>(() => imageFilter.GetFilteredImage(test_image1, rgbRangeOutOfBoundsMock));
        }
    }
}
