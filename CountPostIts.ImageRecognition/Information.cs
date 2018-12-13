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
using System.IO;

namespace CountPostIts.ImageRecognition
{
    public class Information
    {
        private readonly int _rgbRange = 35;
        public IBlobCounterWrapper BlobCounterWrapper { get; set; }
        public ISimpleShapeCheckerWrapper SimpleShapeCheckerWrapper { get; set; }
        public IColorFilteringWrapper ColorFilteringWrapper { get; set; }

        public Information(IBlobCounterWrapper blobCounterWrapper, ISimpleShapeCheckerWrapper simpleShapeCheckerWrapper, IColorFilteringWrapper colorFilteringWrapper)
        {
            this.BlobCounterWrapper = blobCounterWrapper;
            this.SimpleShapeCheckerWrapper = simpleShapeCheckerWrapper;
            this.ColorFilteringWrapper = colorFilteringWrapper;
        }

        public Information()
        {
            this.BlobCounterWrapper = new BlobCounterWrapper();
            this.SimpleShapeCheckerWrapper = new SimpleShapeCheckerWrapper();
            this.ColorFilteringWrapper = new ColorFilteringWrapper();
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



        //TODO: Add proper resultPath
        public void SaveHighlightedPostItNotes(string filename, Dictionary<string, int> rgb)
        {
            Bitmap image = (Bitmap)Bitmap.FromFile(filename);
            FilterImage(image, rgb);
            Blob[] blobs = BlobsInImage(image);
            Bitmap imageHighlighted = DrawQuadrilaterals(blobs, image);
            string resultPath = "result.png";
            imageHighlighted.Save(resultPath);
        }





        public Blob[] BlobsInImage(Bitmap image)
        {
            BlobCounterWrapper.OwnFilterBlobs(true);
            BlobCounterWrapper.OwnMinHeight(30);
            BlobCounterWrapper.OwnMinWidth(30);
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
            interval[0] = (number - _rgbRange < 0) ? 0 : number - _rgbRange;
            interval[1] = (number + _rgbRange > 255) ? 255 : number + _rgbRange;
            return interval;
        }       
    }
}
