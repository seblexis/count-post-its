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
        private const string FilenameNoPostits = "None.jpg";
        private Mock<IFileWrapper> _mockFile;
        private Mock<IInformationWrapper> _mockInformation;

        [SetUp]
        public void Setup()
        {
            _mockFile = new Mock<IFileWrapper>();
            _mockInformation = new Mock<IInformationWrapper>();

            _mockFile
                .Setup(m => m.CallFileExists(Filename))
                .Returns(true);

            _mockInformation
                .Setup(m => m.CountPostits(Filename))
                .Returns(5);

            _mockInformation
                .Setup(m => m.HasPostits(Filename))
                .Returns(true);

            _mockInformation
                .Setup(m => m.HasPostits(FilenameNoPostits))
                .Returns(false);

            _config = new Config(_mockFile.Object, _mockInformation.Object);
        }

        [Test]
        public void ChecksFile_Is_Called_When_Given_Correct_Input()
        {
            _config.ChecksFile(Filename);

            _mockFile.Verify(m => m.CallFileExists(Filename), Times.Once);
        }

        [Test]
        public void Calls_Library_When_Given_Correct_File()
        {
            _config.ChecksFile(Filename);

            _mockInformation.Verify(m => m.CountPostits(Filename), Times.Once);

            
        }

        [Test]
        public void Throws_Exception_When_Given_Incorrect_File()
        { 
            Assert.Throws<ArgumentException>(() => _config.ChecksFile(IncorrectFilename));
        }
    }
}