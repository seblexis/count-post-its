using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CountPostIts.ConsoleUI;

namespace CountPostIts.ConsoleUI
{
    public class Config
    {
        private readonly IFileWrapper _file;

        public Config(IFileWrapper file)
        {
            _file = file;
        }

        public void ChecksFile(string filename)
        {
            if (!_file.FileExists(filename)) throw new ArgumentNullException();
        }
    }
}
