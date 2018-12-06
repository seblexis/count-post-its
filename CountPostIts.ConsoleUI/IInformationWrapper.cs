using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountPostIts.ConsoleUI
{
    public interface  IInformationWrapper
    {
        int CountPostits(string filename);

        bool HasPostits(string filename);
    }
}
