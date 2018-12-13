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

        public void FilterImage(Bitmap image, Dictionary<string, int[]> rgb)
        {
            SetFilters(rgb);
            ColorFilteringWrapper.OwnApplyInPlace(image);
        }

        public int CountPostItNotes(string filename, Dictionary<string, int[]> rgb)
        {
            Bitmap image = (Bitmap)Bitmap.FromFile(filename);
            FilterImage(image, rgb);
            Blob[] blobs = BlobsInImage(image);
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

        public void SetFilters(Dictionary<string, int[]> rgb)
        {
            try
            {
                SetFilterRed(rgb["R"][0], rgb["R"][1]);
                SetFilterGreen(rgb["G"][0], rgb["G"][1]);
                SetFilterBlue(rgb["B"][0], rgb["B"][1]);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
            }
        }

        private void SetFilterRed(int rmin, int rmax)
        {
            CheckRanges(rmin, rmax);
            ColorFilteringWrapper.OwnRed(rmin, rmax);
        }

        private void SetFilterGreen(int gmin, int gmax)
        {
            CheckRanges(gmin, gmax);
            ColorFilteringWrapper.OwnGreen(gmin, gmax);
        }
        private void SetFilterBlue(int bmin, int bmax)
        {
            CheckRanges(bmin, bmax);
            ColorFilteringWrapper.OwnBlue(bmin, bmax);
        }

        private void CheckRanges(int min, int max)
        {
            if (min < 0 || min > 255)
            {
                throw new ArgumentException("min needs to be between 0 and 255");
            }
            else if (max < 0 || max > 255)
            {
                throw new ArgumentException("max needs to be between 0 and 255");
            }
            else if (min > max)
            {
                throw new ArgumentException("min cannot be bigger than max");
            }
        } 
    }
}
