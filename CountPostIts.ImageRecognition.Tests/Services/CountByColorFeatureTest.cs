using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CountPostIts.ImageRecognition.Tests.Services
{
    [TestClass]
    public class CountByColorFeatureTest
    {
        private CountByColor _information;
        private const string FilePath = "../../TestImages/";

        [TestInitialize]
        public void BeforeEachTest()
        {
            _information = new CountByColor();
        }

        [DataTestMethod]
        [DataRow("test1.jpg", "Yellow", 7)]
        [DataRow("test1.jpg", "Green", 5)]
        [DataRow("test5.jpg", "Green", 4)]
        [DataRow("test2.jpg", "Blue", 1)]
        [DataRow("test3.jpg", "Blue", 1)]
        [DataRow("test4.jpg", "Blue", 1)]
        [DataRow("test4.jpg", "Orange", 2)]
        [DataRow("test5.jpg", "Blue", 1)]
        [DataRow("test6.jpg", "Blue", 3)]
        [DataRow("test5.jpg", "Pink", 2)]
        [DataRow("test6.jpg", "Pink", 1)]
        [DataRow("test6.jpg", "Purple", 3)]
        public void CountPostItsInGivenImage(string filename, string colour, int expected)
        {
            // Act
            int actual = _information.CountAllColours($"{FilePath}{filename}")[colour];

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
