using System;
using System.Collections.Generic;
using System.Drawing;
using Accord;
using Accord.Imaging;
using Accord.Imaging.Filters;

namespace CountPostIts.ImageRecognition
{
    public class Information
    {
        private readonly int _rgbRange = 45;
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
            HSLFiltering hsl = new HSLFiltering();
            hsl.Saturation = new Range(0.00f, 0.3f);
            hsl.Luminance = new Range(0.30f, 1f);
            hsl.FillOutsideRange = false;
            hsl.ApplyInPlace(image);

            image.Save("test-r.png");
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
            BlobCounterWrapper.OwnMinHeight(10);
            BlobCounterWrapper.OwnMinWidth(10);
            BlobCounterWrapper.OwnProcessImage(image);
            return BlobCounterWrapper.OwnGetObjectsInformation();
        }

        public int CountQuadrilaterals(Blob[] blobs)
        {
            int counter = 0;
            var _colorOfPosts = new Dictionary<string, int>
            {
                {"Red", 0},
                {"Pink",0 },
                {"Green", 0},
                {"Blue", 0},
                {"Light Blue", 0 },
                {"Yellow", 0},
                {"Orange", 0 },
                {"Purple", 0 },
                {"Unknown", 0 }
            };
            foreach (Blob blob in blobs)
            {
                List<IntPoint> edgePoints = BlobCounterWrapper.OwnGetBlobsEdgePoints(blob);
                List<IntPoint> cornerPoints;
                if (SimpleShapeCheckerWrapper.OwnIsQuadrilateral(edgePoints, out cornerPoints))
                {
                    Color blobColor = blob.ColorMean;

                    if (blobColor.GetHue() >= 15 && blobColor.GetHue() < 45)
                    {
                        _colorOfPosts["Orange"]++;
                    }
                    else if (blobColor.GetHue() >= 45 && blobColor.GetHue() < 75)
                    {
                        _colorOfPosts["Yellow"]++;
                    }
                    else if (blobColor.GetHue() >= 75 && blobColor.GetHue() < 165)
                    {
                        _colorOfPosts["Green"]++;
                    }
                    else if (blobColor.GetHue() >= 165 && blobColor.GetHue() < 195)
                    {
                        _colorOfPosts["Light Blue"]++;
                    }
                    else if (blobColor.GetHue() >= 195 && blobColor.GetHue() < 250)
                    {
                        _colorOfPosts["Blue"]++;
                    }
                    else if (blobColor.GetHue() >= 250 && blobColor.GetHue() < 295)
                    {
                        _colorOfPosts["Purple"]++;
                    }
                    else if (blobColor.GetHue() >= 295 && blobColor.GetHue() < 340)
                    {
                        _colorOfPosts["Pink"]++;
                    }
                    else
                    {
                        _colorOfPosts["Red"]++;
                    }
                        counter++;
                }
            }
            Console.WriteLine($"Found Red: {_colorOfPosts["Red"]}, Pink: {_colorOfPosts["Pink"]}, Purple: {_colorOfPosts["Purple"]}, Green: {_colorOfPosts["Green"]}, Light Blue: {_colorOfPosts["Light Blue"]}, Blue: {_colorOfPosts["Blue"]}, Yellow: {_colorOfPosts["Yellow"]}, Orange: {_colorOfPosts["Orange"]}, Unknown: {_colorOfPosts["Unknown"]}");

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
