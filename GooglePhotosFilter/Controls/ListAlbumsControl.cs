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
using GooglePhotosFilter.Classes;
using GooglePhotosFilter.Controls;

namespace GooglePhotosFilter.Controls
{
    public partial class ListAlbumsControl : UserControl
    {
        private BackgroundWorker bwListAlbums;
        private BackgroundWorker bwLoadPicture;
        
        public ListAlbumsControl()
        {
            InitializeComponent();

            pnlAlbums.Visible = false;

            this.bwListAlbums = new BackgroundWorker();
            this.bwListAlbums.DoWork += bwListAlbums_DoWork;
            this.bwListAlbums.RunWorkerCompleted += bwListAlbums_RunWorkerCompleted;
            this.bwListAlbums.RunWorkerAsync();

            this.bwLoadPicture = new BackgroundWorker();
            this.bwLoadPicture.DoWork += bwLoadPicture_DoWork;
            this.bwLoadPicture.RunWorkerCompleted += bwLoadPicture_RunWorkerCompleted;
        }

        void bwLoadPicture_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }

        void bwLoadPicture_DoWork(object sender, DoWorkEventArgs e)
        {
            throw new NotImplementedException();
        }

        void bwListAlbums_DoWork(object sender, DoWorkEventArgs e)
        {
            ResultAlbums result = GooglePhotosInterface.Instance.ListAlbums();

            if (result.ResultCode == "OK")
            {
                this.Invoke(new Action(() => {
                    for (int i = 0; i < result.Albums.Count; i++)
                    {
                        AlbumData album = result.Albums[i];

                        AlbumControl albumControl = new AlbumControl(album);
                        pnlAlbums.Controls.Add(albumControl);
                    }
                }));                
            }
            else
            {
                MessageBox.Show(result.ResultMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void bwListAlbums_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pnlAlbums.Visible = true;
        }

    }
}
