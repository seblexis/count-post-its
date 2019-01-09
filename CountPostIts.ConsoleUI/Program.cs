using System;
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
                new FileWrapper()
            );

            if (config.ChecksFile(opt.FileName))
            {
                var resultsGetter = new ResultsGetter(new CountByColorWrapper());
                var result = resultsGetter.Get(opt.FileName);

                var resultsPrinter = new ResultsPrinter();
                resultsPrinter.Print(result);
            };
        }
    }
}


