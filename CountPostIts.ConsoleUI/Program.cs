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
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}


