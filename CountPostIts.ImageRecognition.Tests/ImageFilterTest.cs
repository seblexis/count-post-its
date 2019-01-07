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
        IColorRange rgbRangeMock;
        Bitmap test_image1;
        ImageFilter imageFilter;

        [TestInitialize()]
        public void BeforeEachTest()
        {
            colorFilteringWrapperMock = Substitute.For<IColorFilteringWrapper>();
            int[] mockRange = { 1, 2 };
            rgbRangeMock = Substitute.For<IColorRange>();
            rgbRangeMock.RangeRed.Returns(new int[] { 1, 2 });
            rgbRangeMock.RangeGreen.Returns(new int[] { 1, 2 });
            rgbRangeMock.RangeBlue.Returns(new int[] { 1, 2 });
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

    }
}
