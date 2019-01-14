using System.Collections.Generic;
using CountPostIts.ImageRecognition.Entities;
using CountPostIts.ImageRecognition.Services.Impl;

namespace CountPostIts.ImageRecognition.Services
{
    public class CountByColor : ICountByColor
    {
        private readonly IPostItAnalysis _postItAnalysis;
        private readonly IColorRanges _colorRanges;
       
        public CountByColor(IPostItAnalysis postItAnalysis, IColorRanges colorRanges)
        {
            _postItAnalysis = postItAnalysis;
            _colorRanges = colorRanges;
        }

        public Dictionary<string, int> CountAllColors(string filename)
        {
            var result = new Dictionary<string, int>();
            foreach (var colorEntry in _colorRanges.Rgb)
            {
                var colorName = colorEntry.Key.ToString();
                var count = _postItAnalysis.CountPostItNotes(filename, colorEntry.Value, colorName);

                result.Add(colorName, count);
            }

            return result;
        }
    }

}