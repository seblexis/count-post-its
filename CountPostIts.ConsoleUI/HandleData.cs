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
            int result = _information.CallCountPostits(filename, colourValues);
            DisplayResults(result);
        }

        private void DisplayResults(int result)
        {
            Console.WriteLine($"Post it count: {result}");
        }
    }
}
