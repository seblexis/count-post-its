using System.Collections.Generic;
using CountPostIts.ImageRecognition.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CountPostIts.ImageRecognition.Tests.Services
{
    [TestClass]
    public class CountByColorFeatureTest
    {
        private const string FilePath = "../../TestImages/";
        private CountByColor _information;

        [TestInitialize]
        public void BeforeEachTest()
        {
            _information = new CountByColor();
        }
        
        [TestMethod]
        public void Test1ReturnsCorrectResults()
        {
            var expected = new Dictionary<string, int>
            {
                {"Yellow", 7},
                {"Green", 5}
            };

            var actual = _information.CountAllColours($"{FilePath}test1.jpg");

            foreach (var colour in expected)
            {
                Assert.AreEqual(colour.Value, actual[colour.Key]);
            }
        }

        [TestMethod]
        public void Test2ReturnsCorrectResults()
        {
            var expected = new Dictionary<string, int>
            {
                {"Blue", 1}
            };
            
            var actual = _information.CountAllColours($"{FilePath}test2.jpg");

            foreach (var colour in expected)
            {
                Assert.AreEqual(colour.Value, actual[colour.Key]);
            }
        }

        [TestMethod]
        public void Test3ReturnsCorrectResults()
        {
            var expected = new Dictionary<string, int>
            {
                {"Blue", 1}
            };

            var actual = _information.CountAllColours($"{FilePath}test3.jpg");

            foreach (var colour in expected)
            {
                Assert.AreEqual(colour.Value, actual[colour.Key]);
            }
        }

        [TestMethod]
        public void Test4ReturnsCorrectResults()
        {
            var expected = new Dictionary<string, int>
            {
                {"Blue", 1},
                {"Orange", 2}
            };

            var actual = _information.CountAllColours($"{FilePath}test4.jpg");

            foreach (var colour in expected)
            {
                Assert.AreEqual(colour.Value, actual[colour.Key]);
            }
        }

        [TestMethod]
        public void Test5ReturnsCorrectResults()
        {
            var expected = new Dictionary<string, int>
            {
                {"Blue", 1},
                {"Green", 4},
                {"Pink", 2}
            };
            
            var actual = _information.CountAllColours($"{FilePath}test5.jpg");

            foreach (var colour in expected)
            {
                Assert.AreEqual(colour.Value, actual[colour.Key]);
            }
        }

        [TestMethod]
        public void Test6ReturnsCorrectResults()
        {
            var expected = new Dictionary<string, int>
            {
                {"Blue", 3},
                {"Pink", 1},
                {"Purple", 3}
            };

            var actual = _information.CountAllColours($"{FilePath}test6.jpg");

            foreach (var colour in expected)
            {
                Assert.AreEqual(colour.Value, actual[colour.Key]);
            }
        }
    }
}