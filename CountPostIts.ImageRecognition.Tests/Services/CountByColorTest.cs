using System.Collections.Generic;
using CountPostIts.ImageRecognition.Entities;
using CountPostIts.ImageRecognition.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace CountPostIts.ImageRecognition.Tests.Services
{
    [TestClass]
    public class CountByColorTest
    {
        private IPostItAnalysis _postItAnalysisMock;
        private IColorRanges _colorRangesMock;
        private IColorRange _colorRangeMock;


        [TestMethod]
        public void CountByColor()
        {
            // Arrange
            _postItAnalysisMock = Substitute.For<IPostItAnalysis>();
            _colorRangesMock = Substitute.For<IColorRanges>();
            _colorRangeMock = Substitute.For<IColorRange>();

            const string filenameMock = "filenameMock";
            const string colornameMock = "Blue";
            const int countMock = 1;
            var colorEntryMock = new Dictionary<Colors, IColorRange>
            {
                {Colors.Blue, _colorRangeMock}
            };

            _colorRangesMock.Rgb.Returns(colorEntryMock);
            _postItAnalysisMock.CountPostItNotes(filenameMock, _colorRangeMock, colornameMock).Returns(countMock);

            var expected = new Dictionary<string, int>
            {
                {colornameMock, countMock}
            };

            var countByColor = new CountByColor(_postItAnalysisMock, _colorRangesMock);

            // Act
            var actual = countByColor.CountAllColors(filenameMock);

            // Assert
            Assert.AreEqual(expected["Blue"],actual["Blue"]);
        }

    }
}
