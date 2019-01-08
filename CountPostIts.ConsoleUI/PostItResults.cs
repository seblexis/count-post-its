using System;
using System.Collections.Generic;

namespace CountPostIts.ConsoleUI
{
    public class PostItResults : IPostItResults
    {
        private readonly ICountByColorWrapper _countByColor;

        public PostItResults(ICountByColorWrapper countByColor)
        {
            _countByColor = countByColor;
        }

        public void DisplayResults(string filename)
        {
            Dictionary<string, int> result = RetrieveResults(filename);

            Console.WriteLine("Result: ");

            foreach (KeyValuePair<string, int> entry in result)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }
        }

        private Dictionary<string, int> RetrieveResults(string filename)
        {
            Dictionary<string, int> result = _countByColor.OwnCountAllColours(filename);
            return result;
        }
    }
}
