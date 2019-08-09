using GooglePhotosFilter.Enums.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooglePhotosFilter.Classes.Media
{
    public class VideoData
    {
        public string CameraMake { get; set; }
        public string CameraModel { get; set; }
        public double Fps { get; set; }
        public VideoProcessingStatus Status { get; set; }
    }
}
