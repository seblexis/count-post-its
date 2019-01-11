using System.Collections.Generic;
using CountPostIts.ConsoleUI.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace CountPostIts.ConsoleUI.Tests.Services
{
    [TestClass]
    public class ResultsGetterTest
    {
        private ICountByColorWrapper _mockCoutByColorWrapper;

        [TestMethod]
        public void GetReturnsDictionary()
        {
            //Arrange
            _mockCoutByColorWrapper = Substitute.For<ICountByColorWrapper>();
            ResultsGetter resultsGetter = new ResultsGetter(_mockCoutByColorWrapper);
            string filename = "filename.jpg";
            var expected = new Dictionary<string, int>();
            _mockCoutByColorWrapper.OwnCountAllColors(filename).Returns(expected);

            //Act
            var actual = resultsGetter.Get(filename);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
