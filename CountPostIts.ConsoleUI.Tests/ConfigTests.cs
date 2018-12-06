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
        private const string IncorrectFilename = "Hello.ppt";
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
        public void Calls_Library_When_Given_Correct_File()
        {
            _config.ChecksFile(Filename);
            
        }

        [Test]
        public void Throws_Exception_When_Given_Incorrect_File()
        { 
            Assert.Throws<ArgumentNullException>(() => _config.ChecksFile(IncorrectFilename));
        }
    }
}