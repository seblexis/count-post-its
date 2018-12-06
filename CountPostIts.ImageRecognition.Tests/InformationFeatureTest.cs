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
        Dictionary<string, int> rgb_yellow_postit = new Dictionary<string, int>();
        Information information;

        [TestInitialize()]
        public void BeforeEachTest()
        {
            blobCounterWrapper = new BlobCounterWrapper();
            simpleShapeCheckerWrapper = new SimpleShapeCheckerWrapper();
            colorFilteringWrapper = new ColorFilteringWrapper();
            rgb_yellow_postit.Add("R", 217);
            rgb_yellow_postit.Add("G", 245);
            rgb_yellow_postit.Add("B", 143);
            information = new Information(blobCounterWrapper, simpleShapeCheckerWrapper, colorFilteringWrapper);
        }

        [TestMethod]
        public void CountPostItNotesReturns6ForTestImage1AndYellow()
        {
            
            Assert.AreEqual(6, information.CountPostItNotes("../../TestImages/test1.jpg", rgb_yellow_postit));
        }

        [TestMethod]
        public void SaveHighlightedPostItNotes()
        {
            string resultPath = "result.png";
            if (File.Exists(resultPath))
            {
                File.Delete(resultPath);
            }
            information.SaveHighlightedPostItNotes("../../TestImages/test1.jpg", rgb_yellow_postit);
            Assert.AreEqual(true, File.Exists(resultPath));
        }
    }
}
