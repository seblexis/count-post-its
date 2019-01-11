using System.Drawing;
using Accord;
using Accord.Imaging.Filters;

namespace CountPostIts.ImageRecognition.Services.Impl
{
    public class ColorFilteringWrapper : IColorFilteringWrapper
    {
        private readonly ColorFiltering _colorFilter;

        public ColorFilteringWrapper()
        {
            _colorFilter = new ColorFiltering();
        }

        public void OwnApplyInPlace(object image)
        {
            _colorFilter.ApplyInPlace((Bitmap)image);
        }

        public void OwnRed(int first, int last)
        {
            _colorFilter.Red = new IntRange(first, last);

        }

        public void OwnBlue(int first, int last)
        {
            _colorFilter.Blue = new IntRange(first, last);
        }

        public void OwnGreen(int first, int last)
        {
            _colorFilter.Green = new IntRange(first, last);
        }
    }
}
