using Accord;
using Accord.Imaging;
using System.Collections.Generic;
using System.Drawing;

namespace CountPostIts.ImageRecognition
{
    public class PostItAnalysis
    {
        public ISimpleShapeCheckerWrapper SimpleShapeCheckerWrapper { get; set; }
        public IBlobCounterWrapper BlobCounterWrapper { get; set; }
        public IColorFilteringWrapper ColorFilteringWrapper { get; set; }

        public PostItAnalysis(IBlobCounterWrapper blobCounterWrapper, ISimpleShapeCheckerWrapper simpleShapeCheckerWrapper, IColorFilteringWrapper colorFilteringWrapper)
        {
            this.SimpleShapeCheckerWrapper = simpleShapeCheckerWrapper;
            this.BlobCounterWrapper = blobCounterWrapper;
            this.ColorFilteringWrapper = colorFilteringWrapper;
        }

        public int CountPostItNotes(string filename, Dictionary<string, int[]> rgbRange, string colourName)
        {
            Bitmap image = (Bitmap)Bitmap.FromFile(filename);
            ImageFilter imageFilter = new ImageFilter(ColorFilteringWrapper);
            Bitmap filteredImage = imageFilter.GetFilteredImage(image, rgbRange);
            Blob[] blobs = BlobsInImage(filteredImage);
            return CountQuadrilaterals(blobs, filteredImage, colourName);
        }
        private Blob[] BlobsInImage(Bitmap image)
        {
            BlobCounterWrapper.OwnFilterBlobs(true);
            BlobCounterWrapper.OwnMinHeight(30);
            BlobCounterWrapper.OwnMinWidth(30);
            BlobCounterWrapper.OwnProcessImage(image);
            return BlobCounterWrapper.OwnGetObjectsInformation();
        }

        private int CountQuadrilaterals(Blob[] blobs, Bitmap image, string colourName)
        {
            int counter = 0;
            for (int i = 0; i < blobs.Length; i++)
            {
                List<IntPoint> edgePoints = BlobCounterWrapper.OwnGetBlobsEdgePoints(blobs[i]);
                List<IntPoint> cornerPoints;
                if (SimpleShapeCheckerWrapper.OwnIsQuadrilateral(edgePoints, out cornerPoints))
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

        private Bitmap DrawPostIt(Bitmap image, List<IntPoint> edgePoints, List<IntPoint> cornerPoints)
        {
            List<System.Drawing.Point> Points = new List<System.Drawing.Point>();
            foreach (var point in cornerPoints)
            {
                Points.Add(new System.Drawing.Point(point.X, point.Y));
            }

            Graphics g = Graphics.FromImage(image);
            g.DrawPolygon(new Pen(Color.Red, 5.0f), Points.ToArray());
            return image;
        }
    }
}
