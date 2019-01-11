using System.Collections.Generic;
using System.Drawing;
using Accord;
using Accord.Imaging;

namespace CountPostIts.ImageRecognition.Services
{
    public interface IBlobCounterWrapper
    {
        void OwnFilterBlobs(bool filterBool);
        void OwnMinHeight(int height);
        void OwnMinWidth(int width);
        Blob[] OwnGetObjectsInformation();
        void OwnProcessImage(object image);
        List<IntPoint> OwnGetBlobsEdgePoints(Blob blob);
        int CalculateMinDimension(Bitmap image);
    }
}