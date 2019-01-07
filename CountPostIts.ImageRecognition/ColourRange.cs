using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountPostIts.ImageRecognition
{
    public class ColourRange : IColourRange
    
    {

        public ColourRange()
        {
        }

        public int[] RangeRed { get; set; }

        public int[] RangeBlue { get; set; }
       
        public int[] RangeGreen { get; set; }
        
    }
}
