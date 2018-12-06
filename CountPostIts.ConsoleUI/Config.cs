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
        private readonly IInformationWrapper _information;

        public Config(IFileWrapper file, IInformationWrapper information)
        {
            _file = file;
            _information = information;
        }

        public void ChecksFile(string filename)
        {
            if (!_file.CallFileExists(filename)) throw new ArgumentException();

            _information.CountPostits(filename);
        }
    }
}
