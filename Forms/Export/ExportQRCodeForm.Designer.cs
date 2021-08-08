
namespace windows_theodolite.Forms.Export
{
    partial class ExportQRCodeForm
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
            this.fileNameLabel = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.qrCodeEdit = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.qrCodeEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.Appearance.BackColor = System.Drawing.Color.White;
            this.fileNameLabel.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileNameLabel.Appearance.Options.UseBackColor = true;
            this.fileNameLabel.Appearance.Options.UseFont = true;
            this.fileNameLabel.Appearance.Options.UseTextOptions = true;
            this.fileNameLabel.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fileNameLabel.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.fileNameLabel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.fileNameLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.fileNameLabel.Location = new System.Drawing.Point(8, 799);
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(768, 29);
            this.fileNameLabel.TabIndex = 1;
            this.fileNameLabel.Text = "File name";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseBackColor = true;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseTextOptions = true;
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl2.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl2.Location = new System.Drawing.Point(8, 8);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(768, 23);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Take a picture of this QR Code and send it to your weapons officer.";
            // 
            // qrCodeEdit
            // 
            this.qrCodeEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.qrCodeEdit.Location = new System.Drawing.Point(8, 31);
            this.qrCodeEdit.Name = "qrCodeEdit";
            this.qrCodeEdit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.qrCodeEdit.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.qrCodeEdit.Properties.ShowMenu = false;
            this.qrCodeEdit.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.qrCodeEdit.Size = new System.Drawing.Size(768, 768);
            this.qrCodeEdit.TabIndex = 3;
            // 
            // ExportQRCodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 836);
            this.Controls.Add(this.qrCodeEdit);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.fileNameLabel);
            this.MinimumSize = new System.Drawing.Size(786, 868);
            this.Name = "ExportQRCodeForm";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Text = "Export QR Code";
            ((System.ComponentModel.ISupportInitialize)(this.qrCodeEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl fileNameLabel;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.PictureEdit qrCodeEdit;
    }
}