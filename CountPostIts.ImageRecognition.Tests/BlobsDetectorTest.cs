using System;
using System.Drawing;
using Accord.Imaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace CountPostIts.ImageRecognition.Tests
{
    [TestClass]
    public class BlobsDetectorTest
    {
        BlobsDetector blobsDetector;
        IBlobCounterWrapper BlobCounterWrapperMock;
        Bitmap image;

        [TestInitialize]
        public void BeforeEachTest()
        {
            BlobCounterWrapperMock = Substitute.For<IBlobCounterWrapper>();
            blobsDetector = new BlobsDetector(BlobCounterWrapperMock);
            image = (Bitmap)Bitmap.FromFile("../../TestImages/test1.jpg");
        }

        [TestMethod]
        public void findBlobsCallsBlobCounterWrapperMethods()
        {
            blobsDetector.FindBlobs(image);

            BlobCounterWrapperMock.Received().CalculateMinDimension(image);
            BlobCounterWrapperMock.Received().OwnFilterBlobs(true);
            BlobCounterWrapperMock.ReceivedWithAnyArgs().OwnMinHeight(1);
            BlobCounterWrapperMock.ReceivedWithAnyArgs().OwnMinWidth(1);
            BlobCounterWrapperMock.Received().OwnProcessImage(image);
        }

        [TestMethod]
        public void findBlobsReturnsListOfBlobs()
        {
            var result = blobsDetector.FindBlobs(image);

            Assert.IsInstanceOfType(result, typeof(Blob[]));
        }
    }
}
