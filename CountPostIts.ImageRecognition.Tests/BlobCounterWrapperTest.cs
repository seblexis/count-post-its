using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CountPostIts.ImageRecognition.Tests
{
    [TestClass]
    public class BlobCounterWrapperTest
    {
        private BlobCounterWrapper blobCounterWrapper;

        [TestInitialize]
        public void BeforeEachTest()
        {
            blobCounterWrapper = new BlobCounterWrapper();
        }

        [TestMethod]
        public void CalculateMinDimensionReturns36ForImage1()
        {
            Bitmap image = (Bitmap)Bitmap.FromFile("../../TestImages/test1.jpg");
            

            int result = blobCounterWrapper.CalculateMinDimension(image);
            Assert.AreEqual(36, result);
        }

        [TestMethod]
        public void CalculateMinDimensionReturns27ForImage6()
        {
            Bitmap image = (Bitmap)Bitmap.FromFile("../../TestImages/test6.jpg");
            BlobCounterWrapper blobCounterWrapper = new BlobCounterWrapper();

            int result = blobCounterWrapper.CalculateMinDimension(image);
            Assert.AreEqual(27, result);
        }
    }
}
