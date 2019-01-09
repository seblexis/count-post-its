using System;
using System.Collections.Generic;
namespace CountPostIts.ConsoleUI
{
    public class ResultsGetter
    {
        private readonly ICountByColorWrapper _countByColor;

        public ResultsGetter(ICountByColorWrapper countByColor)
        {
            _countByColor = countByColor;
        }

        public Dictionary<string, int> Get(string filename)
        {
            Dictionary<string, int> result = _countByColor.OwnCountAllColours(filename);
            return result;
        }
    }
}
