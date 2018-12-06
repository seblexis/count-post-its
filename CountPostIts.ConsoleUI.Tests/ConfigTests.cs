using System;
using System.IO;
using NUnit.Framework;
using Moq;

namespace CountPostIts.ConsoleUI.Tests
{
    public class Tests
    {
        private Config _config;
        private const string Filename = "postits.jpg";
        private Mock<IFileWrapper> _mockFile;

        [SetUp]
        public void Setup()
        {
            _mockFile = new Mock<IFileWrapper>();

            _mockFile
                .Setup(m => m.FileExists(Filename))
                .Returns(true);

            _config = new Config(_mockFile.Object);
        }

        [Test]
        public void ChecksFile_Is_Called_When_Given_Correct_Input()
        {
            _config.ChecksFile(Filename);

            _mockFile.Verify(m => m.FileExists(Filename), Times.Once);
        }

        [Test]
        public void HasNotBeenParsed_Is_Called_When_Given_Incorrect_Input()
        {

        }
    }
}