using System.Collections.Generic;

namespace CountPostIts.ImageRecognition
{
    public class ColourRanges
    {
        public Dictionary<Colours, Dictionary<string, int[]>> RGB { get; set; }

        private IColourRange _colourRange;

        private int[] greenR = { 80, 130 };
        private int[] greenG = { 100, 130 };
        private int[] greenB = { 40, 100 };
    
        private int[] yellowR = { 130, 195 };
        private int[] yellowG = { 115, 180 };
        private int[] yellowB = { 20, 90 };

        private int[] blueR = { 10, 80 };
        private int[] blueG = { 50, 130 };
        private int[] blueB = { 60, 150 };

        private int[] orangeR = { 160, 210 };
        private int[] orangeG = { 75, 125 };
        private int[] orangeB = { 0, 40 };

        private int[] pinkR = { 160, 240 };
        private int[] pinkG = { 35, 130 };
        private int[] pinkB = { 40, 110 };

        private int[] purpleR = { 170, 230 };
        private int[] purpleG = { 130, 180 };
        private int[] purpleB = { 130, 170 };

        public ColourRanges(IColourRange colourRange)
        {
            _colourRange = colourRange;
            this.RGB = CreateList();
        }

        private Dictionary<Colours, Dictionary<string, int[]>> CreateList()
        {
            Dictionary<Colours, Dictionary<string, int[]>> RGB = new Dictionary<Colours, Dictionary<string, int[]>>();
            Dictionary<string, int[]> greenRGB = SetRanges(greenR, greenG, greenB);
            Dictionary<string, int[]> yellowRGB = SetRanges(yellowR, yellowG, yellowB);
            Dictionary<string, int[]> blueRGB = SetRanges(blueR, blueG, blueB);
            Dictionary<string, int[]> orangeRGB = SetRanges(orangeR, orangeG, orangeB);
            Dictionary<string, int[]> pinkRGB = SetRanges(pinkR, pinkG, pinkB);
            Dictionary<string, int[]> purpleRGB = SetRanges(purpleR, purpleG, purpleB);

            RGB.Add(Colours.Green, greenRGB);
            RGB.Add(Colours.Yellow, yellowRGB);
            RGB.Add(Colours.Blue, blueRGB);
            RGB.Add(Colours.Orange, orangeRGB);
            RGB.Add(Colours.Pink, pinkRGB);
            RGB.Add(Colours.Purple, purpleRGB);

            return RGB;
        }

        private Dictionary<string, int[]> SetRanges(int[] rRange, int[] gRange, int[] bRange)
        {
            Dictionary<string, int[]> rgbRanges = new Dictionary<string, int[]>
            {
                {"R", rRange },
                {"G", gRange },
                {"B" , bRange}
            };

            return rgbRanges;
        }
    }
}
