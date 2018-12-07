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
        Dictionary<string, int> rgbYellowPostit = new Dictionary<string, int>();
        Dictionary<string, int> rgbPinkPostit = new Dictionary<string, int>();
        Information information;

        [TestInitialize()]
        public void BeforeEachTest()
        {
            blobCounterWrapper = new BlobCounterWrapper();
            simpleShapeCheckerWrapper = new SimpleShapeCheckerWrapper();
            colorFilteringWrapper = new ColorFilteringWrapper();
            rgbYellowPostit.Add("R", 217);
            rgbYellowPostit.Add("G", 245);
            rgbYellowPostit.Add("B", 143);
            rgbPinkPostit.Add("R", 250 );
            rgbPinkPostit.Add("G", 98);
            rgbPinkPostit.Add("B", 141);
            information = new Information(blobCounterWrapper, simpleShapeCheckerWrapper, colorFilteringWrapper);
        }

        [TestMethod]
        public void CountPostItNotesReturns6ForTestImage1AndYellow()
        {
            Assert.AreEqual(6, information.CountPostItNotes("../../TestImages/test1.jpg", rgbYellowPostit));
        }

        [TestMethod]
        public void CountPostItNotesReturns6ForTestImage1AndPink()
        {
            information.SaveHighlightedPostItNotes("../../TestImages/test1.jpg", rgbPinkPostit);
            Assert.AreEqual(6, information.CountPostItNotes("../../TestImages/test1.jpg", rgbPinkPostit));
        }

        [TestMethod]
        public void SaveHighlightedPostItNotes()
        {
            string resultPath = "result.png";
            if (File.Exists(resultPath))
            {
                File.Delete(resultPath);
            }
            information.SaveHighlightedPostItNotes("../../TestImages/test1.jpg", rgbYellowPostit);
            Assert.AreEqual(true, File.Exists(resultPath));
        }
    }
}
