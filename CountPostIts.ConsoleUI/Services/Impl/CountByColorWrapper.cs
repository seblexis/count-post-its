using System.Collections.Generic;
using CountPostIts.ImageRecognition.Services;

namespace CountPostIts.ConsoleUI.Services.Impl
{
    internal class CountByColorWrapper : ICountByColorWrapper
    {
        public Dictionary<string, int> OwnCountAllColors(string filename)
        {
            var information = new CountByColor();
            return information.CountAllColours(filename);
        }
    }
}