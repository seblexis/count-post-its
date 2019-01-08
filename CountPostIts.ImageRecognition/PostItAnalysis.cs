using Accord;
using Accord.Imaging;
using System.Collections.Generic;
using System.Drawing;

namespace CountPostIts.ImageRecognition
{
    public class PostItAnalysis
    {
        private ISimpleShapeCheckerWrapper _simpleShapeCheckerWrapper;
        private IBlobCounterWrapper _blobCounterWrapper;
        private IColorFilteringWrapper _colorFilteringWrapper;

        public PostItAnalysis(IBlobCounterWrapper blobCounterWrapper, ISimpleShapeCheckerWrapper simpleShapeCheckerWrapper, IColorFilteringWrapper colorFilteringWrapper)
        {
            _simpleShapeCheckerWrapper = simpleShapeCheckerWrapper;
            _blobCounterWrapper = blobCounterWrapper;
            _colorFilteringWrapper = colorFilteringWrapper;
        }

        public int CountPostItNotes(string filename, IColorRange rgbRange, string colourName)
        {
            Bitmap image = (Bitmap)Bitmap.FromFile(filename);
            ImageFilter imageFilter = new ImageFilter(_colorFilteringWrapper);
            BlobsDetector blobsDetector = new BlobsDetector(_blobCounterWrapper);
            Bitmap filteredImage = imageFilter.GetFilteredImage(image, rgbRange);
            Blob[] blobs = blobsDetector.FindBlobs(filteredImage);

            return CountQuadrilaterals(blobs, filteredImage, colourName);
        }

        private int CountQuadrilaterals(Blob[] blobs, Bitmap image, string colourName)
        {
            int counter = 0;
            for (int i = 0; i < blobs.Length; i++)
            {
                List<IntPoint> edgePoints = _blobCounterWrapper.OwnGetBlobsEdgePoints(blobs[i]);
                List<IntPoint> cornerPoints;
                if (_simpleShapeCheckerWrapper.OwnIsQuadrilateral(edgePoints, out cornerPoints))
                {
                    DrawPostIt(image, edgePoints, cornerPoints);
                    counter++;
                }
            }
            string resultPath = $"result_{colourName}.jpg";
            if (counter > 0)
            {
                image.Save(resultPath);
            }
            return counter;
        }

        private void DrawPostIt(Bitmap image, List<IntPoint> edgePoints, List<IntPoint> cornerPoints)
        {
            List<System.Drawing.Point> points = new List<System.Drawing.Point>();
            foreach (var point in cornerPoints)
            {
                points.Add(new System.Drawing.Point(point.X, point.Y));
            }
            Graphics g = Graphics.FromImage(image);
            g.DrawPolygon(new Pen(Color.Red, 5.0f), points.ToArray());
        }
    }
}
