using Accord.Imaging.Filters;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountPostIts.ImageRecognition
{
    public class ImageColouring
    {
        public void setFilters(Dictionary<string, int> rgb, IColorFiltering colorFilterWrapper)
        {
            int[] rangeRed = RGBRange(rgb["R"]);
            int[] rangeGreen = RGBRange(rgb["G"]);
            int[] rangeBlue = RGBRange(rgb["B"]);

            colorFilterWrapper.AddRedValue(rangeRed[0], rangeRed[1]);
            colorFilterWrapper.AddGreenValue(rangeGreen[0], rangeGreen[1]);
            colorFilterWrapper.AddBlueValue(rangeBlue[0], rangeBlue[1]);

        }

        public int[] RGBRange(int rgb)
        {
            int[] range = new int[2];
            range[0] = rgb < 25 ? 0 : rgb - 25;
            range[1] = rgb > 230 ? 255 : rgb + 25;
            return range;
        }

        //public blackBG(colorFilterWrapper, image)
        //{

        //}

        public ImageColouring()
        {
        }
    }
}
