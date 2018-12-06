using Accord;
using Accord.Imaging;
using System.Collections.Generic;

namespace CountPostIts.ImageRecognition
{
    public interface IBlobCounterWrapper
    {

        BlobCounter BlobCounter { get; set; }

        void OwnFilterBlobs (bool filterBool);
        void OwnMinHeight(int height);
        void OwnMinWidth(int width);
        Blob[] OwnGetObjectsInformation();
        void OwnProcessImage(object image);
        List<IntPoint> OwnGetBlobsEdgePoints(Blob blob);
    }
}