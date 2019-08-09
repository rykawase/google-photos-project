using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooglePhotosFilter.Classes.Media
{
    public class MediaItemData
    {
        public string Id { get; set; }
        public string ProductUrl { get; set; }
        public string BaseUrl { get; set; }
        public string MimeType { get; set; }
        public MediaData MediaMetaData { get; set; }
        public ContributorData ContributorInfo { get; set; }
        public string FileName { get; set; }
    }
}
