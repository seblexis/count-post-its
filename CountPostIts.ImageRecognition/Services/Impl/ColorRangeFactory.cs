namespace CountPostIts.ImageRecognition
{
    class ColorRangeFactory : IColorRangeFactory
    {
        public IColorRange Create()
        {
            return new ColorRange();
        }
    }
}
