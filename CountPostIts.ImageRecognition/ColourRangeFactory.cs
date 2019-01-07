using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountPostIts.ImageRecognition
{
    class ColourRangeFactory : IColourRangeFactory
    {
        public IColourRange Create()
        {
            return new ColourRange();
        }
    }
}
