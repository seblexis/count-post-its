using System.Collections.Generic;
using CountPostIts.ImageRecognition;
using CountPostIts.ImageRecognition.Services;

namespace CountPostIts.ConsoleUI.Services.Impl
{
    class CountByColorWrapper : ICountByColorWrapper
    {
        public Dictionary<string, int> OwnCountAllColors(string filename)
        {
            CountByColor information = new CountByColor();
            return information.CountAllColours(filename);
        }
    }
}
