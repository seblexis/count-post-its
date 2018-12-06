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
            var config = new Config(new FileWrapper(), new InformationWrapper());
        }
    }
}


