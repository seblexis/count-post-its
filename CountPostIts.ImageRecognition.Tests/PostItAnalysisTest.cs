using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace CountPostIts.ImageRecognition.Tests
{
    [TestClass]
    public class PostItAnalysisTest
    {
        PostItAnalysis postItAnalysis;
        IColorRange yellowRGBRanges = new ColorRange();
        IBlobCounterWrapper blobCounterWrapperMock;
        ISimpleShapeCheckerWrapper simpleShapeCheckerWrapperMock;
        IColorFilteringWrapper colorFilteringWrapperMock;
        IColorRangeFactory _colorRangeFactoryMock;


        [TestInitialize()]
        public void BeforeEachTest()
        {
            blobCounterWrapperMock = Substitute.For<BlobCounterWrapper>();
            simpleShapeCheckerWrapperMock = Substitute.For<SimpleShapeCheckerWrapper>();
            colorFilteringWrapperMock = Substitute.For<ColorFilteringWrapper>();
            _colorRangeFactoryMock = Substitute.For<IColorRangeFactory>();
            postItAnalysis = new PostItAnalysis(blobCounterWrapperMock, simpleShapeCheckerWrapperMock, colorFilteringWrapperMock);
            ColorRanges colorRanges = new ColorRanges(_colorRangeFactoryMock);
            yellowRGBRanges = colorRanges.RGB[Colors.Yellow];
        }

        [TestMethod]
        public void CountPostItNotesSavesImage()
        {
            string resultPath = "result_Yellow.jpg";
            if (File.Exists(resultPath))
            {
                File.Delete(resultPath);
            }
            postItAnalysis.CountPostItNotes("../../TestImages/test4.jpg", yellowRGBRanges, "Yellow");
            Assert.AreEqual(true, File.Exists(resultPath));
        }

    }
}
