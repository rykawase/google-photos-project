using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooglePhotosFilter.Classes.Albums
{
    public class AlbumData
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string ProductUrl { get; set; }
        public bool IsWritable { get; set; }
        public ShareInfoData ShareInfo { get; set; }
        public string MediaItemsCount { get; set; }
        public string CoverPhotoBaseUrl { get; set; }
        public string CoverPhotoMediaItemId { get; set; }
    }
}
