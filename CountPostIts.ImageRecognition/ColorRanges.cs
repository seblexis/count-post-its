using System.Collections.Generic;

namespace CountPostIts.ImageRecognition
{
    public class ColorRanges
    {
        public Dictionary<Colors, IColorRange> RGB { get; set; }

        private readonly IColorRangeFactory _colorRangeFactory;

        public ColorRanges(IColorRangeFactory colorRangeFactory)
        {
            _colorRangeFactory = colorRangeFactory;
            this.RGB = CreateList();
        }

        private Dictionary<Colors, IColorRange> CreateList()
        {
            IColorRange greenRanges = _colorRangeFactory.Create();
            greenRanges.RangeRed = new int[] { 80, 130 };
            greenRanges.RangeGreen = new int[] { 100, 130 };
            greenRanges.RangeBlue = new int[] { 40, 100 };

            IColorRange yellowRanges = _colorRangeFactory.Create();
            yellowRanges.RangeRed = new int[] { 130, 193 };
            yellowRanges.RangeGreen = new int[] { 115, 180 };
            yellowRanges.RangeBlue = new int[] { 20, 90 };

            IColorRange blueRanges = _colorRangeFactory.Create();
            blueRanges.RangeRed = new int[] { 10, 80 };
            blueRanges.RangeGreen = new int[] { 50, 130 };
            blueRanges.RangeBlue = new int[] { 60, 150 };

            IColorRange orangeRanges = _colorRangeFactory.Create();
            orangeRanges.RangeRed = new int[] { 160, 210 };
            orangeRanges.RangeGreen = new int[] { 75, 125 };
            orangeRanges.RangeBlue = new int[] { 0, 40 };

            IColorRange pinkRanges = _colorRangeFactory.Create();
            pinkRanges.RangeRed = new int[] { 160, 240 };
            pinkRanges.RangeGreen = new int[] { 35, 130 };
            pinkRanges.RangeBlue = new int[] { 40, 110 };

            IColorRange purpleRanges = _colorRangeFactory.Create();
            purpleRanges.RangeRed = new int[] { 170, 230 };
            purpleRanges.RangeGreen = new int[] { 130, 180 };
            purpleRanges.RangeBlue = new int[] { 130, 170 };

            var RGB = new Dictionary<Colors, IColorRange>
            {
                { Colors.Green, greenRanges },
                { Colors.Yellow, yellowRanges },
                { Colors.Blue, blueRanges },
                { Colors.Orange, orangeRanges },
                { Colors.Pink, pinkRanges },
                { Colors.Purple, purpleRanges }
            };

            return RGB;
        }

    }
}
