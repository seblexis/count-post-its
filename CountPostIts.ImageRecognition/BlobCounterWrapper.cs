using Accord;
using Accord.Imaging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountPostIts.ImageRecognition
{
    public class BlobCounterWrapper : IBlobCounterWrapper
    {
        public BlobCounter BlobCounter { get; set; }
        public BlobCounterWrapper()
        {
            this.BlobCounter = new BlobCounter();
        }

        public void OwnFilterBlobs(bool filterBool)
        {
            BlobCounter.FilterBlobs = filterBool;
        }

        public void OwnMinHeight(int height)
        {
            BlobCounter.MinHeight = height;
        }

        public void OwnMinWidth(int width)
        {
            BlobCounter.MinWidth = width;
        }

        public void OwnProcessImage(object image)
        {
            BlobCounter.ProcessImage((Bitmap)image);
        }

        public Blob[] OwnGetObjectsInformation()
        {
            return BlobCounter.GetObjectsInformation();
        }

        public List<IntPoint> OwnGetBlobsEdgePoints(Blob blob)
        {
            return BlobCounter.GetBlobsEdgePoints(blob);
        }
    }
}
