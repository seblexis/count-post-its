using Accord.Imaging.Filters;
using System.Drawing;
using System.Drawing.Imaging;

namespace CountPostIts.ImageRecognition
{
    public interface IColorFiltering
    {
        ColorFiltering ColorFilter { get; set; }
        void AddRedValue(int first, int last);
        void AddBlueValue(int first, int last);
        void AddGreenValue(int first, int last);
        void ApplyToImage(object image);
    }
}