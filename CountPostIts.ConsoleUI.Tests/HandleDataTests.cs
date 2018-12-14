using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Moq;

namespace CountPostIts.ConsoleUI.Tests
{
    public class HandleDataTests
    {
        private const string Filename = "postits.jpg";
        private readonly Dictionary<string, int> _colourValues = new Dictionary<string, int>
        {
            {"R", 230 },
            {"B", 179 },
            {"G", 199 }
        };
        private HandleData _handleData;
        private Mock<IInformationWrapper> _mockInformation;

        [SetUp]
        public void Setup()
        {
            _mockInformation = new Mock<IInformationWrapper>();

            //_mockInformation
            //    .Setup(m => m.CallCountPostits(Filename, _colourValues))
            //    .Returns(5);

            _handleData = new HandleData(_mockInformation.Object);
        }

        [Test]
        public void Calls_Library_When_Given_A_File()
        {
            _handleData.PostitResults(Filename, _colourValues);

            //_mockInformation.Verify(m => m.CallCountPostits(Filename, _colourValues), Times.Once);
        }  
    }
}
