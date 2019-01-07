using System.Collections.Generic;

namespace CountPostIts.ImageRecognition
{
    public class ColourRanges
    {
        public Dictionary<Colours, IColourRange> RGB { get; set; }

        private IColourRangeFactory _colourRangeFactory;

        public ColourRanges(IColourRangeFactory colourRangeFactory)
        {
            _colourRangeFactory = colourRangeFactory;
            this.RGB = CreateList();
        }

        private Dictionary<Colours, IColourRange> CreateList()
        {
            IColourRange greenRanges = _colourRangeFactory.Create();
            greenRanges.RangeRed = new int[] { 80, 130 };
            greenRanges.RangeGreen = new int[] { 100, 130 };
            greenRanges.RangeBlue = new int[] { 40, 100 };

            IColourRange yellowRanges = _colourRangeFactory.Create();
            yellowRanges.RangeRed = new int[] { 130, 193 };
            yellowRanges.RangeGreen = new int[] { 115, 180 };
            yellowRanges.RangeBlue = new int[] { 20, 90 };

            IColourRange blueRanges = _colourRangeFactory.Create();
            blueRanges.RangeRed = new int[] { 10, 80 };
            blueRanges.RangeGreen = new int[] { 50, 130 };
            blueRanges.RangeBlue = new int[] { 60, 150 };

            IColourRange orangeRanges = _colourRangeFactory.Create();
            orangeRanges.RangeRed = new int[] { 160, 210 };
            orangeRanges.RangeGreen = new int[] { 75, 125 };
            orangeRanges.RangeBlue = new int[] { 0, 40 };

            IColourRange pinkRanges = _colourRangeFactory.Create();
            pinkRanges.RangeRed = new int[] { 160, 240 };
            pinkRanges.RangeGreen = new int[] { 35, 130 };
            pinkRanges.RangeBlue = new int[] { 40, 110 };

            IColourRange purpleRanges = _colourRangeFactory.Create();
            purpleRanges.RangeRed = new int[] { 170, 230 };
            purpleRanges.RangeGreen = new int[] { 130, 180 };
            purpleRanges.RangeBlue = new int[] { 130, 170 };

            Dictionary<Colours, IColourRange> RGB = new Dictionary<Colours, IColourRange>
            {
                { Colours.Green, greenRanges },
                { Colours.Yellow, yellowRanges },
                { Colours.Blue, blueRanges },
                { Colours.Orange, orangeRanges },
                { Colours.Pink, pinkRanges },
                { Colours.Purple, purpleRanges }
            };

            return RGB;
        }

    }
}
