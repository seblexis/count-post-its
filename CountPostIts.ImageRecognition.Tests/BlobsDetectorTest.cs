using System.Drawing;
using Accord.Imaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Image = System.Drawing.Image;

namespace CountPostIts.ImageRecognition.Tests
{
    [TestClass]
    public class BlobsDetectorTest
    {
        private BlobsDetector _blobsDetector;
        private IBlobCounterWrapper _blobCounterWrapperMock;
        private Bitmap _image;

        [TestInitialize]
        public void BeforeEachTest()
        {
            _blobCounterWrapperMock = Substitute.For<IBlobCounterWrapper>();
            _blobsDetector = new BlobsDetector(_blobCounterWrapperMock);
            _image = (Bitmap)Image.FromFile("../../TestImages/test1.jpg");
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

            Assert.IsInstanceOfType(actual, expected);
        }
    }
}
