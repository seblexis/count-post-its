using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Accord;
using Accord.Imaging;
using Accord.Imaging.Filters;
using Accord.Math.Geometry;


namespace CountPostIts.ImageRecognition
{
    public class PostItCounter
    {
        public static int Count(string filename, Dictionary<string,int> rgb)
        {
            Bitmap image = (Bitmap)Bitmap.FromFile(filename);


            //keep colours in this range

            IColorFiltering colorFilteringWrapper = new ColorFilteringWrapper();
            ImageColouring imageColouring = new ImageColouring();
            imageColouring.setFilters(rgb, colorFilteringWrapper);
            BlobCounter blobCounter = new BlobCounter();
            blobCounter.FilterBlobs = true;
            blobCounter.MinHeight = 5;
            blobCounter.MinWidth = 5;

            blobCounter.ProcessImage(image);
            Blob[] blobs = blobCounter.GetObjectsInformation();
            return 6;
        }
    }
}
