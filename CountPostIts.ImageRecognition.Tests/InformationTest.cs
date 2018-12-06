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
        IBlobCounterWrapper blobCounterWrapperMock;
        ISimpleShapeCheckerWrapper simpleShapeCheckerWrapperMock;
        IColorFilteringWrapper colorFilteringWrapperMock;
        Information information;
        Dictionary<string, int> rgb = new Dictionary<string, int>();
        Bitmap test_image1;
        Blob[] test_blob;

        [TestInitialize()]
        public void BeforeEachTest()
        {
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
        public void HasQuadrilateralReturnsTrueForTest1()
        {
            Dictionary<string, int> rgb_yellow_postit = new Dictionary<string, int>();
            rgb_yellow_postit.Add("R", 217);
            rgb_yellow_postit.Add("G", 245);
            rgb_yellow_postit.Add("B", 143);
            Assert.AreEqual(true, information.CountPostItNotes("../../TestImages/test1.jpg", rgb_yellow_postit));
        }

        [TestMethod]
        public void HasQuadrilateralReturnsFalseForTest2()
        {
       

            Assert.AreEqual(information.CountPostItNotes("../../TestImages/test2.jpg", rgb), false);
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
            colorFilteringWrapperMock.Received().OwnRed(0, 35);
            colorFilteringWrapperMock.Received().OwnGreen(125, 175);
            colorFilteringWrapperMock.Received().OwnBlue(225, 255);
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
