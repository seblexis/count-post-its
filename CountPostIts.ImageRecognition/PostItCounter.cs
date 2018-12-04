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
        public static int Count(string filename, Dictionary<string,int> RGB)
        {
            Bitmap image = (Bitmap)Bitmap.FromFile(filename);

            ColorFiltering colorFilter = new ColorFiltering();

            //keep colours in this range
            

            BlobCounter blobCounter = new BlobCounter();
            blobCounter.FilterBlobs = true;
            blobCounter.MinHeight = 5;
            blobCounter.MinWidth = 5;

            blobCounter.ProcessImage(image);
            Blob[] blobs = blobCounter.GetObjectsInformation();
            return 6;
        }

        public static int[] RGBRange(int rgb)
        {
            int[] range = new int[2];
            // var result = x > y ? "x is greater than y" : "x is less than or eq
            range[0] = rgb < 25 ? 0 : rgb - 25;
            range[1] = rgb > 230 ? 255 : rgb + 25;
            return range;
        }
    }
}
