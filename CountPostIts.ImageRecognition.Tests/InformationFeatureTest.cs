using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountPostIts.ImageRecognition.Tests
{
    [TestClass]
    public class InformationFeatureTest
    {

        IBlobCounterWrapper blobCounterWrapper;
        ISimpleShapeCheckerWrapper simpleShapeCheckerWrapper;
        IColorFilteringWrapper colorFilteringWrapper;
        Information information;

        [TestInitialize()]
        public void BeforeEachTest()
        {
            blobCounterWrapper = new BlobCounterWrapper();
            simpleShapeCheckerWrapper = new SimpleShapeCheckerWrapper();
            colorFilteringWrapper = new ColorFilteringWrapper();
            information = new Information();
        }

        [TestCategory("Yellow")]
        [TestMethod]
        public void Count7inImage4()
        {
            Assert.AreEqual(7, information.CountAllColours("../../TestImages/test4.jpg")["Yellow"]);
        }

        [TestCategory("Green")]
        [TestMethod]
        public void Count5InImage4()
        {
            Assert.AreEqual(5, information.CountAllColours("../../TestImages/test4.jpg")["Green"]);
        }

        [TestCategory("Blue")]
        [TestMethod]
        public void Count1InImage5()
        {
            Assert.AreEqual(1, information.CountAllColours("../../TestImages/test5.jpg")["Blue"]);
        }

        [TestCategory("Blue")]
        [Ignore]
        [TestMethod]
        public void Count1InImage6()
        {
            Assert.AreEqual(1, information.CountAllColours("../../TestImages/test6.jpg")["Blue"]);
        }


        //        [TestMethod]
        //        public void SaveHighlightedPostItNotes()
        //        {
        //            Dictionary<string, int> rgbYellowPostit1 = new Dictionary<string, int>();
        //            rgbYellowPostit1.Add("R", 217);
        //            rgbYellowPostit1.Add("G", 245);
        //            rgbYellowPostit1.Add("B", 143);
        //            string resultPath = "result.png";
        //            if (File.Exists(resultPath))
        //            {
        //                File.Delete(resultPath);
        //            }
        //            information.SaveHighlightedPostItNotes("../../TestImages/test1.jpg", rgbYellowPostit1);
        //            Assert.AreEqual(true, File.Exists(resultPath));
        //        }
    }
}
