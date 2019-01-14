using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CountPostIts.ImageRecognition.Entities;

namespace CountPostIts.ImageRecognition.Services
{
    public interface IPostItAnalysis
    {
        int CountPostItNotes(string filename, IColorRange rgbRange, string colorName);
    }
}
