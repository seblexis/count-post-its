﻿using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace CountPostIts.ImageRecognition.Tests
{
    [TestClass]
    public class ImageFilterTest
    {
        private IColorFilteringWrapper _colorFilteringWrapperMock;
        private IColorRange _rgbRangeMock;
        private Bitmap _testImage1;
        private ImageFilter _imageFilter;

        [TestInitialize]
        public void BeforeEachTest()
        {
            _colorFilteringWrapperMock = Substitute.For<IColorFilteringWrapper>();
            _rgbRangeMock = Substitute.For<IColorRange>();
            _rgbRangeMock.RangeRed.Returns(new[] { 1, 2 });
            _rgbRangeMock.RangeGreen.Returns(new[] { 1, 2 });
            _rgbRangeMock.RangeBlue.Returns(new[] { 1, 2 });
            _testImage1 = (Bitmap)Bitmap.FromFile("../../TestImages/test1.jpg");
            _imageFilter = new ImageFilter(_colorFilteringWrapperMock);
        }

        [TestMethod]
        public void GetFilteretedImageSetsFilter()
        {
            _imageFilter.GetFilteredImage(_testImage1, _rgbRangeMock);
            _colorFilteringWrapperMock.Received().OwnRed(1,2);
            _colorFilteringWrapperMock.Received().OwnGreen(1, 2);
            _colorFilteringWrapperMock.Received().OwnBlue(1, 2);
        }

        [TestMethod]
        public void GetFilteretedAppliesFiltersToImage()
        {
            _imageFilter.GetFilteredImage(_testImage1, _rgbRangeMock);  
        }
    }
}
