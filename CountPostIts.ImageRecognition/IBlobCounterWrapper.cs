using Accord.Imaging;

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

        //    BlobCounter blobCounter = new BlobCounter();

        //    blobCounter.FilterBlobs = true;
        //    blobCounter.MinHeight = 10;
        //    blobCounter.MinWidth = 10;

        //    blobCounter.ProcessImage(image);
    }
}