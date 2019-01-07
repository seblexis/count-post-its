using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace CountPostIts.ImageRecognition.Tests
{
    [TestClass]
    public class ColourRangesTest
    {
        IColourRangeFactory colourRangeFactoryMock;
        IColourRange colourRangeMock;
        ColourRanges colourRanges;

        [TestInitialize]
        public void BeforeEachTest()
        {
            colourRangeFactoryMock = Substitute.For<IColourRangeFactory>();
            colourRangeMock = Substitute.For<IColourRange>();
            colourRangeMock.RangeRed.Returns(new int[] { 1, 1 });
            colourRangeMock.RangeBlue.Returns(new int[] { 1, 1 });
            colourRangeMock.RangeGreen.Returns(new int[] { 1, 1 });
            colourRangeFactoryMock.Create().Returns(colourRangeMock);

            colourRanges = new ColourRanges(colourRangeFactoryMock);
        }

        [TestMethod]
        public void CreatesColourObject()
        {
            colourRangeFactoryMock.Received().Create();
        }

        [TestMethod]
        public void ReturnsListWith6Colours()
        {

            Assert.AreEqual(6, colourRanges.RGB.Count);
        }

        [TestMethod]
        public void ReturnsListWithDictionariesWithColourRanges()
        {
            var actual = colourRanges.RGB[Colours.Green];
            Assert.IsNotNull(actual.RangeRed);

        }

    }

}
