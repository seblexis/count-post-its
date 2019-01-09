using System;

namespace CountPostIts.ConsoleUI
{
    public class Config
    {
        private readonly IFileWrapper _file;

        public Config(IFileWrapper file)
        {
            _file = file;
        }

        public Boolean ChecksFile(string filename)
        {
            if (!_file.CallFileExists(filename)) throw new ArgumentException();

            return true;
        }
    }
}
