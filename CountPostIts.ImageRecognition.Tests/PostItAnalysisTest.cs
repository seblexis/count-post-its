using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace CountPostIts.ImageRecognition.Tests
{
    [TestClass]
    public class PostItAnalysisTest
    {
        private PostItAnalysis _postItAnalysis;
        private IColorRange _yellowRgbRanges = new ColorRange();
        private IBlobCounterWrapper _blobCounterWrapperMock;
        private ISimpleShapeCheckerWrapper _simpleShapeCheckerWrapperMock;
        private IColorFilteringWrapper _colorFilteringWrapperMock;
        private IColorRangeFactory _colorRangeFactoryMock;


        [TestInitialize]
        public void BeforeEachTest()
        {
            _blobCounterWrapperMock = Substitute.For<BlobCounterWrapper>();
            _simpleShapeCheckerWrapperMock = Substitute.For<SimpleShapeCheckerWrapper>();
            _colorFilteringWrapperMock = Substitute.For<ColorFilteringWrapper>();
            _colorRangeFactoryMock = Substitute.For<IColorRangeFactory>();
            _postItAnalysis = new PostItAnalysis(_blobCounterWrapperMock, _simpleShapeCheckerWrapperMock, _colorFilteringWrapperMock);
            ColorRanges colorRanges = new ColorRanges(_colorRangeFactoryMock);
            _yellowRgbRanges = colorRanges.Rgb[Colors.Yellow];
        }

        [TestMethod]
        public void CountPostItNotesSavesImage()
        {
            // Arrange
            const string resultPath = "result_Yellow.jpg";
            if (File.Exists(resultPath))
            {
                File.Delete(resultPath);
            }

            // Act
            _postItAnalysis.CountPostItNotes("../../TestImages/test4.jpg", _yellowRgbRanges, "Yellow");

            // Assert
            Assert.IsTrue(File.Exists(resultPath));
        }

    }
}
