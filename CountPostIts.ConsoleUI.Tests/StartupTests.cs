using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace CountPostIts.ConsoleUI.MSTests
{
    [TestClass]
    public class StartupTests
    {
        private Startup _startup;
        private const string Filename = "postits.jpg";
        private const string IncorrectFilename = "Hello.ppt";
        private IFileWrapper _mockFileWrapper;

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
            bool actual = _startup.VerifyFile(Filename);

            // Assert
            Assert.IsTrue(actual);
        }
    }
}
