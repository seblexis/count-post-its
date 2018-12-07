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

        public int PostitResults(string filename)
        {
            return _information.CallCountPostits(filename);
        }
    }
}
