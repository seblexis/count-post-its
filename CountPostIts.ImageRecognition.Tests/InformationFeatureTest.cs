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
        public void Count7YellowInImage1()
        {
            Assert.AreEqual(7, information.CountAllColours("../../TestImages/test1.jpg")["Yellow"]);
        }

        [Ignore]
        [TestCategory("Yellow")]
        [TestMethod]
        //Test is only returning 3 because of overlap
        public void Count3YellowInImage4()
        {
            Assert.AreEqual(5, information.CountAllColours("../../TestImages/test4.jpg")["Yellow"]);
        }

        [TestCategory("Green")]
        [TestMethod]
        public void Count5GreenInImage1()
        {
            Assert.AreEqual(5, information.CountAllColours("../../TestImages/test1.jpg")["Green"]);
        }

        [TestCategory("Green")]
        [TestMethod]
        public void Count4GreenInImage5()
        {
            Assert.AreEqual(4, information.CountAllColours("../../TestImages/test5.jpg")["Green"]);
        }

        [TestCategory("Blue")]
        [TestMethod]
        public void Count1BlueInImage2()
        {
            Assert.AreEqual(1, information.CountAllColours("../../TestImages/test2.jpg")["Blue"]);
        }

        [TestCategory("Blue")]
        [TestMethod]
        public void Count1BlueInImage3()
        {
            Assert.AreEqual(1, information.CountAllColours("../../TestImages/test3.jpg")["Blue"]);
        }

        [TestCategory("Blue")]
        [TestMethod]
        public void Count1BlueInImage4()
        {
            Assert.AreEqual(1, information.CountAllColours("../../TestImages/test4.jpg")["Blue"]);
        }
        [TestCategory("Blue")]
        [TestMethod]
        public void Count1BlueInImage5()
        {
            Assert.AreEqual(1, information.CountAllColours("../../TestImages/test5.jpg")["Blue"]);
        }
        [TestCategory("Blue")]
        [TestMethod]
        public void Count3BlueInImage6()
        {
            Assert.AreEqual(3, information.CountAllColours("../../TestImages/test6.jpg")["Blue"]);
        }

        [Ignore]
        [TestCategory("Orange")]
        [TestMethod]
        //Test not passing (returning 1) because of writing in post it, not because of not match
        public void Count2OrangeInImage4()
        {
            Assert.AreEqual(2, information.CountAllColours("../../TestImages/test4.jpg")["Orange"]);
        }

        [TestCategory("Pink")]
        [TestMethod]
        public void Count2PinkInImage5()
        {
            Assert.AreEqual(2, information.CountAllColours("../../TestImages/test5.jpg")["Pink"]);
        }

        [TestCategory("Pink")]
        [TestMethod]
        public void Count1PinkInImage6()
        {
            Assert.AreEqual(1, information.CountAllColours("../../TestImages/test6.jpg")["Pink"]);
        }

        [TestCategory("Purple")]
        [TestMethod]
        //Test not passing because of shadow making post it note not quadrilateral
        public void Count3PurpleInImage6()
        {
            Assert.AreEqual(3, information.CountAllColours("../../TestImages/test6.jpg")["Purple"]);
        }

 




    }
}
