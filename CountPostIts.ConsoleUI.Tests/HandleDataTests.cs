using System.Collections.Generic;
using NUnit.Framework;
using Moq;

namespace CountPostIts.ConsoleUI.Tests
{
    public class HandleDataTests
    {
        private const string Filename = "postits.jpg";
        private const string IncorrectFilename = "Hello.ppt";
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
                .Setup(m => m.OwnCountAllColours(Filename))
                .Returns(result);

            _handleData = new HandleData(_mockInformation.Object);
        }

        [Test]
        public void Calls_Library_When_Given_A_File()
        {
            _handleData.PostItResults(Filename);

            _mockInformation.Verify(m => m.OwnCountAllColours(Filename), Times.Once);
        }
    }
}
