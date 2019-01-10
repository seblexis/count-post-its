using System;
using System.IO;

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

        public string GetPathInProject(string filename)
        {
            return new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName + "\\images\\" + filename;
        }
    }
}
