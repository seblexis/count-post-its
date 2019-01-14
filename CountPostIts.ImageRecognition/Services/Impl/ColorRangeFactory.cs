using CountPostIts.ImageRecognition.Entities;
using CountPostIts.ImageRecognition.Entities.Impl;

namespace CountPostIts.ImageRecognition.Services.Impl
{
    public class ColorRangeFactory : IColorRangeFactory
    {
        public IColorRange Create()
        {
            return new ColorRange();
        }
    }
}