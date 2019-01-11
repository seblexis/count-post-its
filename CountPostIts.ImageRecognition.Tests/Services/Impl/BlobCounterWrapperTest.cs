using System.Drawing;
using CountPostIts.ImageRecognition.Services.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CountPostIts.ImageRecognition.Tests.Services.Impl
{
    [TestClass]
    public class BlobCounterWrapperTest
    {
        private BlobCounterWrapper _blobCounterWrapper;

        [TestInitialize]
        public void BeforeEachTest()
        {
            _blobCounterWrapper = new BlobCounterWrapper();
        }

        [TestMethod]
        public void CalculateMinDimensionReturns72ForImage1()
        {
            // Arrange
            Bitmap image = (Bitmap)Image.FromFile("../../TestImages/test1.jpg");
            int expected = 72;

            // Act
            int actual = _blobCounterWrapper.CalculateMinDimension(image);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateMinDimensionReturns54ForImage6()
        {
            // Arrange
            Bitmap image = (Bitmap)Image.FromFile("../../TestImages/test6.jpg");
            BlobCounterWrapper blobCounterWrapper = new BlobCounterWrapper();
            int expected = 54;

            // Act
            int actual = blobCounterWrapper.CalculateMinDimension(image);

            // Assert
            Assert.AreEqual(actual, expected);
        }
    }
}
