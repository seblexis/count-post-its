using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace CountPostIts.ImageRecognition.Tests
{
    [TestClass]
    public class ColorRangesTest
    {
        IColorRangeFactory _colorRangeFactoryMock;
        IColorRange _colorRangeMock;
        ColorRanges _colorRanges;

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
            _colorRangeFactoryMock.Received().Create();
        }

        [TestMethod]
        public void ReturnsListWith6Colors()
        {

            Assert.AreEqual(6, _colorRanges.Rgb.Count);
        }

        [TestMethod]
        public void ReturnsListWithDictionariesWithColorRanges()
        {
            var actual = _colorRanges.Rgb[Colors.Green];
            Assert.IsNotNull(actual.RangeRed);

        }

    }

}
