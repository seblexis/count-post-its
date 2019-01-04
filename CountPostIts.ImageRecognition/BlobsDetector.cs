using Accord.Imaging;
using System.Drawing;

namespace CountPostIts.ImageRecognition
{
    public class BlobsDetector
    {
        private IBlobCounterWrapper _blobCounterWrapper;

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
