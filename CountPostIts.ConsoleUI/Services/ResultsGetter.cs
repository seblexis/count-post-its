using System.Collections.Generic;

namespace CountPostIts.ConsoleUI.Services
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
            var result = _countByColor.OwnCountAllColors(filename);
            return result;
        }
    }
}