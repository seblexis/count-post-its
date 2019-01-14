using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Accord;
using Accord.Imaging;
using CountPostIts.ImageRecognition.Entities;
using Image = System.Drawing.Image;
using Point = System.Drawing.Point;

namespace CountPostIts.ImageRecognition.Services.Impl
{
    public class PostItAnalysis : IPostItAnalysis
    {
        private readonly IBlobCounterWrapper _blobCounterWrapper;
        private readonly IColorFilteringWrapper _colorFilteringWrapper;
        private readonly ISimpleShapeCheckerWrapper _simpleShapeCheckerWrapper;

        public PostItAnalysis(IBlobCounterWrapper blobCounterWrapper,
            ISimpleShapeCheckerWrapper simpleShapeCheckerWrapper, IColorFilteringWrapper colorFilteringWrapper)
        {
            _simpleShapeCheckerWrapper = simpleShapeCheckerWrapper;
            _blobCounterWrapper = blobCounterWrapper;
            _colorFilteringWrapper = colorFilteringWrapper;
        }

        public int CountPostItNotes(string filename, IColorRange rgbRange, string colorName)
        {
            var image = (Bitmap) Image.FromFile(filename);
            var imageFilter = new ImageFilter(_colorFilteringWrapper);
            var blobsDetector = new BlobsDetector(_blobCounterWrapper);
            var filteredImage = imageFilter.GetFilteredImage(image, rgbRange);
            var blobs = blobsDetector.FindBlobs(filteredImage);

            return CountQuadrilaterals(blobs, filteredImage, colorName);
        }

        private int CountQuadrilaterals(Blob[] blobs, Bitmap image, string colorName)
        {
            var counter = 0;
            for (var i = 0; i < blobs.Length; i++)
            {
                var edgePoints = _blobCounterWrapper.OwnGetBlobsEdgePoints(blobs[i]);
                if (_simpleShapeCheckerWrapper.OwnIsQuadrilateral(edgePoints, out var cornerPoints))
                {
                    DrawPostIt(image, edgePoints, cornerPoints);
                    counter++;
                }
            }

            if (counter > 0) image.Save(GetPathToSaveTo(colorName));
            return counter;
        }

        private void DrawPostIt(Bitmap image, List<IntPoint> edgePoints, List<IntPoint> cornerPoints)
        {
            var points = new List<Point>();
            foreach (var point in cornerPoints) points.Add(new Point(point.X, point.Y));
            var g = Graphics.FromImage(image);
            g.DrawPolygon(new Pen(Color.Red, 5.0f), points.ToArray());
        }

        private string GetPathToSaveTo(string colorName)
        {
            return new DirectoryInfo(Environment.CurrentDirectory)?.Parent?.Parent?.Parent?.FullName +
                   $"\\images\\result_{colorName}.jpg";
        }
    }
}