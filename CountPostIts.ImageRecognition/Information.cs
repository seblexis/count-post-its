using System;
using System.Collections.Generic;

namespace CountPostIts.ImageRecognition
{
    public class Information
    {
        private IBlobCounterWrapper _blobCounterWrapper;
        private ISimpleShapeCheckerWrapper _simpleShapeCheckerWrapper;
        private IColorFilteringWrapper _colorFilteringWrapper;

        public Information()
        {
            _blobCounterWrapper = new BlobCounterWrapper();
            _simpleShapeCheckerWrapper = new SimpleShapeCheckerWrapper();
            _colorFilteringWrapper = new ColorFilteringWrapper();
        }

        public Dictionary<string, int> CountAllColours(string filename)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            ColorRanges colorRanges = new ColorRanges(new ColorRangeFactory());
            PostItAnalysis postItAnalysis = new PostItAnalysis(_blobCounterWrapper, _simpleShapeCheckerWrapper, _colorFilteringWrapper);
            foreach (KeyValuePair<Colors, IColorRange> colourEntry in colorRanges.RGB)
            {
                string colourName = Enum.GetName(typeof(Colors), colourEntry.Key);
                int count = postItAnalysis.CountPostItNotes(filename, colourEntry.Value, colourName);
                result.Add(colourName, count);
            }
            return result;
        }
    }
}
