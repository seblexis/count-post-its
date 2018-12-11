using System.Collections.Generic;

namespace CountPostIts.ConsoleUI
{
    public interface  IInformationWrapper
    {
        void SaveHighlightedPostItNotes(string filename, Dictionary<string, int> colourValues);
        Dictionary<string, int> CallCountPostits(string filename, Dictionary<string, int>colourValues);
    }
}
