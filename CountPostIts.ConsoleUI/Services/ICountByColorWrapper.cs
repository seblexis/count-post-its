using System.Collections.Generic;

namespace CountPostIts.ConsoleUI.Services
{
    public interface ICountByColorWrapper
    {
        Dictionary<string, int> OwnCountAllColors(string filename);
    }
}