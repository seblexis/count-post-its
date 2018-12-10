using System.Collections.Generic;

namespace CountPostIts.ConsoleUI
{
    public interface  IInformationWrapper
    {
        int CallCountPostits(string filename, Dictionary<string, int>colourValues);
    }
}
