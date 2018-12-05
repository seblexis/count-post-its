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
        [Value(0, Required = true, HelpText = "File must be saved in same directory as .exe")]
        public string FileName { get; set; }


        [Option('m', "multiple")]
        public bool IsMultiple { get; set; }

    }
}
