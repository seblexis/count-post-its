using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountPostIts.ImageRecognition
{
    public class ColourRanges
    {
        public Dictionary<Colours, int[]> RGB { get; set; }
        private int[] greenRGBRange = { 80, 110, 100, 130, 40, 70 };
        private int[] yellowRGBRange = { 130, 160, 115, 145, 20, 50 };
        private int[] blueRGBRange = { 10, 40, 100, 130, 120, 150 };
        private int[] orangeRGBRange = { 160, 210, 75, 125, 0, 40 };

        public ColourRanges()
        {
            this.RGB = setRanges();
        }

        private Dictionary<Colours, int[]> setRanges()
        {
            Dictionary<Colours, int[]> RGB = new Dictionary<Colours, int[]>();
            RGB.Add(Colours.Green, greenRGBRange);
            RGB.Add(Colours.Yellow, yellowRGBRange);
            RGB.Add(Colours.Blue, blueRGBRange);
            RGB.Add(Colours.Orange, orangeRGBRange);
            return RGB;
        }
    }
}
