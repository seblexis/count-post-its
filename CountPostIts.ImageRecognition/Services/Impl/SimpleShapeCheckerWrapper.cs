﻿using System.Collections.Generic;
using Accord;
using Accord.Math.Geometry;

namespace CountPostIts.ImageRecognition.Services.Impl
{
    public class SimpleShapeCheckerWrapper : ISimpleShapeCheckerWrapper
    {
        private readonly SimpleShapeChecker _ownShapeChecker;

        public SimpleShapeCheckerWrapper()
        {
            _ownShapeChecker = new SimpleShapeChecker();
        }

        public bool OwnIsQuadrilateral(List<IntPoint> edgePoints, out List<IntPoint> cornerPoints)
        {
            return _ownShapeChecker.IsQuadrilateral(edgePoints, out cornerPoints);
        }
    }
}