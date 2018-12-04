using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CountPostIts.ConsoleUI
{
    public class FileVerification
    {
        public static void FileNamePrompt()
        {
            Console.WriteLine("Enter filename:");
        }

        public static void GetUserInput(string input = null)
        {
            input = input ?? Console.ReadLine();
            if(input.Contains(".jpg") || input.Contains(".png"))
            {
                Console.WriteLine($"Processing file {input}");
            }
            else
            {
                Console.WriteLine("Incorrect file type, please re-enter:");
            }
        }
    }
}
