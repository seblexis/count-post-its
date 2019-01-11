using System.Collections.Generic;
using Accord;

namespace CountPostIts.ImageRecognition.Services
{
    public interface ISimpleShapeCheckerWrapper
    {
        bool OwnIsQuadrilateral(List<IntPoint> edgePoints, out List<IntPoint> cornerPoints);
    }
}