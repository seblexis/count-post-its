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
        Dictionary<string, int> rgbYellowRange4 = new Dictionary<string, int>();
        Dictionary<string, int> rgbGreenRange4 = new Dictionary<string, int>();
        Dictionary<string, int> rgbNeonYellowRange1 = new Dictionary<string, int>();
        Dictionary<string, int> rgbPinkRange1 = new Dictionary<string, int>();
        Dictionary<string, int> rgbLightBlueRange3 = new Dictionary<string, int>();
        Dictionary<string, int> rgbBlueRange5 = new Dictionary<string, int>();
        Dictionary<string, int> rgbMagentaRange3 = new Dictionary<string, int>();
        Dictionary<string, int> rgbLightGreenRange3 = new Dictionary<string, int>();
        Information information;

        [TestInitialize()]
        public void BeforeEachTest()
        {
            blobCounterWrapper = new BlobCounterWrapper();
            simpleShapeCheckerWrapper = new SimpleShapeCheckerWrapper();
            colorFilteringWrapper = new ColorFilteringWrapper();

            rgbYellowRange4.Add("RMin", 130);
            rgbYellowRange4.Add("RMax", 160);
            rgbYellowRange4.Add("GMin", 115);
            rgbYellowRange4.Add("GMax", 145);
            rgbYellowRange4.Add("BMin", 20);
            rgbYellowRange4.Add("BMax", 50);

            rgbLightGreenRange3.Add("RMin", 190);
            rgbLightGreenRange3.Add("RMax", 220);
            rgbLightGreenRange3.Add("GMin", 200);
            rgbLightGreenRange3.Add("GMax", 230);
            rgbLightGreenRange3.Add("BMin", 120);
            rgbLightGreenRange3.Add("BMax", 155);

            rgbGreenRange4.Add("RMin", 80);
            rgbGreenRange4.Add("RMax", 110);
            rgbGreenRange4.Add("GMin", 100);
            rgbGreenRange4.Add("GMax", 130);
            rgbGreenRange4.Add("BMin", 40);
            rgbGreenRange4.Add("BMax", 70);

            
            rgbNeonYellowRange1.Add("RMin", 200);
            rgbNeonYellowRange1.Add("RMax", 230);
            rgbNeonYellowRange1.Add("GMin", 230);
            rgbNeonYellowRange1.Add("GMax", 255);
            rgbNeonYellowRange1.Add("BMin", 120);
            rgbNeonYellowRange1.Add("BMax", 150);

            rgbPinkRange1.Add("RMin", 225);
            rgbPinkRange1.Add("RMax", 255);
            rgbPinkRange1.Add("GMin", 65);
            rgbPinkRange1.Add("GMax", 100);
            rgbPinkRange1.Add("BMin", 110);
            rgbPinkRange1.Add("BMax", 140);

            rgbLightBlueRange3.Add("RMin", 75);
            rgbLightBlueRange3.Add("RMax", 105);
            rgbLightBlueRange3.Add("GMin", 150);
            rgbLightBlueRange3.Add("GMax", 180);
            rgbLightBlueRange3.Add("BMin", 150);
            rgbLightBlueRange3.Add("BMax", 180);

            rgbBlueRange5.Add("RMin", 10);
            rgbBlueRange5.Add("RMax", 40);
            rgbBlueRange5.Add("GMin", 100);
            rgbBlueRange5.Add("GMax", 130);
            rgbBlueRange5.Add("BMin", 120);
            rgbBlueRange5.Add("BMax", 150);

            rgbMagentaRange3.Add("RMin", 225);
            rgbMagentaRange3.Add("RMax", 255);
            rgbMagentaRange3.Add("GMin", 5);
            rgbMagentaRange3.Add("GMax", 65);
            rgbMagentaRange3.Add("BMin", 110);
            rgbMagentaRange3.Add("BMax", 150);

            information = new Information(blobCounterWrapper, simpleShapeCheckerWrapper, colorFilteringWrapper);
        }

        [TestMethod]
        public void CountPostItNotesWithRangeReturnsSixForTestImage1AndNeonYellow()
        {
            information.SaveHighlightedPostItNotesWithRange("../../TestImages/test1.jpg", rgbNeonYellowRange1);
            Assert.AreEqual(6, information.CountPostItNotesWithRanges("../../TestImages/test1.jpg", rgbNeonYellowRange1));                    
        }

        [TestMethod]
        public void CountPostItNotesWithRangeReturnsSixForTestImage1AndPink()
        {
            information.SaveHighlightedPostItNotesWithRange("../../TestImages/test1.jpg", rgbPinkRange1);
            Assert.AreEqual(6, information.CountPostItNotesWithRanges("../../TestImages/test1.jpg", rgbPinkRange1));
        }


        [TestMethod]
        public void CountPostItNotesWithRangeReturnsThreeForTestImage3AndLightGreen()
        {
            information.SaveHighlightedPostItNotesWithRange("../../TestImages/test3.jpg", rgbLightGreenRange3);
            Assert.AreEqual(3, information.CountPostItNotesWithRanges("../../TestImages/test3.jpg", rgbLightGreenRange3));
        }

        [TestMethod]
        public void CountPostItNotesWithRangeReturnsZeroForTestImage4and6and7AndLightGreen()
        {
            information.SaveHighlightedPostItNotesWithRange("../../TestImages/test4.jpg", rgbLightGreenRange3);
            Assert.AreEqual(0, information.CountPostItNotesWithRanges("../../TestImages/test4.jpg", rgbLightGreenRange3));
            Assert.AreEqual(0, information.CountPostItNotesWithRanges("../../TestImages/test6.jpg", rgbLightGreenRange3));
            Assert.AreEqual(0, information.CountPostItNotesWithRanges("../../TestImages/test7.jpg", rgbLightGreenRange3));
        }


        [TestMethod]
        public void CountPostItNotesWithRangeReturnsThreeForTestImage3AndMagenta()
        {
            information.SaveHighlightedPostItNotesWithRange("../../TestImages/test3.jpg", rgbMagentaRange3);
            Assert.AreEqual(3, information.CountPostItNotesWithRanges("../../TestImages/test3.jpg", rgbMagentaRange3));
        }

        [TestMethod]
        public void CountPostItNotesWithRangeReturnsOneForTestImage5AndBlue()
        {
            information.SaveHighlightedPostItNotesWithRange("../../TestImages/test5.jpg", rgbBlueRange5);
            Assert.AreEqual(1, information.CountPostItNotesWithRanges("../../TestImages/test5.jpg", rgbBlueRange5));
        }

        [TestMethod]
        public void SaveHighlightedPostItNotes()
        {
            Dictionary<string, int> rgbYellowPostit1 = new Dictionary<string, int>();
            rgbYellowPostit1.Add("R", 217);
            rgbYellowPostit1.Add("G", 245);
            rgbYellowPostit1.Add("B", 143);
            string resultPath = "result.png";
            if (File.Exists(resultPath))
            {
                File.Delete(resultPath);
            }
            information.SaveHighlightedPostItNotes("../../TestImages/test1.jpg", rgbYellowPostit1);
            Assert.AreEqual(true, File.Exists(resultPath));
        }


        [TestMethod]
        public void CountPostItNotesWithRangeReturnsFiveForTestImage4AndGreen()
        {
            information.SaveHighlightedPostItNotesWithRange("../../TestImages/test4.jpg", rgbGreenRange4);
            Assert.AreEqual(5, information.CountPostItNotesWithRanges("../../TestImages/test4.jpg", rgbGreenRange4));
        }

        [TestMethod]
        public void CountPostItNotesWithRangeReturnsOneForTestImage6AndGreen()
        {
            information.SaveHighlightedPostItNotesWithRange("../../TestImages/test6.jpg", rgbGreenRange4);
            Assert.AreEqual(1, information.CountPostItNotesWithRanges("../../TestImages/test6.jpg", rgbGreenRange4));
        }

        [TestMethod]
        public void CountPostItNotesWithRangeReturnsFourForTestImage7AndGreen()
        {
            information.SaveHighlightedPostItNotesWithRange("../../TestImages/test7.jpg", rgbGreenRange4);
            Assert.AreEqual(4, information.CountPostItNotesWithRanges("../../TestImages/test7.jpg", rgbGreenRange4));
        }

        [TestMethod]
        public void CountPostItNotesWithRangeReturnsSevenForTestImage4AndYellow()
        {
            information.SaveHighlightedPostItNotesWithRange("../../TestImages/test4.jpg", rgbYellowRange4);
            Assert.AreEqual(7, information.CountPostItNotesWithRanges("../../TestImages/test4.jpg", rgbYellowRange4));
        }

        
    }
}
