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

            config.ChecksFile(opt.FileName);
        }
    }
}


