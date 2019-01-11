using System.Collections.Generic;
using CountPostIts.ImageRecognition.Services;

namespace CountPostIts.ImageRecognition.Entities
{
    public class ColorRanges
    {
        public Dictionary<Colors, IColorRange> Rgb { get; set; }

        private readonly IColorRangeFactory _colorRangeFactory;

        public ColorRanges(IColorRangeFactory colorRangeFactory)
        {
            _colorRangeFactory = colorRangeFactory;
            Rgb = CreateList();
        }

        private Dictionary<Colors, IColorRange> CreateList()
        {
            IColorRange greenRanges = _colorRangeFactory.Create();
            greenRanges.RangeRed = new[] { 80, 130 };
            greenRanges.RangeGreen = new[] { 100, 130 };
            greenRanges.RangeBlue = new[] { 40, 100 };

            IColorRange yellowRanges = _colorRangeFactory.Create();
            yellowRanges.RangeRed = new[] { 130, 193 };
            yellowRanges.RangeGreen = new[] { 115, 180 };
            yellowRanges.RangeBlue = new[] { 20, 90 };

            IColorRange blueRanges = _colorRangeFactory.Create();
            blueRanges.RangeRed = new[] { 10, 80 };
            blueRanges.RangeGreen = new[] { 50, 130 };
            blueRanges.RangeBlue = new[] { 60, 150 };

            IColorRange orangeRanges = _colorRangeFactory.Create();
            orangeRanges.RangeRed = new[] { 160, 210 };
            orangeRanges.RangeGreen = new[] { 75, 125 };
            orangeRanges.RangeBlue = new[] { 0, 40 };

            IColorRange pinkRanges = _colorRangeFactory.Create();
            pinkRanges.RangeRed = new[] { 160, 240 };
            pinkRanges.RangeGreen = new[] { 35, 130 };
            pinkRanges.RangeBlue = new[] { 40, 110 };

            IColorRange purpleRanges = _colorRangeFactory.Create();
            purpleRanges.RangeRed = new[] { 170, 230 };
            purpleRanges.RangeGreen = new[] { 130, 180 };
            purpleRanges.RangeBlue = new[] { 130, 170 };

            return new Dictionary<Colors, IColorRange>
            {
                { Colors.Green, greenRanges },
                { Colors.Yellow, yellowRanges },
                { Colors.Blue, blueRanges },
                { Colors.Orange, orangeRanges },
                { Colors.Pink, pinkRanges },
                { Colors.Purple, purpleRanges }
            };
        }
    }
}
