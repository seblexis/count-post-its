using System.Collections.Generic;

namespace CountPostIts.ConsoleUI
{
    public interface  ICountByColorWrapper
    {
        Dictionary<string, int> OwnCountAllColours(string filename);
    }
}
