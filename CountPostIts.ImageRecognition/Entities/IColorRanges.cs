using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountPostIts.ImageRecognition.Entities
{
    public interface IColorRanges
    {
        Dictionary<Colors, IColorRange> Rgb { get; set; }
    }
}
