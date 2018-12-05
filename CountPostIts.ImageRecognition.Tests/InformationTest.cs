using System;
using Accord.Imaging;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace CountPostIts.ImageRecognition.Tests
{
    [TestClass]
    public class InformationTest
    {
        [TestMethod]
        public void HasQuadrilateralReturnsTrueForTest1()
        {
            IBlobCounterWrapper blobCounterWrapperMock = Substitute.For<IBlobCounterWrapper>();
            Information information = new Information(blobCounterWrapperMock);
            Assert.AreEqual(information.HasQuadrilateral("test1.jpg"), true);
        }

        [TestMethod]
        public void HasQuadrilateralReturnsFalseForTest2()
        {
            IBlobCounterWrapper blobCounterWrapperMock = Substitute.For<IBlobCounterWrapper>();
            Information information = new Information(blobCounterWrapperMock);
            Assert.AreEqual(information.HasQuadrilateral("test2.jpg"), false);
        }

        [TestMethod]
        public void BlobsInImageCallsGetObjectInformation()
        {
            IBlobCounterWrapper blobCounterWrapperMock = Substitute.For<IBlobCounterWrapper>();
            Information information = new Information(blobCounterWrapperMock);
            Bitmap image = (Bitmap)Bitmap.FromFile("test1.jpg");
            Assert.AreEqual(information.BlobsInImage(image).GetType(), typeof(Blob[]));
        }


    }
}
