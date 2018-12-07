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

        private readonly IHandleData _handleData;

        public Config(IFileWrapper file, IHandleData handleData)
        {
            _file = file;
            _handleData = handleData;
        }

        public void ChecksFile(string filename)
        {
            if (!_file.CallFileExists(filename)) throw new ArgumentException();

            _handleData.PostitResults(filename);
        }
    }
}
