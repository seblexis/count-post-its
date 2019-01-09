using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountPostIts.ConsoleUI
{
    public class ResultsPrinter
    {
        public void Print(Dictionary<string, int> result)
        {
            Console.WriteLine("Result: ");

            foreach (KeyValuePair<string, int> entry in result)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }
        }
    }
}
