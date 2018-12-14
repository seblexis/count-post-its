using System;
using System.Collections.Generic;

namespace CountPostIts.ImageRecognition
{
    public class Information
    {
        public IBlobCounterWrapper BlobCounterWrapper { get; set; }
        public ISimpleShapeCheckerWrapper SimpleShapeCheckerWrapper { get; set; }
        public IColorFilteringWrapper ColorFilteringWrapper { get; set; }


        public Information()
        {
            this.BlobCounterWrapper = new BlobCounterWrapper();
            this.SimpleShapeCheckerWrapper = new SimpleShapeCheckerWrapper();
            this.ColorFilteringWrapper = new ColorFilteringWrapper();
        }

        public Dictionary<string, int> CountAllColours(string filename)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            ColourRanges colourRanges = new ColourRanges();
            PostItAnalysis postItAnalysis = new PostItAnalysis(BlobCounterWrapper, SimpleShapeCheckerWrapper, ColorFilteringWrapper);
            foreach (KeyValuePair<Colours, Dictionary<string, int[]>> colourEntry in colourRanges.RGB)
            {
                string colourName = Enum.GetName(typeof(Colours), colourEntry.Key);
                int count = postItAnalysis.CountPostItNotes(filename, colourEntry.Value, colourName);
                result.Add(colourName, count);
            }
            return result;
        }
    }
}
