namespace GooglePhotosFilter.Controls
{
    partial class ListAlbumsControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlAlbums = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // pnlAlbums
            // 
            this.pnlAlbums.AutoScroll = true;
            this.pnlAlbums.Location = new System.Drawing.Point(4, 3);
            this.pnlAlbums.Name = "pnlAlbums";
            this.pnlAlbums.Size = new System.Drawing.Size(705, 580);
            this.pnlAlbums.TabIndex = 0;
            // 
            // ListAlbumsControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pnlAlbums);
            this.Name = "ListAlbumsControl";
            this.Size = new System.Drawing.Size(712, 583);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnlAlbums;

    }
}
