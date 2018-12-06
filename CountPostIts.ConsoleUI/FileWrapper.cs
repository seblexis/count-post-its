using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountPostIts.ConsoleUI
{
    class FileWrapper : IFileWrapper
    {
        public bool CallFileExists(string filename)
        {
            return File.Exists(filename);
        }
    }
}
