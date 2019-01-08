using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CountPostIts.ImageRecognition.Tests
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
        public void CalculateMinDimensionReturns36ForImage1()
        {
            Bitmap image = (Bitmap)Image.FromFile("../../TestImages/test1.jpg");

            int result = _blobCounterWrapper.CalculateMinDimension(image);
            Assert.AreEqual(72, result);
        }

        [TestMethod]
        public void CalculateMinDimensionReturns27ForImage6()
        {
            Bitmap image = (Bitmap)Image.FromFile("../../TestImages/test6.jpg");
            BlobCounterWrapper blobCounterWrapper = new BlobCounterWrapper();

            int result = blobCounterWrapper.CalculateMinDimension(image);
            Assert.AreEqual(54, result);
        }
    }
}
