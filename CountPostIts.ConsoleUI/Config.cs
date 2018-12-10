using System;
using System.Collections.Generic;

namespace CountPostIts.ConsoleUI
{
    public class Config
    {
        private readonly IFileWrapper _file;
        private readonly IHandleData _handleData;

        public Config(IFileWrapper file, IHandleData handleData)
        {
            _file = file;
            _handleData = handleData;
        }

        public void ChecksFile(string filename, Dictionary<string, int> colourValues)
        {
            if (!_file.CallFileExists(filename)) throw new ArgumentException();

            _handleData.PostitResults(filename, colourValues);
        }
    }
}
