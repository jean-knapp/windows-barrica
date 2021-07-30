
namespace windows_theodolite.Forms.Settings
{
    partial class RangeSettingsForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RangeSettingsForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.towerTargetDistanceEdit = new DevExpress.XtraEditors.SpinEdit();
            this.towerTowerDistanceEdit = new DevExpress.XtraEditors.SpinEdit();
            this.defaultHeadingEdit = new DevExpress.XtraEditors.SpinEdit();
            this.importButton = new DevExpress.XtraEditors.SimpleButton();
            this.exportButton = new DevExpress.XtraEditors.SimpleButton();
            this.cancelButton = new DevExpress.XtraEditors.SimpleButton();
            this.saveButton = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.secTowerTargetDistanceEdit = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.saveFileDialog = new DevExpress.XtraEditors.XtraSaveFileDialog(this.components);
            this.openFileDialog = new DevExpress.XtraEditors.XtraOpenFileDialog(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.towerTargetDistanceEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.towerTowerDistanceEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.defaultHeadingEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.secTowerTargetDistanceEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::windows_theodolite.Properties.Resources.rangeBackground;
            this.pictureBox1.Location = new System.Drawing.Point(5, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(423, 275);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // towerTargetDistanceEdit
            // 
            this.towerTargetDistanceEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.towerTargetDistanceEdit.Location = new System.Drawing.Point(315, 110);
            this.towerTargetDistanceEdit.Name = "towerTargetDistanceEdit";
            this.towerTargetDistanceEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.towerTargetDistanceEdit.Properties.Appearance.Options.UseFont = true;
            this.towerTargetDistanceEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.towerTargetDistanceEdit.Properties.MaxValue = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.towerTargetDistanceEdit.Size = new System.Drawing.Size(100, 30);
            this.towerTargetDistanceEdit.TabIndex = 1;
            // 
            // towerTowerDistanceEdit
            // 
            this.towerTowerDistanceEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.towerTowerDistanceEdit.Location = new System.Drawing.Point(167, 280);
            this.towerTowerDistanceEdit.Name = "towerTowerDistanceEdit";
            this.towerTowerDistanceEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.towerTowerDistanceEdit.Properties.Appearance.Options.UseFont = true;
            this.towerTowerDistanceEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.towerTowerDistanceEdit.Properties.MaxValue = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.towerTowerDistanceEdit.Size = new System.Drawing.Size(100, 30);
            this.towerTowerDistanceEdit.TabIndex = 2;
            // 
            // defaultHeadingEdit
            // 
            this.defaultHeadingEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.defaultHeadingEdit.Location = new System.Drawing.Point(220, 155);
            this.defaultHeadingEdit.Name = "defaultHeadingEdit";
            this.defaultHeadingEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.defaultHeadingEdit.Properties.Appearance.Options.UseFont = true;
            this.defaultHeadingEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.defaultHeadingEdit.Properties.IsFloatValue = false;
            this.defaultHeadingEdit.Properties.MaskSettings.Set("mask", "N00");
            this.defaultHeadingEdit.Properties.MaxValue = new decimal(new int[] {
            359,
            0,
            0,
            0});
            this.defaultHeadingEdit.Size = new System.Drawing.Size(75, 30);
            this.defaultHeadingEdit.TabIndex = 3;
            // 
            // importButton
            // 
            this.importButton.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importButton.Appearance.Options.UseFont = true;
            this.importButton.Location = new System.Drawing.Point(12, 12);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(100, 30);
            this.importButton.TabIndex = 4;
            this.importButton.Text = "Import";
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // exportButton
            // 
            this.exportButton.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportButton.Appearance.Options.UseFont = true;
            this.exportButton.Location = new System.Drawing.Point(118, 12);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(100, 30);
            this.exportButton.TabIndex = 5;
            this.exportButton.Text = "Export";
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Appearance.Options.UseFont = true;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(239, 371);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 30);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(115)))), ((int)(((byte)(70)))));
            this.saveButton.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Appearance.Options.UseBackColor = true;
            this.saveButton.Appearance.Options.UseFont = true;
            this.saveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.saveButton.Location = new System.Drawing.Point(345, 371);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 30);
            this.saveButton.TabIndex = 6;
            this.saveButton.Text = "Save";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl6);
            this.panelControl1.Controls.Add(this.labelControl5);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.secTowerTargetDistanceEdit);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.towerTargetDistanceEdit);
            this.panelControl1.Controls.Add(this.defaultHeadingEdit);
            this.panelControl1.Controls.Add(this.towerTowerDistanceEdit);
            this.panelControl1.Controls.Add(this.pictureBox1);
            this.panelControl1.Location = new System.Drawing.Point(12, 48);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(433, 316);
            this.panelControl1.TabIndex = 8;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(5, 270);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(73, 38);
            this.labelControl6.TabIndex = 9;
            this.labelControl6.Text = "Secondary\r\nTower";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(366, 270);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(55, 38);
            this.labelControl5.TabIndex = 9;
            this.labelControl5.Text = "Primary\r\nTower";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(18, 85);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(59, 19);
            this.labelControl4.TabIndex = 8;
            this.labelControl4.Text = "Distance";
            // 
            // secTowerTargetDistanceEdit
            // 
            this.secTowerTargetDistanceEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.secTowerTargetDistanceEdit.Location = new System.Drawing.Point(18, 110);
            this.secTowerTargetDistanceEdit.Name = "secTowerTargetDistanceEdit";
            this.secTowerTargetDistanceEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.secTowerTargetDistanceEdit.Properties.Appearance.Options.UseFont = true;
            this.secTowerTargetDistanceEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.secTowerTargetDistanceEdit.Properties.MaxValue = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.secTowerTargetDistanceEdit.Size = new System.Drawing.Size(100, 30);
            this.secTowerTargetDistanceEdit.TabIndex = 7;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(220, 130);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(58, 19);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Heading";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(186, 255);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(59, 19);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "Distance";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(315, 85);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(59, 19);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Distance";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Comma-separated values (*.csv)|*.csv";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Comma-separated values (*.csv)|*.csv";
            // 
            // RangeSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 413);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.importButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("RangeSettingsForm.IconOptions.Icon")));
            this.MaximizeBox = false;
            this.Name = "RangeSettingsForm";
            this.Text = "Range Settings";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.towerTargetDistanceEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.towerTowerDistanceEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.defaultHeadingEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.secTowerTargetDistanceEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraEditors.SpinEdit towerTargetDistanceEdit;
        private DevExpress.XtraEditors.SpinEdit towerTowerDistanceEdit;
        private DevExpress.XtraEditors.SpinEdit defaultHeadingEdit;
        private DevExpress.XtraEditors.SimpleButton importButton;
        private DevExpress.XtraEditors.SimpleButton exportButton;
        private DevExpress.XtraEditors.SimpleButton cancelButton;
        private DevExpress.XtraEditors.SimpleButton saveButton;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.XtraSaveFileDialog saveFileDialog;
        private DevExpress.XtraEditors.XtraOpenFileDialog openFileDialog;
        private DevExpress.XtraEditors.SpinEdit secTowerTargetDistanceEdit;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
    }
}