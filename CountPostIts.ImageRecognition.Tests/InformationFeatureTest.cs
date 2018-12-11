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
        int[] rgbYellowRange = {130,160,115,145,20,60};
        int[] rgbGreenRange = { 80, 110, 100, 130, 40, 70 };
        int[] rgbNeonYellowRange = { 200, 230, 230, 255, 120, 150 };
        int[] rgbPinkRange = { 225, 255, 65, 100, 110, 140 };
        int[] rgbLightBlueRange = { 75, 105, 150, 180, 150, 180 };
        int[] rgbBlueRange = { 10, 40, 100, 130, 120, 150 };
        int[] rgbMagentaRange = { 225, 255, 5, 65, 110, 150 };
        int[] rgbLightGreenRange = { 190, 220, 200, 230, 120, 155 };
        Information information;

        public void TestForZero(int[] rgbRange, string[] images)
        {
            for (int i=0; i < images.Length; i++)
            {
                Assert.AreEqual(0, information.CountPostItNotesWithRanges("../../TestImages/test" + images[i] +".jpg", rgbRange));
            }
        }

        [TestInitialize()]
        public void BeforeEachTest()
        {
            blobCounterWrapper = new BlobCounterWrapper();
            simpleShapeCheckerWrapper = new SimpleShapeCheckerWrapper();
            colorFilteringWrapper = new ColorFilteringWrapper();
            information = new Information(blobCounterWrapper, simpleShapeCheckerWrapper, colorFilteringWrapper);
        }

        [TestCategory("Green")]
        [TestMethod]
        public void CountPostItNotesWithRangeReturnsFiveForTestImage4AndGreen()
        {
            information.SaveHighlightedPostItNotesWithRange("../../TestImages/test4.jpg", rgbGreenRange);
            Assert.AreEqual(5, information.CountPostItNotesWithRanges("../../TestImages/test4.jpg", rgbGreenRange));
        }

        [TestCategory("Green")]
        [TestMethod]
        public void CountPostItNotesWithRangeReturnsOneForTestImage6AndGreen()
        {
            information.SaveHighlightedPostItNotesWithRange("../../TestImages/test6.jpg", rgbGreenRange);
            Assert.AreEqual(1, information.CountPostItNotesWithRanges("../../TestImages/test6.jpg", rgbGreenRange));
        }

        [TestCategory("Green")]
        [TestMethod]
        public void CountPostItNotesWithRangeReturnsFourForTestImage7AndGreen()
        {
            information.SaveHighlightedPostItNotesWithRange("../../TestImages/test7.jpg", rgbGreenRange);
            Assert.AreEqual(4, information.CountPostItNotesWithRanges("../../TestImages/test7.jpg", rgbGreenRange));
        }

        [TestCategory("Green")]
        [TestMethod]
        public void CountPostItNotesWithRangeReturnsZeroForTestImage1and3and5AndGreen()
        {
            string[] imagesNoGreen = { "1", "3", "5"};
            TestForZero(rgbGreenRange, imagesNoGreen);
            
        }

        [TestCategory("Yellow")]
        [TestMethod]
        public void CountPostItNotesWithRangeReturnsSevenForTestImage4AndYellow()
        {
            information.SaveHighlightedPostItNotesWithRange("../../TestImages/test4.jpg", rgbYellowRange);
            Assert.AreEqual(7, information.CountPostItNotesWithRanges("../../TestImages/test4.jpg", rgbYellowRange));
        }


        [TestCategory("Yellow")]
        [TestMethod]
        public void CountPostItNotesWithRangeReturnsTwoForTestImage5AndYellow()
        {
            information.SaveHighlightedPostItNotesWithRange("../../TestImages/test5.jpg", rgbYellowRange);
            Assert.AreEqual(2, information.CountPostItNotesWithRanges("../../TestImages/test5.jpg", rgbYellowRange));
        }

        [TestCategory("Yellow")]
        [TestMethod]
        public void CountPostItNotesWithRangeReturnsSixForTestImage6AndYellow()
        {
            information.SaveHighlightedPostItNotesWithRange("../../TestImages/test6.jpg", rgbYellowRange);
            Assert.AreEqual(6, information.CountPostItNotesWithRanges("../../TestImages/test6.jpg", rgbYellowRange));
        }

        [TestCategory("Yellow")]
        [TestMethod]
        public void CountPostItNotesWithRangeReturnsFourForTestImage7AndYellow()
        {
            information.SaveHighlightedPostItNotesWithRange("../../TestImages/test7.jpg", rgbYellowRange);
            Assert.AreEqual(4, information.CountPostItNotesWithRanges("../../TestImages/test7.jpg", rgbYellowRange));
        }

        [TestCategory("Yellow")]
        [TestMethod]
        public void CountPostItNotesWithRangeReturnsZeroForTestImage1and3AndYellow()
        {
            string[] imagesNoYellow = { "1", "3" };
            TestForZero(rgbYellowRange, imagesNoYellow);
           
        }


        [TestCategory("NeonYellow")]
        [TestMethod]
        public void CountPostItNotesWithRangeReturnsSixForTestImage1AndNeonYellow()
        {
            information.SaveHighlightedPostItNotesWithRange("../../TestImages/test1.jpg", rgbNeonYellowRange);
            Assert.AreEqual(6, information.CountPostItNotesWithRanges("../../TestImages/test1.jpg", rgbNeonYellowRange));                    
        }

        [TestCategory("NeonYellow")]
        [TestMethod]
        public void CountPostItNotesWithRangeReturnsZeroForTestImage3and4and5and6and7AndNeonYellow()
        {

            string[] imagesNoNeonYellow = { "3", "4", "5", "6", "7" };
            TestForZero(rgbNeonYellowRange, imagesNoNeonYellow);
        }

        [TestCategory("Pink")]
        [TestMethod]
        public void CountPostItNotesWithRangeReturnsSixForTestImage1AndPink()
        {
            information.SaveHighlightedPostItNotesWithRange("../../TestImages/test1.jpg", rgbPinkRange);
            Assert.AreEqual(6, information.CountPostItNotesWithRanges("../../TestImages/test1.jpg", rgbPinkRange));
        }

        [TestCategory("Pink")]
        [TestMethod]
        public void CountPostItNotesWithRangeReturnsZeroForTestImage3and4and5and6and7AndPink()
        {
            string[] imagesNoPink = { "3", "4", "5", "6", "7" };
            TestForZero(rgbPinkRange, imagesNoPink);
        }

        [TestCategory("LightGreen")]
        [TestMethod]
        public void CountPostItNotesWithRangeReturnsThreeForTestImage3AndLightGreen()
        {
            information.SaveHighlightedPostItNotesWithRange("../../TestImages/test3.jpg", rgbLightGreenRange);
            Assert.AreEqual(3, information.CountPostItNotesWithRanges("../../TestImages/test3.jpg", rgbLightGreenRange));
        }

        [TestCategory("LightGreen")]
        [TestMethod]
        public void CountPostItNotesWithRangeReturnsZeroForTestImage1and4and5and6and7AndLightGreen()
        {
            string[] imagesNoLightGreen = { "1", "4", "5", "6", "7" };
            TestForZero(rgbLightGreenRange, imagesNoLightGreen);
        }

        [TestCategory("Magenta")]
        [TestMethod]
        public void CountPostItNotesWithRangeReturnsThreeForTestImage3AndMagenta()
        {
            information.SaveHighlightedPostItNotesWithRange("../../TestImages/test3.jpg", rgbMagentaRange);
            Assert.AreEqual(3, information.CountPostItNotesWithRanges("../../TestImages/test3.jpg", rgbMagentaRange));
        }

        [TestCategory("Magenta")]
        [TestMethod]
        public void CountPostItNotesWithRangeReturnsZeroForTestImage1and4and5and6and7AndMagenta()
        {
            string[] imagesNoMagenta = { "1", "4", "5", "6", "7" };
            TestForZero(rgbMagentaRange, imagesNoMagenta);
         
        }

        [TestCategory("Blue")]
        [TestMethod]
        public void CountPostItNotesWithRangeReturnsOneForTestImage5AndBlue()
        {
            information.SaveHighlightedPostItNotesWithRange("../../TestImages/test5.jpg", rgbBlueRange);
            Assert.AreEqual(1, information.CountPostItNotesWithRanges("../../TestImages/test5.jpg", rgbBlueRange));
        }

        [TestCategory("Blue")]
        [TestMethod]
        public void CountPostItNotesWithRangeReturnsZeroForTestImage1and3and4and6and7AndBlue()
        {
            string[] imagesNoBlue = { "1", "3", "4", "6", "7" };
            TestForZero(rgbBlueRange, imagesNoBlue);
         
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

        
    }
}
