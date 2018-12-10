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
        Dictionary<string, int> rgb_yellow_postit4 = new Dictionary<string, int>();
        Information information;

        [TestInitialize()]
        public void BeforeEachTest()
        {
            blobCounterWrapper = new BlobCounterWrapper();
            simpleShapeCheckerWrapper = new SimpleShapeCheckerWrapper();
            colorFilteringWrapper = new ColorFilteringWrapper();
            rgb_yellow_postit4.Add("R", 144);
            rgb_yellow_postit4.Add("G", 129);
            rgb_yellow_postit4.Add("B", 40);
            information = new Information(blobCounterWrapper, simpleShapeCheckerWrapper, colorFilteringWrapper);
        }

        [TestMethod]
        public void CountPostItNotesReturnsSixForTestImage1AndYellow()
        {
            information.SaveHighlightedPostItNotes("../../TestImages/test1.jpg", rgb_yellow_postit4);
            Assert.AreEqual(6, information.CountPostItNotes("../../TestImages/test1.jpg", rgb_yellow_postit4));
        }

        [TestMethod]
        public void SaveHighlightedPostItNotes()
        {
            string resultPath = "result.png";
            if (File.Exists(resultPath))
            {
                File.Delete(resultPath);
            }
            information.SaveHighlightedPostItNotes("../../TestImages/test1.jpg", rgb_yellow_postit4);
            Assert.AreEqual(true, File.Exists(resultPath));
        }

        [TestMethod]
        public void CountPostItNotesReturnsFiveForTestImage4AndGreen()
        {
            Dictionary<string, int> rgb_green_postit4 = new Dictionary<string, int>();
            rgb_green_postit4.Add("R", 100);
            rgb_green_postit4.Add("G", 120);
            rgb_green_postit4.Add("B", 60);
            information.SaveHighlightedPostItNotes("../../TestImages/test4.jpg", rgb_green_postit4);
            Assert.AreEqual(5, information.CountPostItNotes("../../TestImages/test4.jpg", rgb_green_postit4));
        }

        [TestMethod]
        public void CountPostItNotesReturnsSevenForTestImage4AndYellow()
        {
            information.SaveHighlightedPostItNotes("../../TestImages/test4.jpg", rgb_yellow_postit4);
            Assert.AreEqual(7, information.CountPostItNotes("../../TestImages/test4.jpg", rgb_yellow_postit4));
        }

        [TestMethod]
        public void CountPostItNotesReturnsOneForTestImage5AndBlue()
        {
            Dictionary<string, int> rgb_blue_postit5 = new Dictionary<string, int>();
            rgb_blue_postit5.Add("R", 27);
            rgb_blue_postit5.Add("G", 107);
            rgb_blue_postit5.Add("B", 135);
            information.SaveHighlightedPostItNotes("../../TestImages/test5.jpg", rgb_blue_postit5);
            Assert.AreEqual(1, information.CountPostItNotes("../../TestImages/test5.jpg", rgb_blue_postit5));
        }

        [TestMethod]
        public void CountPostItNotesReturnsTwoForTestImage5AndYellow()
        {
            Dictionary<string, int> rgb_yellow_postit4 = new Dictionary<string, int>();
            information.SaveHighlightedPostItNotes("../../TestImages/test5.jpg", rgb_yellow_postit4);
            Assert.AreEqual(2, information.CountPostItNotes("../../TestImages/test5.jpg", rgb_yellow_postit4));
        }

        [TestMethod]
        public void CountPostItNotesReturnsSixForTestImage6AndYellow()
        {
            Dictionary<string, int> rgb_yellow_postit4 = new Dictionary<string, int>();
            information.SaveHighlightedPostItNotes("../../TestImages/test6.jpg", rgb_yellow_postit4);
            Assert.AreEqual(6, information.CountPostItNotes("../../TestImages/test6.jpg", rgb_yellow_postit4));
        }
    }
}
