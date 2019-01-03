﻿using Accord;
using Accord.Math.Geometry;
using System.Collections.Generic;

namespace CountPostIts.ImageRecognition
{
    public interface ISimpleShapeCheckerWrapper
    {
        bool OwnIsQuadrilateral(List<IntPoint> edgePoints,  out List<IntPoint> cornerPoints);
    }
}