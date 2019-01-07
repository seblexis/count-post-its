using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountPostIts.ImageRecognition
{
    public class ColorRange : IColorRange

    {
        private int[] _rangeRed;
        private int[] _rangeGreen;
        private int[] _rangeBlue;

        public int[] RangeRed
        {
            get => _rangeRed;
            set
            {
                try
                {
                    CheckRanges(value);
                    _rangeRed = value;
                }
                catch (ArgumentOutOfRangeException outOfRange)
                {
                    Console.WriteLine(outOfRange.Message);
                }
            }
        }

        public int[] RangeGreen
        {
            get => _rangeGreen;
            set
            {
                try
                {
                    CheckRanges(value);
                    _rangeGreen = value;
                }
                catch (ArgumentOutOfRangeException outOfRange)
                {
                    Console.WriteLine(outOfRange.Message);
                }
            }
        }

        public int[] RangeBlue
        {
            get => _rangeBlue;
            set
            {
                try
                {
                    CheckRanges(value);
                    _rangeBlue = value;
                }
                catch (ArgumentOutOfRangeException outOfRange)
                {
                    Console.WriteLine(outOfRange.Message);
                    throw;
                }
            }
        }

        private void CheckRanges(int[] rgbRange)
        {
            if (rgbRange[0] > rgbRange[1])
            {
                throw new ArgumentOutOfRangeException(nameof(rgbRange), "First value needs to be lower than second");
            }

            if (rgbRange[0] < 0 || rgbRange[0] > 255 || rgbRange[1] < 0 || rgbRange[1] > 255)
            {
                throw new ArgumentOutOfRangeException(nameof(rgbRange),"Values need to be below 0 and 255");
            }
        }
        
    }
}
