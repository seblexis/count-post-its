using System.Collections.Generic;
using CountPostIts.ImageRecognition;

namespace CountPostIts.ConsoleUI
{
    class InformationWrapper : IInformationWrapper
    {
        public Dictionary<string, int> OwnCountAllColours(string filename)
        {
            Information information = new Information();
            return information.CountAllColours(filename);
        }

    }

   
}
