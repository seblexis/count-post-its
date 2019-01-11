using System;
using CommandLine;
using CountPostIts.ConsoleUI.Entities;
using CountPostIts.ConsoleUI.Services;
using CountPostIts.ConsoleUI.Services.Impl;

namespace CountPostIts.ConsoleUI
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(Run)
                .WithNotParsed(opt => Environment.Exit(-1));
        }

        private static void Run(Options opt)
        {
            var startup = new Startup(
                new FileWrapper()
            );

            var filePath = startup.GetPathInProject(opt.FileName);

            try
            {
                if (startup.VerifyFile(filePath))
                {
                    var resultsGetter = new ResultsGetter(new CountByColorWrapper());
                    var result = resultsGetter.Get(filePath);

                    var resultsPrinter = new ResultsPrinter();
                    resultsPrinter.Print(result);
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}