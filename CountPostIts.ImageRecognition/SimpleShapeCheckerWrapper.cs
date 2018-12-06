using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord;
using Accord.Math.Geometry;

namespace CountPostIts.ImageRecognition
{
    public class SimpleShapeCheckerWrapper : ISimpleShapeCheckerWrapper
    {
        public SimpleShapeChecker OwnShapeChecker { get; set; }

        public SimpleShapeCheckerWrapper()
        {
            this.OwnShapeChecker = new SimpleShapeChecker();
        }
        public bool OwnIsQuadrilateral(List<IntPoint> edgePoints, out List<IntPoint> cornerPoints)
        {
            return OwnShapeChecker.IsQuadrilateral(edgePoints, out cornerPoints);
        }
    }
}
