using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountPostIts.ConsoleUI
{
    public class HandleData : IHandleData
    {
        private readonly IInformationWrapper _information;

        public HandleData(IInformationWrapper information)
        {
            _information = information;
        }

        public void PostitResults(string filename)
        {
            int result = _information.CallCountPostits(filename);
            DisplayResults(result);
        }

        private void DisplayResults(int result)
        {
            Console.WriteLine($"Post it count: {result}");
        }
    }
}
