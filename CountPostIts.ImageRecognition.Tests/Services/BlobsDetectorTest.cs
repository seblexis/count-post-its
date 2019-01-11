using System.Drawing;
using Accord.Imaging;
using CountPostIts.ImageRecognition.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Image = System.Drawing.Image;

namespace CountPostIts.ImageRecognition.Tests.Services
{
    [TestClass]
    public class BlobsDetectorTest
    {
        private IBlobCounterWrapper _blobCounterWrapperMock;
        private BlobsDetector _blobsDetector;
        private Bitmap _image;

        [TestInitialize]
        public void BeforeEachTest()
        {
            _blobCounterWrapperMock = Substitute.For<IBlobCounterWrapper>();
            _blobsDetector = new BlobsDetector(_blobCounterWrapperMock);
            _image = (Bitmap) Image.FromFile("../../TestImages/test1.jpg");
        }

        [TestMethod]
        public void FindBlobsCallsBlobCounterWrapperMethods()
        {
            // Act
            _blobsDetector.FindBlobs(_image);

            // Assert    
            _blobCounterWrapperMock.Received().CalculateMinDimension(_image);
            _blobCounterWrapperMock.Received().OwnFilterBlobs(true);
            _blobCounterWrapperMock.ReceivedWithAnyArgs().OwnMinHeight(1);
            _blobCounterWrapperMock.ReceivedWithAnyArgs().OwnMinWidth(1);
            _blobCounterWrapperMock.Received().OwnProcessImage(_image);
        }

        [TestMethod]
        public void FindBlobsReturnsListOfBlobs()
        {
            // Arrange
            var expected = typeof(Blob[]);

            // Act
            var actual = _blobsDetector.FindBlobs(_image);

            // Assert
            Assert.IsInstanceOfType(actual, expected);
        }
    }
}