using System;
using System.Collections.Generic;
using CountPostIts.ImageRecognition;

namespace CountPostIts.ConsoleUI
{
    class InformationWrapper : IInformationWrapper
    {
        //TODO: Reimplement the return command once CountPostItNotes is updated to return a dictionary
        public Dictionary<string, int> CallCountPostits(string filename, Dictionary<string, int> colourValues)
        {
            Information information = new Information();
            // return information.CountPostItNotes(filename, colourValues);
            throw new NotImplementedException();
        }

        public void SaveHighlightedPostItNotes(string filename, Dictionary<string, int> colourValues)
        {
            Information information = new Information();
            information.SaveHighlightedPostItNotes(filename, colourValues);
        }
    }

   
}
