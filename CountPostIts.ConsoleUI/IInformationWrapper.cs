using System.Collections.Generic;

namespace CountPostIts.ConsoleUI
{
    public interface  IInformationWrapper
    {
        Dictionary<string, int> CallCountPostits(string filename, Dictionary<string, int>colourValues);
    }
}
