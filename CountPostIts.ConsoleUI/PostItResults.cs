using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Channels;

namespace CountPostIts.ConsoleUI
{
    public class PostItResults : IPostItResults
    {

        public void ShowResults(String filename)
        {
            var resultsGetter = new ResultsGetter(new CountByColorWrapper());
            var result = resultsGetter.Get(filename);

            var resultsPrinter = new ResultsPrinter();
            resultsPrinter.Print(result);
        }
    }
}
