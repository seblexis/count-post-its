namespace CountPostIts.ImageRecognition
{
    public interface IColorFilteringWrapper
    {
        void OwnRed(int first, int last);
        void OwnBlue(int first, int last);
        void OwnGreen(int first, int last);
        void OwnApplyInPlace(object image);
    }
}