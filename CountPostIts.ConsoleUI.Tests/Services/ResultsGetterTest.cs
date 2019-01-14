using System.Collections.Generic;
using CountPostIts.ConsoleUI.Services;
using CountPostIts.ImageRecognition.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace CountPostIts.ConsoleUI.Tests.Services
{
    [TestClass]
    public class ResultsGetterTest
    {
        private ICountByColor _mockCountByColor;

        [TestMethod]
        public void GetReturnsDictionary()
        {
            //Arrange
            _mockCountByColor = Substitute.For<ICountByColor>();
            var resultsGetter = new ResultsGetter(_mockCountByColor);
            var filename = "filename.jpg";
            var expected = new Dictionary<string, int>();
            _mockCountByColor.CountAllColors(filename).Returns(expected);

            //Act
            var actual = resultsGetter.Get(filename);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}