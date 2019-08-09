using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooglePhotosFilter.Classes.Media
{
    public class MediaData
    {
        public string CreationTime { get; set; }
        public string Widht { get; set; }
        public string Height { get; set; }
        public PhotoData Photo { get; set; }
        public VideoData Video { get; set; }
    }
}
