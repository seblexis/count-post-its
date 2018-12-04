using Accord.Imaging.Filters;
using Accord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;

namespace CountPostIts.ImageRecognition
{
    public class ColorFilteringWrapper : IColorFiltering
    {
        
        public ColorFilteringWrapper()
        {
            ColorFilter = new ColorFiltering();
        }
        public ColorFiltering ColorFilter { get; set; }

        public void AddRedValue(int first, int last)
        {
            ColorFilter.Red = new IntRange(first, last);
        }
        public void AddBlueValue(int first, int last)
        {
            ColorFilter.Blue = new IntRange(first, last);
        }
        public void AddGreenValue(int first, int last)
        {
            ColorFilter.Green = new IntRange(first, last);
        }

        //public void ApplyToImage(BitmapData image)
        //{
        //    ColorFilter.ApplyInPlace(image);
        //}

    }
}
