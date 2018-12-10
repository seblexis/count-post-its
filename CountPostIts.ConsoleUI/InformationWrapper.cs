using System;
using System.Collections.Generic;
using CountPostIts.ImageRecognition;

namespace CountPostIts.ConsoleUI
{
    class InformationWrapper : IInformationWrapper
    {
        public int CallCountPostits(string filename)
        {
            Information information = new Information();
            Dictionary<string, int> dict = new Dictionary<string, int>();
            dict.Add("R", 202);
            dict.Add("G", 66);
            dict.Add("B", 99);
            return information.CountPostItNotes(filename, dict);
        }
    }
}
