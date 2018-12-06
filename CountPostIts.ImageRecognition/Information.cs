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
        public ISimpleShapeCheckerWrapper SimpleShapeCheckerWrapper { get; set; }
        public IColorFilteringWrapper ColorFilteringWrapper { get; set; }

        public Information(IBlobCounterWrapper blobCounterWrapper, ISimpleShapeCheckerWrapper simpleShapeCheckerWrapper, IColorFilteringWrapper colorFilteringWrapper)
        {
            this.BlobCounterWrapper = blobCounterWrapper;
            this.SimpleShapeCheckerWrapper = simpleShapeCheckerWrapper;
            this.ColorFilteringWrapper = colorFilteringWrapper;
        }

        public void FilterImage(Bitmap image, Dictionary<string, int> rgb)
        {
            setFilters(rgb);
            ColorFilteringWrapper.OwnApplyInPlace(image);
        }

        public int CountPostItNotes(string filename, Dictionary<string, int> rgb)
        {
            Bitmap image = (Bitmap)Bitmap.FromFile(filename);
            FilterImage(image, rgb);
            Blob[] blobs = BlobsInImage(image);
            return CountQuadrilaterals(blobs);
        }

        public void SaveHighlightedPostItNotes(string filename, Dictionary<string, int> rgb)
        {
            Bitmap image = (Bitmap)Bitmap.FromFile(filename);
            FilterImage(image, rgb);
            Blob[] blobs = BlobsInImage(image);
            Bitmap imageHighlighted = DrawQuadrilaterals(blobs, image);
            imageHighlighted.Save("result.png");
        }



        public Blob[] BlobsInImage(Bitmap image)
        {
            BlobCounterWrapper.OwnFilterBlobs(true);
            BlobCounterWrapper.OwnMinHeight(5);
            BlobCounterWrapper.OwnMinWidth(5);
            BlobCounterWrapper.OwnProcessImage(image);
            return BlobCounterWrapper.OwnGetObjectsInformation();
        }

        public int CountQuadrilaterals(Blob[] blobs)
        {
            int counter = 0;
            for (int i = 0; i < blobs.Length; i++)
            {
                List<IntPoint> edgePoints = BlobCounterWrapper.OwnGetBlobsEdgePoints(blobs[i]);
                List<IntPoint> cornerPoints;
                if (SimpleShapeCheckerWrapper.OwnIsQuadrilateral(edgePoints, out cornerPoints))
                {
                    counter++;
                }
            }
            return counter;
        }

        public Bitmap DrawQuadrilaterals(Blob[] blobs, Bitmap image)
        {
            for (int i = 0; i < blobs.Length; i++)
            {
                List<IntPoint> edgePoints = BlobCounterWrapper.OwnGetBlobsEdgePoints(blobs[i]);
                List<IntPoint> cornerPoints;
                if (SimpleShapeCheckerWrapper.OwnIsQuadrilateral(edgePoints, out cornerPoints))
                {
                    List<System.Drawing.Point> Points = new List<System.Drawing.Point>();
                    foreach (var point in cornerPoints)
                    {
                        Points.Add(new System.Drawing.Point(point.X, point.Y));
                    }

                    Graphics g = Graphics.FromImage(image);
                    g.DrawPolygon(new Pen(Color.Red, 5.0f), Points.ToArray());
                }
            }
            return image;
        }

        public void setFilters(Dictionary<string, int> rgb)
        {
            int red = rgb["R"];
            ColorFilteringWrapper.OwnRed(FindRGBInterval(red)[0], FindRGBInterval(red)[1]);

            int green = rgb["G"];
            ColorFilteringWrapper.OwnGreen(FindRGBInterval(green)[0], FindRGBInterval(green)[1]);

            int blue = rgb["B"];
            ColorFilteringWrapper.OwnBlue(FindRGBInterval(blue)[0], FindRGBInterval(blue)[1]);

        }

        public int[] FindRGBInterval(int number)
        {
            int[] interval = new int[2];
            interval[0] = (number - 25 < 0) ? 0 : number - 25;
            interval[1] = (number + 25 > 255) ? 255 : number + 25;
            return interval;
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
