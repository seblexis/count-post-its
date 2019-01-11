using System;
using CountPostIts.ConsoleUI.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace CountPostIts.ConsoleUI.Tests.Services
{
    [TestClass]
    public class StartupTests
    {
        private const string Filename = "postits.jpg";
        private const string IncorrectFilename = "Hello.ppt";
        private IFileWrapper _mockFileWrapper;
        private Startup _startup;

        [TestInitialize]
        public void BeforeEachTest()
        {
            _mockFileWrapper = Substitute.For<IFileWrapper>();
            _mockFileWrapper.CallFileExists(Filename).Returns(true);

            _startup = new Startup(_mockFileWrapper);
        }

        [TestMethod]
        public void ChecksFileIsCalledWhenGivenCorrectInput()
        {
            // Act
            _startup.VerifyFile(Filename);

            // Assert
            _mockFileWrapper.Received().CallFileExists(Filename);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowsExceptionWhenGivenIncorrectFile()
        {
            // Act and Assert
            _startup.VerifyFile(IncorrectFilename);
        }

        [TestMethod]
        public void ReturnsTrueWhenGivenCorrectFile()
        {
            // Act 
            var actual = _startup.VerifyFile(Filename);

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void GetPathInProjectReturnsCorrectPath()
        {
            // Arrange
            var expected = "count-post-its\\images\\" + Filename;

            // Act
            var actual = _startup.GetPathInProject(Filename);

            // Assert
            StringAssert.EndsWith(actual, expected);
        }
    }
}