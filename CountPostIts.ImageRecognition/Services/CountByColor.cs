using System;
using System.Collections.Generic;
using CountPostIts.ImageRecognition.Entities;
using CountPostIts.ImageRecognition.Services.Impl;

namespace CountPostIts.ImageRecognition.Services
{
    public class CountByColor
    {
        private readonly IBlobCounterWrapper _blobCounterWrapper;
        private readonly IColorFilteringWrapper _colorFilteringWrapper;
        private readonly ISimpleShapeCheckerWrapper _simpleShapeCheckerWrapper;

        public CountByColor()
        {
            _blobCounterWrapper = new BlobCounterWrapper();
            _simpleShapeCheckerWrapper = new SimpleShapeCheckerWrapper();
            _colorFilteringWrapper = new ColorFilteringWrapper();
        }

        public Dictionary<string, int> CountAllColours(string filename)
        {
            var result = new Dictionary<string, int>();
            var colorRanges = new ColorRanges(new ColorRangeFactory());
            var postItAnalysis =
                new PostItAnalysis(_blobCounterWrapper, _simpleShapeCheckerWrapper, _colorFilteringWrapper);
            foreach (var colourEntry in colorRanges.Rgb)
            {
                var colourName = Enum.GetName(typeof(Colors), colourEntry.Key);
                var count = postItAnalysis.CountPostItNotes(filename, colourEntry.Value, colourName);
                result.Add(colourName, count);
            }

            return result;
        }
    }
}