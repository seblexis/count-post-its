using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Threading.Tasks;

using Accord;
using Accord.Imaging;
using Accord.Imaging.Filters;
using Accord.Math.Geometry;

namespace CountPostIts.ImageRecognition
{
    public class Information
    {
        public IBlobCounterWrapper BlobCounterWrapper { get; set; }
        public Information(IBlobCounterWrapper blobCounterWrapper)
        {
            this.BlobCounterWrapper = blobCounterWrapper;
        }
        public bool HasQuadrilateral(string filename)
        {
            return true;
        }
        public Blob[] BlobsInImage(Bitmap image)
        {
            BlobCounterWrapper.OwnFilterBlobs(true);
            BlobCounterWrapper.OwnMinHeight(10);
            BlobCounterWrapper.OwnMinWidth(10);
            BlobCounterWrapper.OwnProcessImage(image);
            return BlobCounterWrapper.OwnGetObjectsInformation();
        }


        //public static void Count()
        //{
        //    string fileName = "test1.jpg";
        //    Bitmap image = (Bitmap)Bitmap.FromFile(fileName);


        //    ColorFiltering colorFilter = new ColorFiltering();
        //    //keep colours in this range
        //    colorFilter.Red = new IntRange(195, 245);

        //    colorFilter.Green = new IntRange(230, 255);

        //    colorFilter.Blue = new IntRange(120, 170);


        //    colorFilter.ApplyInPlace(image);

        //    BlobCounter blobCounter = new BlobCounter();

        //    blobCounter.FilterBlobs = true;
        //    blobCounter.MinHeight = 10;
        //    blobCounter.MinWidth = 10;

        //    blobCounter.ProcessImage(image);
        //    Blob[] blobs = blobCounter.GetObjectsInformation();

        //    SimpleShapeChecker shapeChecker = new SimpleShapeChecker();
        //    image.Save("result.png");

        //    int counter = 0;
        //    for (int i = 0; i < blobs.Length; i++)
        //    {
        //        List<IntPoint> edgePoints = blobCounter.GetBlobsEdgePoints(blobs[i]);
        //        List<IntPoint> cornerPoints;
        //        if (shapeChecker.IsQuadrilateral(edgePoints, out cornerPoints))
        //        {
        //            List<System.Drawing.Point> Points = new List<System.Drawing.Point>();
        //            foreach (var point in cornerPoints)
        //            {
        //                Points.Add(new System.Drawing.Point(point.X, point.Y));
        //            }

        //            Graphics g = Graphics.FromImage(image);
        //            g.DrawPolygon(new Pen(Color.Red, 5.0f), Points.ToArray());

        //            image.Save("result.png");
        //            counter++;
        //        }
        //    }
        //}
    }
}
