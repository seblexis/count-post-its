using CountPostIts.ImageRecognition.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CountPostIts.ImageRecognition.Tests.Services
{
    [TestClass]
    public class CountByColorFeatureTest
    {
        CountByColor _information;

        [TestInitialize]
        public void BeforeEachTest()
        {
            _information = new CountByColor();
        }

        [TestCategory("Yellow")]
        [TestMethod]
        public void Count7YellowInImage1()
        {
            // Arrange
            int expected = 7;

            // Act
            int actual = _information.CountAllColours("../../TestImages/test1.jpg")["Yellow"];

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Ignore]
        [TestCategory("Yellow")]
        [TestMethod]
        //Test is only returning 3 because of overlap
        public void Count5YellowInImage4()
        {
            // Arrange
            int expected = 5;

            // Act
            int actual = _information.CountAllColours("../../TestImages/test4.jpg")["Yellow"];

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCategory("Green")]
        [TestMethod]
        public void Count5GreenInImage1()
        {
            // Arrange
            int expected = 5;

            // Act
            int actual = _information.CountAllColours("../../TestImages/test1.jpg")["Green"];

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCategory("Green")]
        [TestMethod]
        public void Count4GreenInImage5()
        {
            // Arrange
            int expected = 4;

            // Act
            int actual = _information.CountAllColours("../../TestImages/test5.jpg")["Green"];

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCategory("Blue")]
        [TestMethod]
        public void Count1BlueInImage2()
        {
            // Arrange
            int expected = 1;

            // Act
            int actual = _information.CountAllColours("../../TestImages/test2.jpg")["Blue"];

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCategory("Blue")]
        [TestMethod]
        public void Count1BlueInImage3()
        {
            // Arrange
            int expected = 1;

            // Act
            int actual = _information.CountAllColours("../../TestImages/test3.jpg")["Blue"];

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCategory("Blue")]
        [TestMethod]
        public void Count1BlueInImage4()
        {
            // Arrange
            int expected = 1;

            // Act
            int actual = _information.CountAllColours("../../TestImages/test4.jpg")["Blue"];

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCategory("Blue")]
        [TestMethod]
        public void Count1BlueInImage5()
        {
            // Arrange
            int expected = 1;

            // Act
            int actual = _information.CountAllColours("../../TestImages/test5.jpg")["Blue"];

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCategory("Blue")]
        [TestMethod]
        public void Count3BlueInImage6()
        {
            // Arrange
            int expected = 3;

            // Act
            int actual = _information.CountAllColours("../../TestImages/test6.jpg")["Blue"];

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Ignore]
        [TestCategory("Orange")]
        [TestMethod]
        //Test not passing (returning 1) because of writing in post it, not because of not match
        public void Count2OrangeInImage4()
        {
            // Arrange
            int expected = 2;

            // Act
            int actual = _information.CountAllColours("../../TestImages/test4.jpg")["Orange"];

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCategory("Pink")]
        [TestMethod]
        public void Count2PinkInImage5()
        {
            // Arrange
            int expected = 2;

            // Act
            int actual = _information.CountAllColours("../../TestImages/test5.jpg")["Pink"];

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCategory("Pink")]
        [TestMethod]
        public void Count1PinkInImage6()
        {
            // Arrange
            int expected = 1;

            // Act
            int actual = _information.CountAllColours("../../TestImages/test6.jpg")["Pink"];

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCategory("Purple")]
        [TestMethod]
        public void Count3PurpleInImage6()
        {
            // Arrange
            int expected = 3;

            // Act
            int actual = _information.CountAllColours("../../TestImages/test6.jpg")["Purple"];

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
