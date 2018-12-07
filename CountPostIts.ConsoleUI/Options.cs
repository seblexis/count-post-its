using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace CountPostIts.ConsoleUI
{
    public class Options
    {
        [Value(0, Required = true, HelpText = "The filename to analyse.")]
        public string FileName { get; set; }
    }
}
