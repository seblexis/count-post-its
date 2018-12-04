using CountPostIts.ImageRecognition;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CountPostIts.ImageRecognition.Tests
{
    [TestFixture]
    public class ImageTest
    {
        [Test]
        public void ReturnsSixWhenCountingYellowPostItNotes()
        {
            string path = "../../TestImages/postitsExample";
            Dictionary<string, int> rgb = new Dictionary<string, int>();
            rgb.Add("Red", 221);
            rgb.Add("Green", 217);
            rgb.Add("Blue", 216);
            
            Assert.AreEqual(PostItCounter.Count(path, rgb), 6);
        }

        [Test]
        public void ReturnRangeOfFiftyForRGBValue()
        {
            Assert.AreEqual(PostItCounter.RGBRange(100)[0], 75);
            Assert.AreEqual(PostItCounter.RGBRange(100)[1], 125);
        }

        public void DoesntReturnRangeBelowPossibleRGBValue()
        {
            Assert.AreEqual(PostItCounter.RGBRange(24)[0], 0);
        }
        public void DoesntReturnRangeAbovePossibleRGBValue()
        {
            Assert.AreEqual(PostItCounter.RGBRange(231)[1], 255);
        }



    }
}
