using System;
using Accord.Imaging;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Collections.Generic;

namespace CountPostIts.ImageRecognition.Tests
{
    [TestClass]
    public class InformationTest
    {
        int _rgbRange;
        IBlobCounterWrapper blobCounterWrapperMock;
        ISimpleShapeCheckerWrapper simpleShapeCheckerWrapperMock;
        IColorFilteringWrapper colorFilteringWrapperMock;
        Information information;
        Dictionary<string, int> rgb = new Dictionary<string, int>();
        Bitmap test_image1;

        [TestInitialize()]
        public void BeforeEachTest()
        {
            _rgbRange = 45;
            blobCounterWrapperMock = Substitute.For<IBlobCounterWrapper>();
            simpleShapeCheckerWrapperMock = Substitute.For<ISimpleShapeCheckerWrapper>();
            colorFilteringWrapperMock = Substitute.For<IColorFilteringWrapper>();
            information = new Information(blobCounterWrapperMock, simpleShapeCheckerWrapperMock, colorFilteringWrapperMock);
            rgb.Add("R", 100);
            rgb.Add("G", 150);
            rgb.Add("B", 200);
            test_image1 = (Bitmap)Bitmap.FromFile("../../TestImages/test1.jpg");
        }


        [TestMethod]
        public void BlobsInImageCallsGetObjectInformation()
        {
            Assert.AreEqual(information.BlobsInImage(test_image1).GetType(), typeof(Blob[]));
        }

        [TestMethod]
        public void SetFiltersCallsOwnRGB()
        {
            Dictionary<string, int> rgbExtreme = new Dictionary<string, int>();
            rgbExtreme.Add("R", 10);
            rgbExtreme.Add("G", 150);
            rgbExtreme.Add("B", 250);
            information.setFilters(rgbExtreme);
            colorFilteringWrapperMock.Received().OwnRed(0, 10 + _rgbRange);
            colorFilteringWrapperMock.Received().OwnGreen(150 - _rgbRange, 150 + _rgbRange);
            colorFilteringWrapperMock.Received().OwnBlue(250 - _rgbRange, 255);
        }

        [TestMethod]
        public void FindRGBIntervalReturnsValuesBetweenRGBMaxAndMin()
        {
            
            Assert.AreEqual(0, information.FindRGBInterval(10)[0]);
            Assert.AreEqual(255, information.FindRGBInterval(250)[1]);
        }

        [TestMethod]
        public void FilterImageCallsSetFiltersAndOwnApplyInPlace()
        {
            information.FilterImage(test_image1, rgb);
            colorFilteringWrapperMock.Received().OwnApplyInPlace(test_image1);
        }

    }
}
