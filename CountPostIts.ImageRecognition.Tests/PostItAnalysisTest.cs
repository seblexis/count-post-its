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
        IColourRange yellowRGBRanges = new ColorRange();
        IBlobCounterWrapper blobCounterWrapperMock;
        ISimpleShapeCheckerWrapper simpleShapeCheckerWrapperMock;
        IColorFilteringWrapper colorFilteringWrapperMock;
        IColourRangeFactory colourRangeFactoryMock;


        [TestInitialize()]
        public void BeforeEachTest()
        {
            blobCounterWrapperMock = Substitute.For<BlobCounterWrapper>();
            simpleShapeCheckerWrapperMock = Substitute.For<SimpleShapeCheckerWrapper>();
            colorFilteringWrapperMock = Substitute.For<ColorFilteringWrapper>();
            colourRangeFactoryMock = Substitute.For<IColourRangeFactory>();
            postItAnalysis = new PostItAnalysis(blobCounterWrapperMock, simpleShapeCheckerWrapperMock, colorFilteringWrapperMock);
            ColourRanges colourRanges = new ColourRanges(colourRangeFactoryMock);
            yellowRGBRanges = colourRanges.RGB[Colours.Yellow];
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
