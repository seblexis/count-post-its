using Accord.Imaging;
using Accord.Imaging.Filters;
using CountPostIts.ImageRecognition;
using NUnit.Framework;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;

namespace CountPostIts.ImageRecognition.Tests
{
    [TestFixture]
    public class PostItCounterTest
    {
       // var colorFilter;

        [SetUp]
        public void BeforeEachTest()
        {
            // var colorFilter = Substitute.For<IFilter>();
        }

        [Test]
        public void ReturnsSixWhenCountingYellowPostItNotes()
        {
            string path = "../../TestImages/postitsExample";
            Dictionary<string, int> rgb = new Dictionary<string, int>();
            rgb.Add("R", 221);
            rgb.Add("G", 217);
            rgb.Add("B", 216);
            
            Assert.AreEqual(PostItCounter.Count(path, rgb), 6);
        }

    }
}
