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
        private HandleData _handleData;
        private Mock<IInformationWrapper> _mockInformation;

        [SetUp]
        public void Setup()
        {
            _mockInformation = new Mock<IInformationWrapper>();

            _mockInformation
                .Setup(m => m.CallCountPostits(Filename))
                .Returns(5);

            _handleData = new HandleData(_mockInformation.Object);
        }

        [Test]
        public void Calls_Library_When_Given_A_File()
        {
            _handleData.PostitResults(Filename);

            _mockInformation.Verify(m => m.CallCountPostits(Filename), Times.Once);
        }  
    }
}
