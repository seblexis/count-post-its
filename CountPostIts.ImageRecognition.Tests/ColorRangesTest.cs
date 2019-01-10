using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace CountPostIts.ImageRecognition.Tests
{
    [TestClass]
    public class ColorRangesTest
    {
        private IColorRangeFactory _colorRangeFactoryMock;
        private IColorRange _colorRangeMock;
        private ColorRanges _colorRanges;

        [TestInitialize]
        public void BeforeEachTest()
        {
            _colorRangeFactoryMock = Substitute.For<IColorRangeFactory>();
            _colorRangeMock = Substitute.For<IColorRange>();
            _colorRangeMock.RangeRed.Returns(new[] { 1, 1 });
            _colorRangeMock.RangeBlue.Returns(new[] { 1, 1 });
            _colorRangeMock.RangeGreen.Returns(new[] { 1, 1 });
            _colorRangeFactoryMock.Create().Returns(_colorRangeMock);

            _colorRanges = new ColorRanges(_colorRangeFactoryMock);
        }

        [TestMethod]
        public void CreatesColorObject()
        {
            // Assert
            _colorRangeFactoryMock.Received().Create();
        }

        [TestMethod]
        public void ReturnsListWith6Colors()
        {
            // Arrange
            int expected = 6;

            // Act
            int actual = _colorRanges.Rgb.Count;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ReturnsListWithDictionariesWithColorRanges()
        {
            // Act
            var actual = _colorRanges.Rgb[Colors.Green];

            // Assert
            Assert.IsNotNull(actual.RangeRed);

        }

    }

}
