using System;
using System.IO;
using NUnit.Framework;

namespace CountPostIts.ConsoleUI.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void FileNamePromptAsksForInput()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                FileVerification.FileNamePrompt();

                string expected = "Enter filename:\r\n";

                Assert.AreEqual(expected, sw.ToString());
            }
        }

        [Test]
        public void GetUserInputConfirmsOnCorrectInput()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                FileVerification.GetUserInput("Postits.jpg");

                string expected = "Processing file Postits.jpg\r\n";

                Assert.AreEqual(expected, sw.ToString());
            }
        }

        [Test]
        public void GetUserInputDisplaysErrorOnIncorrectInput()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                FileVerification.GetUserInput("Postits");

                string expected = "Incorrect file type, please re-enter:\r\n";

                Assert.AreEqual(expected, sw.ToString());
            }
        }
    }
}