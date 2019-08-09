using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooglePhotosFilter.Classes.Media
{
    public class PhotoData
    {
        public string CameraMake { get; set; }
        public string CameraModel { get; set; }
        public double FocalLength { get; set; }
        public double ApertureFNumber { get; set; }
        public double IsoEquivalent { get; set; }
        public string ExposureTime { get; set; }
    }
}
