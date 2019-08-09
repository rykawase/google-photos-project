using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GooglePhotosFilter.Classes.Albums;
using GooglePhotosFilter.Utils;

namespace GooglePhotosFilter.Controls
{
    public delegate void AlbumChoosedEventHandler(string albumId);

    public partial class AlbumControl : UserControl
    {
        private string albumControlId = string.Empty;

        public static event AlbumChoosedEventHandler onAlbumChoosed;

        public AlbumControl()
        {
            InitializeComponent();
        }

        public AlbumControl(AlbumData albumData)
            : this()
        {
            this.lblTitle.Text = albumData.Title;
            this.lblMediaCount.Text = string.Format("{0} picture(s)", albumData.MediaItemsCount);
            this.pbxCover.Image = Utilities.GetBmpFromGoogleUrl(albumData.CoverPhotoBaseUrl + "=w220-h200-c");
            
            this.albumControlId = albumData.Id;
        }

        

        private void pbxCover_Click(object sender, EventArgs e)
        {
            onAlbumChoosed(this.albumControlId);
        }
    }
}
