using System;
using System.IO;
using CountPostIts.ImageRecognition.Entities;
using CountPostIts.ImageRecognition.Entities.Impl;
using CountPostIts.ImageRecognition.Services;
using CountPostIts.ImageRecognition.Services.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace CountPostIts.ImageRecognition.Tests.Services
{
    [TestClass]
    public class PostItAnalysisTest
    {
        private IBlobCounterWrapper _blobCounterWrapperMock;
        private IColorFilteringWrapper _colorFilteringWrapperMock;
        private IColorRangeFactory _colorRangeFactoryMock;
        private PostItAnalysis _postItAnalysis;
        private ISimpleShapeCheckerWrapper _simpleShapeCheckerWrapperMock;
        private IColorRange _yellowRgbRanges = new ColorRange();


        [TestInitialize]
        public void BeforeEachTest()
        {
            _blobCounterWrapperMock = Substitute.For<BlobCounterWrapper>();
            _simpleShapeCheckerWrapperMock = Substitute.For<SimpleShapeCheckerWrapper>();
            _colorFilteringWrapperMock = Substitute.For<ColorFilteringWrapper>();
            _colorRangeFactoryMock = Substitute.For<IColorRangeFactory>();
            _postItAnalysis = new PostItAnalysis(_blobCounterWrapperMock, _simpleShapeCheckerWrapperMock,
                _colorFilteringWrapperMock);
            var colorRanges = new ColorRanges(_colorRangeFactoryMock);
            _yellowRgbRanges = colorRanges.Rgb[Colors.Yellow];
        }

        [TestMethod]
        public void CountPostItNotesSavesImage()
        {
            // Arrange
            var expectedPathToSaveTo = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.Parent.FullName +
                                       $"\\images\\result_Yellow.jpg";

            Console.WriteLine(File.Exists(expectedPathToSaveTo));
            if (File.Exists(expectedPathToSaveTo)) File.Delete(expectedPathToSaveTo);

            // Act
            _postItAnalysis.CountPostItNotes("../../TestImages/test4.jpg", _yellowRgbRanges, "Yellow");

            // Assert
            Assert.IsTrue(File.Exists(expectedPathToSaveTo));
        }
    }
}