using System.Collections.Generic;
using CountPostIts.ImageRecognition.Services;

namespace CountPostIts.ConsoleUI.Services
{
    public class ResultsGetter
    {
        private readonly ICountByColor _countByColor;

        public ResultsGetter(ICountByColor countByColor)
        {
            _countByColor = countByColor;
        }

        public Dictionary<string, int> Get(string filename)
        {
            var result = _countByColor.CountAllColors(filename);
            return result;
        }
    }
}