
namespace windows_theodolite.Forms.Import
{
    partial class ImportQRCodeForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.qrCodeEdit = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.qrCodeEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // qrCodeEdit
            // 
            this.qrCodeEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.qrCodeEdit.Location = new System.Drawing.Point(0, 0);
            this.qrCodeEdit.Name = "qrCodeEdit";
            this.qrCodeEdit.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.qrCodeEdit.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.qrCodeEdit.Size = new System.Drawing.Size(298, 268);
            this.qrCodeEdit.TabIndex = 1;
            // 
            // ImportQRCodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 268);
            this.Controls.Add(this.qrCodeEdit);
            this.Name = "ImportQRCodeForm";
            this.Text = "ImportQRCodeForm";
            ((System.ComponentModel.ISupportInitialize)(this.qrCodeEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit qrCodeEdit;
    }
}