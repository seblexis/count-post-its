using Accord;
using Accord.Imaging.Filters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountPostIts.ImageRecognition
{
    public class ColorFilteringWrapper : IColorFilteringWrapper
    {
        public ColorFiltering ColorFilter { get; set; }

        public ColorFilteringWrapper()
        {
            this.ColorFilter = new ColorFiltering();
        }

        public void OwnApplyInPlace(object image)
        {
            ColorFilter.ApplyInPlace((Bitmap)image);
        }

        public void OwnRed(int first, int last)
        {
            ColorFilter.Red = new IntRange(first, last);

        }

        public void OwnBlue(int first, int last)
        {
            ColorFilter.Blue = new IntRange(first, last);
        }


        public void OwnGreen(int first, int last)
        {
            ColorFilter.Green = new IntRange(first, last);
        }
    }
}
