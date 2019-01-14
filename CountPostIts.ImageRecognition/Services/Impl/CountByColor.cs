using System.Collections.Generic;
using CountPostIts.ImageRecognition.Entities;
using CountPostIts.ImageRecognition.Services.Impl;

namespace CountPostIts.ImageRecognition.Services
{
    public class CountByColor : ICountByColor
    {
        private readonly IPostItAnalysis _postItAnalysis;
       
        public CountByColor(IPostItAnalysis postItAnalysis)
        {
            _postItAnalysis = postItAnalysis;
        }

        public Dictionary<string, int> CountAllColors(string filename)
        {
            var result = new Dictionary<string, int>();
            var colorRanges = new ColorRanges(new ColorRangeFactory());
            foreach (var colorEntry in colorRanges.Rgb)
            {
                var colorName = colorEntry.Key.ToString();
                var count = _postItAnalysis.CountPostItNotes(filename, colorEntry.Value, colorName);
                result.Add(colorName, count);
            }

            return result;
        }
    }
}