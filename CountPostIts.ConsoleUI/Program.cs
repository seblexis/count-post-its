using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace CountPostIts.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(ChecksFile)
                .WithNotParsed(options => Environment.Exit(-1));

            Console.ReadLine();
        }

        static void ChecksFile(Options options)
        {
            if (File.Exists(options.FileName))
            {



                if (options.IsMultiple)
                {
                    PostItCount.GetPostitCount(options.FileName);
                }
                else
                {
                    PostItCount.HasPostIt(options.FileName);
                }

                Console.WriteLine();
            }
        }


    }
}


