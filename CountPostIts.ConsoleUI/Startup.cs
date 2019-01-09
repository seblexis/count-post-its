using System;

namespace CountPostIts.ConsoleUI
{
    public class Startup
    {
        private readonly IFileWrapper _file;

        public Startup(IFileWrapper file)
        {
            _file = file;
        }

        public bool VerifyFile(string filename)
        {
            if (!_file.CallFileExists(filename)) throw new ArgumentException();

            return true;
        }
    }
}
