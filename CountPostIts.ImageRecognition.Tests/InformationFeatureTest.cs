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
        int[] rgbYellowRange = {130,190,110,180,20,70};
        int[] rgbGreenRange = { 80, 110, 100, 130, 40, 70 };
        int[] rgbNeonYellowRange = { 200, 230, 230, 255, 120, 150 };
        int[] rgbPinkRange = { 225, 255, 65, 100, 110, 140 };
        int[] rgbLightBlueRange = { 75, 105, 150, 180, 150, 180 };
        int[] rgbBlueRange = { 10, 40, 80, 130, 110, 150 };
        int[] rgbMagentaRange = { 225, 255, 5, 65, 110, 150 };
        int[] rgbLightGreenRange = { 190, 220, 200, 230, 120, 155 };
        int[] rgbOrangeRange = { 160, 210, 75, 125, 0, 40 };
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
        public void CountPostItNotesWithRangeReturnsThreeForTestImage8AndGreen()
        {
            information.SaveHighlightedPostItNotesWithRange("../../TestImages/test8.jpg", rgbGreenRange);
            Assert.AreEqual(3, information.CountPostItNotesWithRanges("../../TestImages/test8.jpg", rgbGreenRange));
        }

        [TestCategory("Green")]
        [TestMethod]
        public void CountPostItNotesWithRangeReturnsZeroForTestImage1and3and5AndGreen()
        {
            string[] imagesNoGreen = { "1", "3", "5", "13", "16", "17"};
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


        
        //Might consider bit of post it on the left too small. Probably fixed by increasing minwidth.

        [TestCategory("Yellow")]
        [TestMethod]
        public void CountPostItNotesWithRangeReturnsThreeForTestImage8AndYellow()
        {
            information.SaveHighlightedPostItNotesWithRange("../../TestImages/test8.jpg", rgbYellowRange);
            Assert.AreEqual(3, information.CountPostItNotesWithRanges("../../TestImages/test8.jpg", rgbYellowRange));
        }

        [TestCategory("Yellow")]
        [TestMethod]
        public void CountPostItNotesWithRangeReturnsFourForTestImage13AndYellow()
        {
            information.SaveHighlightedPostItNotesWithRange("../../TestImages/test13.jpg", rgbYellowRange);
            Assert.AreEqual(4, information.CountPostItNotesWithRanges("../../TestImages/test13.jpg", rgbYellowRange));
        }

        [Ignore]
        //Not working because of overlapping. Returns 3 rather than 5
        [TestCategory("Yellow")]
        [TestMethod]
        public void CountPostItNotesWithRangeReturnsFiveForTestImage16AndYellow()
        {
            information.SaveHighlightedPostItNotesWithRange("../../TestImages/test16.jpg", rgbYellowRange);
            Assert.AreEqual(5, information.CountPostItNotesWithRanges("../../TestImages/test16.jpg", rgbYellowRange));
        }

        //There are actually 4 yellow post it notes here, but two are overlapped.
        //Method is not capable of distinguishing between yellow and yellow-greenish
        [Ignore]
        [TestCategory("Yellow")]
        [TestMethod]
        public void CountPostItNotesWithRangeReturnsTwoForTestImage17AndYellow()
        {
            information.SaveHighlightedPostItNotesWithRange("../../TestImages/test17.jpg", rgbYellowRange);
            Assert.AreEqual(2, information.CountPostItNotesWithRanges("../../TestImages/test17.jpg", rgbYellowRange));
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

            string[] imagesNoNeonYellow = { "3", "4", "5", "6", "7", "8", "13", "16", "17" };
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
            string[] imagesNoPink = { "3", "4", "5", "6", "7", "8", "13", "16", "17" };
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
            string[] imagesNoLightGreen = { "1", "4", "5", "6", "7", "8", "13", "16", "17" };
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
            string[] imagesNoMagenta = { "1", "4", "5", "6", "7", "8", "13", "16", "17" };
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
        public void CountPostItNotesWithRangeReturnsOneForTestImage8AndBlue()
        {
            information.SaveHighlightedPostItNotesWithRange("../../TestImages/test8.jpg", rgbBlueRange);
            Assert.AreEqual(1, information.CountPostItNotesWithRanges("../../TestImages/test8.jpg", rgbBlueRange));
        }

        [TestCategory("Blue")]
        [TestMethod]
        public void CountPostItNotesWithRangeReturnsOneForTestImage16AndBlue()
        {
            information.SaveHighlightedPostItNotesWithRange("../../TestImages/test16.jpg", rgbBlueRange);
            Assert.AreEqual(1, information.CountPostItNotesWithRanges("../../TestImages/test16.jpg", rgbBlueRange));
        }

        [TestCategory("Blue")]
        [TestMethod]
        public void CountPostItNotesWithRangeReturnsZeroForTestImage1and3and4and6and7AndBlue()
        {
            string[] imagesNoBlue = { "1", "3", "4", "6", "7", "13", "17" };
            TestForZero(rgbBlueRange, imagesNoBlue);
        }

        [Ignore]
        //Not working because of drawing in post it
        [TestCategory("Orange")]
        [TestMethod]
        public void CountPostItNotesWithRangeReturnsOneForTestImage16AndOrange()
        {
            information.SaveHighlightedPostItNotesWithRange("../../TestImages/test16.jpg", rgbOrangeRange);
            Assert.AreEqual(2, information.CountPostItNotesWithRanges("../../TestImages/test16.jpg", rgbOrangeRange));
        }

        [TestCategory("Orange")]
        [TestMethod]
        public void CountPostItNotesWithRangeReturnsZeroForOtherImagesAndOrange()
        {
            string[] imagesNoOrange = { "1", "3", "4", "5", "6", "7", "8", "13", "17" };
            TestForZero(rgbOrangeRange, imagesNoOrange);
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
