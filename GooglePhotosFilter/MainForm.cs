using GooglePhotosFilter.Classes;
using GooglePhotosFilter.Classes.Albums;
using GooglePhotosFilter.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GooglePhotosFilter
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            AlbumControl.onAlbumChoosed += AlbumControl_onAlbumChoosed;

            navigateToNextPanelControl(new LoginControl());
        }

        void AlbumControl_onAlbumChoosed(string albumId)
        {
            navigateToNextPanelControl(new ListPicturesControl(albumId));
        }        

        private void btnLogin_Click(object sender, EventArgs e)
        {
            navigateToNextPanelControl(new LoginControl());
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void navigateToNextPanelControl(UserControl control)
        {
            if (this.pnlControls.Controls.Count > 0)
                this.pnlControls.Controls.RemoveAt(0);

            this.pnlControls.Controls.Add(control);
        }

        private void btnAlbums_Click(object sender, EventArgs e)
        {
            navigateToNextPanelControl(new ListAlbumsControl());
        }

        private void btnPictures_Click(object sender, EventArgs e)
        {
            navigateToNextPanelControl(new ListPicturesControl(string.Empty));
        }
    }
}
