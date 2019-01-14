using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountPostIts.ImageRecognition.Services
{
    public interface ICountByColor
    {
        Dictionary<string, int> CountAllColors(string filename);
    }
}
