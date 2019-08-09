using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooglePhotosFilter.Classes.Albums
{
    public class ShareInfoData
    {
        public SharedAlbumOptionsData SharedAlbumOptions { get; set; }
        public string SheareableUrl { get; set; }
        public string ShareToken { get; set; }
        public bool IsJoined { get; set; }
    }
}
