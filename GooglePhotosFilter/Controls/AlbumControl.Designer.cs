namespace GooglePhotosFilter.Controls
{
    partial class AlbumControl
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
            this.pbxCover = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblMediaCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCover)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxCover
            // 
            this.pbxCover.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxCover.Location = new System.Drawing.Point(0, 0);
            this.pbxCover.Margin = new System.Windows.Forms.Padding(4);
            this.pbxCover.Name = "pbxCover";
            this.pbxCover.Size = new System.Drawing.Size(220, 164);
            this.pbxCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbxCover.TabIndex = 0;
            this.pbxCover.TabStop = false;
            this.pbxCover.Click += new System.EventHandler(this.pbxCover_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(5, 168);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(211, 39);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Album Title";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblMediaCount
            // 
            this.lblMediaCount.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMediaCount.Location = new System.Drawing.Point(5, 216);
            this.lblMediaCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMediaCount.Name = "lblMediaCount";
            this.lblMediaCount.Size = new System.Drawing.Size(211, 15);
            this.lblMediaCount.TabIndex = 2;
            this.lblMediaCount.Text = "0 pictures";
            this.lblMediaCount.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // AlbumControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblMediaCount);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pbxCover);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AlbumControl";
            this.Size = new System.Drawing.Size(220, 232);
            ((System.ComponentModel.ISupportInitialize)(this.pbxCover)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxCover;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblMediaCount;
    }
}
