using System.Collections.Generic;
using CountPostIts.ImageRecognition;

namespace CountPostIts.ConsoleUI
{
    class CountByColorWrapper : ICountByColorWrapper
    {
        public Dictionary<string, int> OwnCountAllColours(string filename)
        {
            CountByColor information = new CountByColor();
            return information.CountAllColours(filename);
        }
    }
}
