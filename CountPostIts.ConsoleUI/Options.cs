using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace CountPostIts.ConsoleUI
{
    class Options
    {
        [Value(0, Required = true)]
        public string FilePath { get; set; }
    }
}
