using System.Drawing;
using Accord.Imaging;

namespace CountPostIts.ImageRecognition.Services
{
    public class BlobsDetector
    {
        private readonly IBlobCounterWrapper _blobCounterWrapper;

        public BlobsDetector(IBlobCounterWrapper blobCounterWrapper)
        {
            _blobCounterWrapper = blobCounterWrapper;
        }

        public Blob[] FindBlobs(Bitmap image)
        {
            int minDimension = _blobCounterWrapper.CalculateMinDimension(image);
            _blobCounterWrapper.OwnFilterBlobs(true);
            _blobCounterWrapper.OwnMinHeight(minDimension);
            _blobCounterWrapper.OwnMinWidth(minDimension);
            _blobCounterWrapper.OwnProcessImage(image);
            return _blobCounterWrapper.OwnGetObjectsInformation();
        }
    }
}
