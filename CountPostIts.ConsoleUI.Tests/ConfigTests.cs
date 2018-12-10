using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using Moq;

namespace CountPostIts.ConsoleUI.Tests
{
    public class ConfigTests
    {
        private Config _config;
        private const string Filename = "postits.jpg";
        private const string IncorrectFilename = "Hello.ppt";
        private const string FilenameNoPostits = "None.jpg";
        private readonly Dictionary<string, int> _colourValues = new Dictionary<string, int>
        {
            {"R", 230 },
            {"B", 179 },
            {"G", 199 }
        };
        private Mock<IFileWrapper> _mockFile;
        private Mock<IHandleData> _mockHandleData;

        [SetUp]
        public void Setup()
        {
            _mockFile = new Mock<IFileWrapper>();
            _mockHandleData = new Mock<IHandleData>();

            _mockFile
                .Setup(m => m.CallFileExists(Filename))
                .Returns(true);

            _config = new Config(_mockFile.Object, _mockHandleData.Object);
        }

        [Test]
        public void ChecksFile_Is_Called_When_Given_Correct_Input()
        {
            _config.ChecksFile(Filename, _colourValues);

            _mockFile.Verify(m => m.CallFileExists(Filename), Times.Once);
        }

        [Test]
        public void Throws_Exception_When_Given_Incorrect_File()
        { 
            Assert.Throws<ArgumentException>(() => _config.ChecksFile(IncorrectFilename, _colourValues));
        }

        [Test]
        public void Calls_PostitResults_When_Given_Correct_File()
        {
            _config.ChecksFile(Filename, _colourValues);

            _mockHandleData.Verify(m => m.PostitResults(Filename, _colourValues), Times.Once);
        }
    }
}