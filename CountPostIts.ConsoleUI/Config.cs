using System;

namespace CountPostIts.ConsoleUI
{
    public class Config
    {
        private readonly IFileWrapper _file;
        private readonly IPostItResults _postItResults;

        public Config(IFileWrapper file, IPostItResults postItResults)
        {
            _file = file;
            _postItResults = postItResults;
        }

        public void ChecksFile(string filename)
        {
            if (!_file.CallFileExists(filename)) throw new ArgumentException();

            _postItResults.DisplayResults(filename);
        }
    }
}
