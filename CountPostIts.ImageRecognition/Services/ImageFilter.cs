using System.Drawing;
using CountPostIts.ImageRecognition.Entities;

namespace CountPostIts.ImageRecognition.Services
{
    public class ImageFilter
    {
        private readonly IColorFilteringWrapper _colorFilteringWrapper;

        public ImageFilter(IColorFilteringWrapper colorFilteringWrapper)
        {
            _colorFilteringWrapper = colorFilteringWrapper;
        }

        public Bitmap GetFilteredImage(Bitmap image, IColorRange rgbRange)
        {
            SetFilters(rgbRange);
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
            _colorFilteringWrapper.OwnRed(rmin, rmax);
        }

        private void SetFilterGreen(int gmin, int gmax)
        {
            _colorFilteringWrapper.OwnGreen(gmin, gmax);
        }

        private void SetFilterBlue(int bmin, int bmax)
        {
            _colorFilteringWrapper.OwnBlue(bmin, bmax);
        }
    }
}