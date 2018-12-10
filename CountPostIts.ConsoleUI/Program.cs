using System;
using System.Collections.Generic;
using CommandLine;

namespace CountPostIts.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(Run)
                .WithNotParsed(opt => Environment.Exit(-1));
        }

        static void Run(Options opt)
        {
            var config = new Config(
                new FileWrapper(), new HandleData(new InformationWrapper())
            );

            Dictionary<string, int> colourValues = new Dictionary<string, int>();
            colourValues.Add("R", opt.rVal);
            colourValues.Add("B", opt.bVal);
            colourValues.Add("G", opt.gVal);

            config.ChecksFile(opt.FileName, colourValues);
        }
    }
}


