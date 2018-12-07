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
            information = new Information(blobCounterWrapper, simpleShapeCheckerWrapper, colorFilteringWrapper);
        }

        [TestMethod]
        public void CountPostItNotesReturns6ForTestImage1AndYellow()
        {
            Dictionary<string, int> rgbYellowPostit1 = new Dictionary<string, int>();
            rgbYellowPostit1.Add("R", 217);
            rgbYellowPostit1.Add("G", 245);
            rgbYellowPostit1.Add("B", 143);
            Assert.AreEqual(6, information.CountPostItNotes("../../TestImages/test1.jpg", rgbYellowPostit1));
        }

        [TestMethod]
        public void CountPostItNotesReturns6ForTestImage1AndPink()
        {
            Dictionary<string, int> rgbPinkPostit1 = new Dictionary<string, int>();
            rgbPinkPostit1.Add("R", 250);
            rgbPinkPostit1.Add("G", 98);
            rgbPinkPostit1.Add("B", 141);


            Assert.AreEqual(6, information.CountPostItNotes("../../TestImages/test1.jpg", rgbPinkPostit1));
        }

        [TestMethod]
        public void CountPostItNotesReturns3ForTestImage3AndBlue()
        {
            Dictionary<string, int> rgbBluePostit3 = new Dictionary<string, int>();
            rgbBluePostit3.Add("R", 90);
            rgbBluePostit3.Add("G", 168);
            rgbBluePostit3.Add("B", 168);

            Assert.AreEqual(3, information.CountPostItNotes("../../TestImages/test3.jpg", rgbBluePostit3));
        }

        [TestMethod]
        public void CountPostItNotesReturns3ForTestImage3AndLightGreen()
        {
            Dictionary<string, int> rgbLightGreenPostit3 = new Dictionary<string, int>();
            rgbLightGreenPostit3.Add("R", 203);
            rgbLightGreenPostit3.Add("G", 212);
            rgbLightGreenPostit3.Add("B", 129);

            Assert.AreEqual(3, information.CountPostItNotes("../../TestImages/test3.jpg", rgbLightGreenPostit3));
        }

        [TestMethod]
        public void CountPostItNotesReturns3ForTestImage3AndMagenta()
        {
            Dictionary<string, int> rgbMagentaPostit3 = new Dictionary<string, int>();
            rgbMagentaPostit3.Add("R", 255);
            rgbMagentaPostit3.Add("G", 12);
            rgbMagentaPostit3.Add("B", 115);

            information.SaveHighlightedPostItNotes("../../TestImages/test3.jpg", rgbMagentaPostit3);
            Assert.AreEqual(3, information.CountPostItNotes("../../TestImages/test3.jpg", rgbMagentaPostit3));
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
