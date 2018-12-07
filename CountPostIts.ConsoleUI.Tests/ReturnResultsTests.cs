using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Moq;

namespace CountPostIts.ConsoleUI.Tests
{
    class ReturnResultsTests
    {
        private const string Filename = "postits.jpg";
        private ReturnResults _returnResults;

        [SetUp]
        public void Setup()
        {
            _returnResults = new ReturnResults();



        }

        [Test]
        public void Returns_5_when_CountPostits_Is_Called()
        {
            _returnResults.PostitResults(Filename);
           
        }




    }
}
