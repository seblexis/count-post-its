using System.Collections.Generic;

namespace CountPostIts.ConsoleUI
{
    public interface  IInformationWrapper
    {
        Dictionary<string, int> CallCountAllColours(string filename);
    }
}
