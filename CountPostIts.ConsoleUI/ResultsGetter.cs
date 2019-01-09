using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountPostIts.ConsoleUI
{
    public class ResultsGetter
    {
        private readonly ICountByColorWrapper _countByColor;

        public ResultsGetter(ICountByColorWrapper countByColor)
        {
            _countByColor = countByColor;
        }

        public Dictionary<string, int> Get(String filename)
        {
            Dictionary<string, int> result = _countByColor.OwnCountAllColours(filename);
            return result;
        }


    }
}
