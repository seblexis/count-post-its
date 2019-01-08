using System;

namespace CountPostIts.ConsoleUI
{
    public class Config
    {
        private readonly IFileWrapper _file;
        private readonly IPostItResults _handleData;

        public Config(IFileWrapper file, IPostItResults handleData)
        {
            _file = file;
            _handleData = handleData;
        }

        public void ChecksFile(string filename)
        {
            if (!_file.CallFileExists(filename)) throw new ArgumentException();

            _handleData.DisplayResults(filename);
        }
    }
}
