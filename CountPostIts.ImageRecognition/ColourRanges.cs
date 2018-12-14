using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountPostIts.ImageRecognition
{
    public class ColourRanges
    {
        public Dictionary<Colours, Dictionary<string, int[]>> RGB { get; set; }
        private int[] greenR = { 80, 110 };
        private int[] greenG = { 100, 130 };
        private int[] greenB = { 40, 70 };
    
        private int[] yellowR = { 130, 160 };
        private int[] yellowG = { 115, 145 };
        private int[] yellowB = { 20, 50 };

        private int[] blueR = { 10, 40 };
        private int[] blueG = { 100, 130 };
        private int[] blueB = { 120, 150 };

        private int[] orangeR = { 160, 210 };
        private int[] orangeG = { 75, 125 };
        private int[] orangeB = { 0, 40 };

        public ColourRanges()
        {
            this.RGB = CreateList();
        }

        private Dictionary<string, int[]> SetRanges(int[] rRange, int[] gRange, int [] bRange)
        {
            Dictionary<string, int[]> rgbRanges = new Dictionary<string, int[]>
            {
                {"R", rRange },
                {"G", gRange },
                {"B" , bRange}
            };

            return rgbRanges;
        }

        private Dictionary<Colours, Dictionary<string, int[]>> CreateList()
        {
            Dictionary<Colours, Dictionary<string, int[]>> RGB = new Dictionary<Colours, Dictionary<string, int[]>>();
            Dictionary<string, int[]> greenRGB = SetRanges(greenR, greenG, greenB);
            Dictionary<string, int[]> yellowRGB = SetRanges(yellowR, yellowG, yellowB);
            Dictionary<string, int[]> blueRGB = SetRanges(blueR, blueG, blueB);
            Dictionary<string, int[]> orangeRGB = SetRanges(orangeR, orangeG, orangeB);

            RGB.Add(Colours.Green, greenRGB);
            RGB.Add(Colours.Yellow, yellowRGB);
            RGB.Add(Colours.Blue, blueRGB);
            RGB.Add(Colours.Orange, orangeRGB);
            return RGB;
        }
    }
}
