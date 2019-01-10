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
            var setup = new Startup(
                new FileWrapper()
            );

            var filePath = setup.GetPathInProject(opt.FileName);
            
            if (setup.VerifyFile(filePath))
            {
                var resultsGetter = new ResultsGetter(new CountByColorWrapper());
                var result = resultsGetter.Get(filePath);

                var resultsPrinter = new ResultsPrinter();
                resultsPrinter.Print(result);
            };
        }
    }
}


