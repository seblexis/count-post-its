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

        public int CountPostItNotes(string filename, Dictionary<string, int[]> rgbRange)
        {
            Bitmap image = (Bitmap)Bitmap.FromFile(filename);
            ImageFilter imageFilter = new ImageFilter(ColorFilteringWrapper);
            Bitmap filteredImage = imageFilter.GetFilteredImage(image, rgbRange);
            Blob[] blobs = BlobsInImage(filteredImage);
            return CountQuadrilaterals(blobs);
        }


        public Dictionary<string, int> CountAllColours(string filename)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            ColourRanges colourRanges = new ColourRanges();
            foreach (KeyValuePair<Colours, Dictionary<string, int[]>> colourEntry in colourRanges.RGB)
            {
                int count = CountPostItNotes(filename, colourEntry.Value);
                result.Add(Enum.GetName(typeof(Colours), colourEntry.Key), count);
                Console.WriteLine(Enum.GetName(typeof(Colours), colourEntry.Key));
            }
            return result;
        }

        //TODO: Add proper resultPath
        public void SaveHighlightedPostItNotes(string filename, Dictionary<string, int[]> rgb)
        {
            Bitmap image = (Bitmap)Bitmap.FromFile(filename);
            //FilterImage(image, rgb);
            Blob[] blobs = BlobsInImage(image);
            Bitmap imageHighlighted = DrawQuadrilaterals(blobs, image);
            string resultPath = "result.png";
            imageHighlighted.Save(resultPath);
        }
        
        private Blob[] BlobsInImage(Bitmap image)
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

    }
}
