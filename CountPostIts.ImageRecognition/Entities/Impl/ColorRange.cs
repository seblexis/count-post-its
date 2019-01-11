using System;

namespace CountPostIts.ImageRecognition.Entities.Impl
{
    public class ColorRange : IColorRange

    {
        private int[] _rangeBlue;
        private int[] _rangeGreen;
        private int[] _rangeRed;

        public int[] RangeRed
        {
            get => _rangeRed;
            set
            {
                VerifyRanges(value);
                _rangeRed = value;
            }
        }

        public int[] RangeGreen
        {
            get => _rangeGreen;
            set
            {
                VerifyRanges(value);
                _rangeGreen = value;
            }
        }

        public int[] RangeBlue
        {
            get => _rangeBlue;
            set
            {
                VerifyRanges(value);
                _rangeBlue = value;
            }
        }

        private void VerifyRanges(int[] rgbRange)
        {
            if (rgbRange[0] > rgbRange[1])
                throw new ArgumentOutOfRangeException(nameof(rgbRange), "First value needs to be lower than second");

            if (rgbRange[0] < 0 || rgbRange[0] > 255 || rgbRange[1] < 0 || rgbRange[1] > 255)
                throw new ArgumentOutOfRangeException(nameof(rgbRange), "Values need to be below 0 and 255");
        }
    }
}