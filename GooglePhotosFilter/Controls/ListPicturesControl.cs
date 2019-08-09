using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GooglePhotosFilter.Classes.Media;
using GooglePhotosFilter.Classes;
using GooglePhotosFilter.Utils;

namespace GooglePhotosFilter.Controls
{
    public partial class ListPicturesControl : UserControl
    {
        public ListPicturesControl(string albumId) 
        {
            InitializeComponent();

            this.LoadPictures(albumId);
        }

        private void LoadPictures(string albumId)
        {
            ResultMediaItems result = new ResultMediaItems();
            
            if(albumId != string.Empty)
                result = GooglePhotosInterface.Instance.ListMediaItems(albumId);
            else
                result = GooglePhotosInterface.Instance.ListMediaItems();

            if (result.ResultCode == "OK")
            {
                ShowPicturesOnScreeen(result);
            }
            else
            {
                MessageBox.Show(result.ResultMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            ResultMediaItems result = GooglePhotosInterface.Instance.ListNextMediaItems();

            if (result.ResultCode == "OK")
            {
                ShowPicturesOnScreeen(result);
            }
            else
            {
                MessageBox.Show(result.ResultMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            ResultMediaItems result = GooglePhotosInterface.Instance.ListPreviousMediaItems();

            if (result.ResultCode == "OK")
            {
                ShowPicturesOnScreeen(result);
            }
            else
            {
                MessageBox.Show(result.ResultMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowPicturesOnScreeen(ResultMediaItems resultMediaItem)
        {
            pnlPictures.Controls.Clear();

            for (int i = 0; i < resultMediaItem.MediaItems.Count; i++)
            {
                MediaItemData mediaItem = resultMediaItem.MediaItems[i];

                PictureBox pbxMedia = new PictureBox();
                pbxMedia.Height = 200;
                pbxMedia.Width = 220;
                pbxMedia.Image = Utilities.GetBmpFromGoogleUrl(mediaItem.BaseUrl + "=w220-h200-c");
                pbxMedia.SizeMode = PictureBoxSizeMode.CenterImage;
                pnlPictures.Controls.Add(pbxMedia);
            }

            btnPrevious.Visible = false;
            btnNext.Visible = false;

            if (resultMediaItem.HasPreviousPage)
                btnPrevious.Visible = true;

            if (resultMediaItem.HasNextPage)
                btnNext.Visible = true;
        }
    }
}
