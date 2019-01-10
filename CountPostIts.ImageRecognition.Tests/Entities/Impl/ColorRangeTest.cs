using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CountPostIts.ImageRecognition.Tests
{
    [TestClass]
    public class ColorRangeTest
    {
        private ColorRange _testColor;

        [TestInitialize]
        public void BeforeEachTest()
        {
            _testColor = new ColorRange();
        }

        [TestMethod]
        public void SetsColorRange()
        {         
            // Arrange
            int[] expected = { 100, 120 };
            _testColor.RangeBlue = new[] { 100, 120 };

            // Act
            int[] actual = _testColor.RangeBlue;

            // Assert
            CollectionAssert.AreEqual(expected, actual);            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DoesNotAcceptValuesBelow0()
        {
            // Act
            _testColor.RangeBlue = new[] { -10, 100 };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DoesNotAcceptValuesAbove255()
        {
            // Act
            _testColor.RangeBlue = new[] { 0, 300 };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DoesNotAcceptValuesInWrongOrder()
        {
            // Act
            _testColor.RangeBlue = new[] { 200, 100 };
        }

    }
}
