using Accord.Imaging.Filters;

namespace CountPostIts.ImageRecognition
{
    public interface IColorFilteringWrapper
    {
        ColorFiltering ColorFilter { get; set; }
        void OwnRed(int first, int last);
        void OwnBlue(int first, int last);
        void OwnGreen(int first, int last);
        void OwnApplyInPlace(object image);
    }
}