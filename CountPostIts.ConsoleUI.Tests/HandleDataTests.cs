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
        private readonly Dictionary<string, int> result = new Dictionary<string, int>
        {
            {"Purple", 4 }
        };
        
        private HandleData _handleData;
        private Mock<IInformationWrapper> _mockInformation;

        [SetUp]
        public void Setup()
        {

            _mockInformation = new Mock<IInformationWrapper>();

            _mockInformation
                .Setup(m => m.CallCountAllColours(Filename))
                .Returns(result);


            _handleData = new HandleData(_mockInformation.Object);
        }

        [Test]
        public void Calls_Library_When_Given_A_File()
        {
            _handleData.PostitResults(Filename);

            _mockInformation.Verify(m => m.CallCountAllColours(Filename), Times.Once);
        }  
    }
}
