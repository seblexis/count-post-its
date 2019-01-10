using System;
using NUnit.Framework;
using Moq;

namespace CountPostIts.ConsoleUI.Tests
{
    public class ConfigTests
    {
        private Startup _config;
        private const string Filename = "postits.jpg";
        private const string IncorrectFilename = "Hello.ppt";

        private Mock<IFileWrapper> _mockFile;

        [SetUp]
        public void Setup()
        {
            _mockFile = new Mock<IFileWrapper>();

            _mockFile
                .Setup(m => m.CallFileExists(Filename))
                .Returns(true);

            _config = new Startup(_mockFile.Object);
        }

        [Test]
        public void ChecksFile_Is_Called_When_Given_Correct_Input()
        {
            // Act
            _config.VerifyFile(Filename);

            // Assert
            _mockFile.Verify(m => m.CallFileExists(Filename), Times.Once);
        }

        [Test]
        public void Throws_Exception_When_Given_Incorrect_File()
        { 
            // Act and Assert
            Assert.Throws<ArgumentException>(() => _config.VerifyFile(IncorrectFilename));
        }

        [Test]
        public void Returns_True_When_Given_Correct_File()
        {
            // Act 
            bool actual = _config.VerifyFile(Filename);

            // Assert
            Assert.IsTrue(actual);
        }

    }
}