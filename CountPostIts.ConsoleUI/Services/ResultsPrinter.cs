using System;
using System.Collections.Generic;

namespace CountPostIts.ConsoleUI.Services
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
