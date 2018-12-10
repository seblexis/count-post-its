using System;
using System.Collections.Generic;
using CountPostIts.ImageRecognition;

namespace CountPostIts.ConsoleUI
{
    class InformationWrapper : IInformationWrapper
    {
        public int CallCountPostits(string filename, Dictionary<string, int> colourValues)
        {
            Information information = new Information();
            return information.CountPostItNotes(filename, colourValues);
        }

        public void SaveHighlightedPostItNotes(string filename, Dictionary<string, int> colourValues)
        {
            Information information = new Information();
            information.SaveHighlightedPostItNotes(filename, colourValues);
        }
    }

   
}
