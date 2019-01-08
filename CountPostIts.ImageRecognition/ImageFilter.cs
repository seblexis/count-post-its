using System;
using System.Drawing;

namespace CountPostIts.ImageRecognition
{
    public class ImageFilter
    {
        private IColorFilteringWrapper _colorFilteringWrapper;

        public ImageFilter(IColorFilteringWrapper colorFilteringWrapper)
        {
            _colorFilteringWrapper = colorFilteringWrapper;
        }

        public Bitmap GetFilteredImage(Bitmap image, IColorRange rgbRange)
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
            _colorFilteringWrapper.OwnApplyInPlace(image);
            return image;
        }

        private void SetFilters(IColorRange rgbRange)
        {
                SetFilterRed(rgbRange.RangeRed[0], rgbRange.RangeRed[1]);
                SetFilterGreen(rgbRange.RangeGreen[0], rgbRange.RangeGreen[1]);
                SetFilterBlue(rgbRange.RangeBlue[0], rgbRange.RangeBlue[1]);          
        }
        private void SetFilterRed(int rmin, int rmax)
        {
            CheckRanges(rmin, rmax);
            _colorFilteringWrapper.OwnRed(rmin, rmax);
        }

        private void SetFilterGreen(int gmin, int gmax)
        {
            CheckRanges(gmin, gmax);
            _colorFilteringWrapper.OwnGreen(gmin, gmax);
        }
        private void SetFilterBlue(int bmin, int bmax)
        {
            CheckRanges(bmin, bmax);
            _colorFilteringWrapper.OwnBlue(bmin, bmax);
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
