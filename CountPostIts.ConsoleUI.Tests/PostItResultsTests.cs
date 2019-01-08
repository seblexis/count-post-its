using System.Collections.Generic;
using NUnit.Framework;
using Moq;

namespace CountPostIts.ConsoleUI.Tests
{
    public class HandleDataTests
    {
        private const string Filename = "postits.jpg";
        private readonly Dictionary<string, int> _result = new Dictionary<string, int>
        {
            {"Purple", 4 }
        };
        
        private PostItResults _handleData;
        private Mock<ICountByColorWrapper> _mockInformation;

        [SetUp]
        public void Setup()
        {
            _mockInformation = new Mock<ICountByColorWrapper>();

            _mockInformation
                .Setup(m => m.OwnCountAllColours(Filename))
                .Returns(_result);

            _handleData = new PostItResults(_mockInformation.Object);
        }

        [Test]
        public void Calls_Library_When_Given_A_File()
        {
            _handleData.DisplayResults(Filename);

            _mockInformation.Verify(m => m.OwnCountAllColours(Filename), Times.Once);
        }
    }
}
