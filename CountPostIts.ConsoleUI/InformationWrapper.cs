using System;
using System.Collections.Generic;
using CountPostIts.ImageRecognition;

namespace CountPostIts.ConsoleUI
{
    class InformationWrapper : IInformationWrapper
    {
        public Dictionary<string, int> CallCountAllColours(string filename)
        {
            Information information = new Information();
            return information.CountAllColours(filename);
        }

    }

   
}
