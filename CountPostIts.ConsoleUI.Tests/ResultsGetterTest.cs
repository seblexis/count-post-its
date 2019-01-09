using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;

namespace CountPostIts.ConsoleUI.Tests
{
    class ResultsGetterTest
    {
        private Mock<ICountByColorWrapper> _countByColorMock;

        [Test]
        public void Get_Returns_Result()
        {
            //Arrange
            _countByColorMock = new Mock<ICountByColorWrapper>();
            ResultsGetter resultsGetter = new ResultsGetter(_countByColorMock.Object);
            string filename = "filename.jpg";
            var resultMock = new Dictionary<string, int>()
            {
                {"Blue", 1}
            };
            _countByColorMock
                .Setup(m => m.OwnCountAllColours(filename))
                .Returns(resultMock);

            //Act
            var actual = resultsGetter.Get(filename);

            //Assert
            Assert.AreEqual(resultMock,actual);
        }
    }
}
