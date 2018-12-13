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

        Information information;

        [TestInitialize()]
        public void BeforeEachTest()
        {
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




  
    }
}
