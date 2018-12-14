using System;
using System.Collections.Generic;

namespace CountPostIts.ConsoleUI
{
    public class HandleData : IHandleData
    {
        private readonly IInformationWrapper _information;

        public HandleData(IInformationWrapper information)
        {
            _information = information;
        }

        public void PostitResults(string filename, Dictionary<string, int> colourValues)
        {
            _information.SaveHighlightedPostItNotes(filename, colourValues);
            Dictionary<string, int> result = _information.CallCountPostits(filename, colourValues);
            DisplayResults(result);

        }

        private void DisplayResults(Dictionary<string, int> result)
        {
            Console.WriteLine("Result: ");
            foreach (KeyValuePair<string, int> entry in result)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }
        }
    }
}
