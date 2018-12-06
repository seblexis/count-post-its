using Accord;
using Accord.Math.Geometry;
using System.Collections.Generic;

namespace CountPostIts.ImageRecognition
{
    public interface ISimpleShapeCheckerWrapper
    {
        SimpleShapeChecker OwnShapeChecker { get; set; }
        bool OwnIsQuadrilateral(List<IntPoint> edgePoints,  out List<IntPoint> cornerPoints);
    }
}