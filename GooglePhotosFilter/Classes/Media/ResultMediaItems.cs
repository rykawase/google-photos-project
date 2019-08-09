using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooglePhotosFilter.Classes.Media
{
    public class ResultMediaItems : ResultGoogleApi
    {
        public List<MediaItemData> MediaItems { get; set; }
        public string NextPageToken { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
    }
}
