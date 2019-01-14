using System.Collections.Generic;
using CountPostIts.ImageRecognition.Services;
using CountPostIts.ImageRecognition.Services.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CountPostIts.ImageRecognition.Tests.Services
{
    [TestClass]
    public class CountByColorFeatureTest
    {
        private const string FilePath = "../../TestImages/";
        private CountByColor _countByColor;

        [TestInitialize]
        public void BeforeEachTest()
        {
            IBlobCounterWrapper blobCounterWrapper = new BlobCounterWrapper();
            ISimpleShapeCheckerWrapper simpleShapeCheckerWrapper = new SimpleShapeCheckerWrapper();
            IColorFilteringWrapper colorFilteringWrapper = new ColorFilteringWrapper();
            IPostItAnalysis postItAnalysis = new PostItAnalysis(blobCounterWrapper, simpleShapeCheckerWrapper, colorFilteringWrapper);
            _countByColor = new CountByColor(postItAnalysis);
        }
        
        [TestMethod]
        public void Test1ReturnsCorrectResults()
        {
            var expected = new Dictionary<string, int>
            {
                {"Yellow", 7},
                {"Green", 5}
            };

            var actual = _countByColor.CountAllColors($"{FilePath}test1.jpg");

            foreach (var color in expected)
            {
                Assert.AreEqual(color.Value, actual[color.Key]);
            }
        }

        [TestMethod]
        public void Test2ReturnsCorrectResults()
        {
            var expected = new Dictionary<string, int>
            {
                {"Blue", 1}
            };
            
            var actual = _countByColor.CountAllColors($"{FilePath}test2.jpg");

            foreach (var color in expected)
            {
                Assert.AreEqual(color.Value, actual[color.Key]);
            }
        }

        [TestMethod]
        public void Test3ReturnsCorrectResults()
        {
            var expected = new Dictionary<string, int>
            {
                {"Blue", 1}
            };

            var actual = _countByColor.CountAllColors($"{FilePath}test3.jpg");

            foreach (var color in expected)
            {
                Assert.AreEqual(color.Value, actual[color.Key]);
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

            var actual = _countByColor.CountAllColors($"{FilePath}test4.jpg");

            foreach (var color in expected)
            {
                Assert.AreEqual(color.Value, actual[color.Key]);
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
            
            var actual = _countByColor.CountAllColors($"{FilePath}test5.jpg");

            foreach (var color in expected)
            {
                Assert.AreEqual(color.Value, actual[color.Key]);
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

            var actual = _countByColor.CountAllColors($"{FilePath}test6.jpg");

            foreach (var color in expected)
            {
                Assert.AreEqual(color.Value, actual[color.Key]);
            }
        }
    }
}