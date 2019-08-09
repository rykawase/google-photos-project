using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooglePhotosFilter.Classes.Albums
{
    public class ResultAlbums : ResultGoogleApi
    {
        public List<AlbumData> Albums { get; set; }
        public string NextPageToken { get; set; }
    }
}
