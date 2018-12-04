using CountPostIts.ConsoleUI;
using NUnit.Framework;
using System;
using System.IO;

namespace Tests
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

                string expected = "Enter filename: ";

                Assert.AreEqual(expected, sw.ToString());
            }
        }
    }
}