using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountPostIts.ImageRecognition
{
    public class ImageFilter
    {
        private IColorFilteringWrapper ColorFilteringWrapper;

        public ImageFilter(IColorFilteringWrapper colorFilteringWrapper)
        {
            this.ColorFilteringWrapper = colorFilteringWrapper;
        }

        public Bitmap GetFilteredImage(Bitmap image, Dictionary<String, int[]> rgbRange)
        {
            try
            {
                SetFilters(rgbRange);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
                throw;
            }
            ColorFilteringWrapper.OwnApplyInPlace(image);
            return image;
        }

        private void SetFilters(Dictionary<string, int[]> rgb)
        {
                SetFilterRed(rgb["R"][0], rgb["R"][1]);
                SetFilterGreen(rgb["G"][0], rgb["G"][1]);
                SetFilterBlue(rgb["B"][0], rgb["B"][1]);          
        }
        private void SetFilterRed(int rmin, int rmax)
        {
            CheckRanges(rmin, rmax);
            ColorFilteringWrapper.OwnRed(rmin, rmax);
        }

        private void SetFilterGreen(int gmin, int gmax)
        {
            CheckRanges(gmin, gmax);
            ColorFilteringWrapper.OwnGreen(gmin, gmax);
        }
        private void SetFilterBlue(int bmin, int bmax)
        {
            CheckRanges(bmin, bmax);
            ColorFilteringWrapper.OwnBlue(bmin, bmax);
        }

        private void CheckRanges(int min, int max)
        {
            if (min < 0 || min > 255)
            {
                throw new ArgumentException("min needs to be between 0 and 255");
            }
            else if (max < 0 || max > 255)
            {
                throw new ArgumentException("max needs to be between 0 and 255");
            }
            else if (min > max)
            {
                throw new ArgumentException("min cannot be bigger than max");
            } 
        }
    }
}
