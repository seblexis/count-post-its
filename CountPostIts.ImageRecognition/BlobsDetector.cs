using Accord.Imaging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountPostIts.ImageRecognition
{
    public class BlobsDetector
    {
        private IBlobCounterWrapper BlobCounterWrapper;

        public BlobsDetector(IBlobCounterWrapper blobCounterWrapper)
        {
            this.BlobCounterWrapper = blobCounterWrapper;
        }

        public Blob[] findBlobs(Bitmap image)
        {
            int minDimension = BlobCounterWrapper.CalculateMinDimension(image);
            BlobCounterWrapper.OwnFilterBlobs(true);
            BlobCounterWrapper.OwnMinHeight(minDimension);
            BlobCounterWrapper.OwnMinWidth(minDimension);
            BlobCounterWrapper.OwnProcessImage(image);
            return BlobCounterWrapper.OwnGetObjectsInformation();
        }
    }
}
