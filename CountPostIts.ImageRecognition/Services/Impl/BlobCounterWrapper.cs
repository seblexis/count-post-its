using System.Collections.Generic;
using System.Drawing;
using Accord;
using Accord.Imaging;

namespace CountPostIts.ImageRecognition.Services.Impl
{
    public class BlobCounterWrapper : IBlobCounterWrapper
    {
        private readonly BlobCounter _blobCounter;

        public BlobCounterWrapper()
        {
            _blobCounter = new BlobCounter();
        }

        public void OwnFilterBlobs(bool filterBool)
        {
            _blobCounter.FilterBlobs = filterBool;
        }

        public void OwnMinHeight(int height)
        {
            _blobCounter.MinHeight = height;
        }

        public void OwnMinWidth(int width)
        {
            _blobCounter.MinWidth = width;
        }

        public void OwnProcessImage(object image)
        {
            _blobCounter.ProcessImage((Bitmap) image);
        }

        public Blob[] OwnGetObjectsInformation()
        {
            return _blobCounter.GetObjectsInformation();
        }

        public List<IntPoint> OwnGetBlobsEdgePoints(Blob blob)
        {
            return _blobCounter.GetBlobsEdgePoints(blob);
        }

        public int CalculateMinDimension(Bitmap image)
        {
            if (image.Width > image.Height) return image.Width / 50;
            return image.Height / 50;
        }
    }
}