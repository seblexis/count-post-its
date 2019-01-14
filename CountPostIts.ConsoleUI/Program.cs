using System;
using CommandLine;
using CountPostIts.ConsoleUI.Entities;
using CountPostIts.ConsoleUI.Services;
using CountPostIts.ConsoleUI.Services.Impl;
using CountPostIts.ImageRecognition.Services;
using CountPostIts.ImageRecognition.Services.Impl;

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

            IBlobCounterWrapper blobCounterWrapper = new BlobCounterWrapper();
            ISimpleShapeCheckerWrapper simpleShapeCheckerWrapper = new SimpleShapeCheckerWrapper();
            IColorFilteringWrapper colorFilteringWrapper = new ColorFilteringWrapper();
            IPostItAnalysis postItAnalysis = new PostItAnalysis(blobCounterWrapper, simpleShapeCheckerWrapper, colorFilteringWrapper);
            ICountByColor countByColor = new CountByColor(postItAnalysis);

            try
            {
                if (startup.VerifyFile(filePath))
                {
                    var resultsGetter = new ResultsGetter(countByColor);
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