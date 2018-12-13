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
            _rgbRange = 35;
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

    }
}
