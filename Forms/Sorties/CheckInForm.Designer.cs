
namespace windows_theodolite.Forms.Sorties
{
    partial class CheckInForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckInForm));
            this.checkInButton = new DevExpress.XtraEditors.SimpleButton();
            this.cancelButton = new DevExpress.XtraEditors.SimpleButton();
            this.modesTree = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn3 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.modeTreeModeRepository = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.sortiesTree = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.sortiesTreePilotRepository = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.sortiesTreeTailNumberRepository = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.modesLabel = new DevExpress.XtraEditors.LabelControl();
            this.modeCombo = new DevExpress.XtraEditors.ComboBoxEdit();
            this.pilotEdit = new DevExpress.XtraEditors.TextEdit();
            this.tailNumberEdit = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.addSortieButton = new DevExpress.XtraEditors.SimpleButton();
            this.addModeButton = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.modesTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modeTreeModeRepository)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sortiesTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sortiesTreePilotRepository)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sortiesTreeTailNumberRepository)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modeCombo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pilotEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tailNumberEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // checkInButton
            // 
            this.checkInButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkInButton.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(115)))), ((int)(((byte)(70)))));
            this.checkInButton.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkInButton.Appearance.Options.UseBackColor = true;
            this.checkInButton.Appearance.Options.UseFont = true;
            this.checkInButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.checkInButton.Enabled = false;
            this.checkInButton.Location = new System.Drawing.Point(200, 307);
            this.checkInButton.Name = "checkInButton";
            this.checkInButton.Size = new System.Drawing.Size(100, 30);
            this.checkInButton.TabIndex = 0;
            this.checkInButton.Text = "Check-in";
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Appearance.Options.UseFont = true;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(94, 307);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 30);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            // 
            // modesTree
            // 
            this.modesTree.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn3});
            this.modesTree.Location = new System.Drawing.Point(12, 12);
            this.modesTree.Name = "modesTree";
            this.modesTree.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.modeTreeModeRepository});
            this.modesTree.Size = new System.Drawing.Size(100, 179);
            this.modesTree.TabIndex = 2;
            this.modesTree.CellValueChanged += new DevExpress.XtraTreeList.CellValueChangedEventHandler(this.modesTree_CellValueChanged);
            // 
            // treeListColumn3
            // 
            this.treeListColumn3.Caption = "Mode";
            this.treeListColumn3.ColumnEdit = this.modeTreeModeRepository;
            this.treeListColumn3.FieldName = "mode";
            this.treeListColumn3.Name = "treeListColumn3";
            this.treeListColumn3.Visible = true;
            this.treeListColumn3.VisibleIndex = 0;
            // 
            // modeTreeModeRepository
            // 
            this.modeTreeModeRepository.AutoHeight = false;
            this.modeTreeModeRepository.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.modeTreeModeRepository.Name = "modeTreeModeRepository";
            // 
            // sortiesTree
            // 
            this.sortiesTree.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2});
            this.sortiesTree.Location = new System.Drawing.Point(118, 12);
            this.sortiesTree.Name = "sortiesTree";
            this.sortiesTree.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.sortiesTreePilotRepository,
            this.sortiesTreeTailNumberRepository});
            this.sortiesTree.Size = new System.Drawing.Size(182, 179);
            this.sortiesTree.TabIndex = 3;
            this.sortiesTree.CellValueChanged += new DevExpress.XtraTreeList.CellValueChangedEventHandler(this.sortiesTree_CellValueChanged);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "Pilot";
            this.treeListColumn1.ColumnEdit = this.sortiesTreePilotRepository;
            this.treeListColumn1.FieldName = "pilot";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 63;
            // 
            // sortiesTreePilotRepository
            // 
            this.sortiesTreePilotRepository.AutoHeight = false;
            this.sortiesTreePilotRepository.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sortiesTreePilotRepository.MaxLength = 3;
            this.sortiesTreePilotRepository.Name = "sortiesTreePilotRepository";
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.Caption = "Tail number";
            this.treeListColumn2.ColumnEdit = this.sortiesTreeTailNumberRepository;
            this.treeListColumn2.FieldName = "tailNumber";
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 1;
            this.treeListColumn2.Width = 94;
            // 
            // sortiesTreeTailNumberRepository
            // 
            this.sortiesTreeTailNumberRepository.AutoHeight = false;
            this.sortiesTreeTailNumberRepository.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sortiesTreeTailNumberRepository.MaxLength = 4;
            this.sortiesTreeTailNumberRepository.Name = "sortiesTreeTailNumberRepository";
            // 
            // modesLabel
            // 
            this.modesLabel.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modesLabel.Appearance.Options.UseFont = true;
            this.modesLabel.Location = new System.Drawing.Point(12, 197);
            this.modesLabel.Name = "modesLabel";
            this.modesLabel.Size = new System.Drawing.Size(46, 23);
            this.modesLabel.TabIndex = 4;
            this.modesLabel.Text = "Mode";
            // 
            // modeCombo
            // 
            this.modeCombo.Location = new System.Drawing.Point(12, 226);
            this.modeCombo.Name = "modeCombo";
            this.modeCombo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modeCombo.Properties.Appearance.Options.UseFont = true;
            this.modeCombo.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modeCombo.Properties.AppearanceDropDown.Options.UseFont = true;
            this.modeCombo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.modeCombo.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.modeCombo.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.modeCombo.Size = new System.Drawing.Size(100, 36);
            this.modeCombo.TabIndex = 6;
            // 
            // pilotEdit
            // 
            this.pilotEdit.Location = new System.Drawing.Point(118, 226);
            this.pilotEdit.Name = "pilotEdit";
            this.pilotEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pilotEdit.Properties.Appearance.Options.UseFont = true;
            this.pilotEdit.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.pilotEdit.Properties.MaxLength = 3;
            this.pilotEdit.Size = new System.Drawing.Size(75, 36);
            this.pilotEdit.TabIndex = 7;
            // 
            // tailNumberEdit
            // 
            this.tailNumberEdit.Location = new System.Drawing.Point(199, 226);
            this.tailNumberEdit.Name = "tailNumberEdit";
            this.tailNumberEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tailNumberEdit.Properties.Appearance.Options.UseFont = true;
            this.tailNumberEdit.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tailNumberEdit.Properties.MaxLength = 4;
            this.tailNumberEdit.Size = new System.Drawing.Size(101, 36);
            this.tailNumberEdit.TabIndex = 8;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(118, 197);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(34, 23);
            this.labelControl1.TabIndex = 9;
            this.labelControl1.Text = "Pilot";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(199, 197);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(101, 23);
            this.labelControl2.TabIndex = 10;
            this.labelControl2.Text = "Tail number";
            // 
            // addSortieButton
            // 
            this.addSortieButton.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(115)))), ((int)(((byte)(70)))));
            this.addSortieButton.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addSortieButton.Appearance.Options.UseBackColor = true;
            this.addSortieButton.Appearance.Options.UseFont = true;
            this.addSortieButton.Location = new System.Drawing.Point(200, 268);
            this.addSortieButton.Name = "addSortieButton";
            this.addSortieButton.Size = new System.Drawing.Size(100, 30);
            this.addSortieButton.TabIndex = 11;
            this.addSortieButton.Text = "Add";
            this.addSortieButton.Click += new System.EventHandler(this.addSortieButton_Click);
            // 
            // addModeButton
            // 
            this.addModeButton.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(115)))), ((int)(((byte)(70)))));
            this.addModeButton.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addModeButton.Appearance.Options.UseBackColor = true;
            this.addModeButton.Appearance.Options.UseFont = true;
            this.addModeButton.Location = new System.Drawing.Point(12, 268);
            this.addModeButton.Name = "addModeButton";
            this.addModeButton.Size = new System.Drawing.Size(100, 30);
            this.addModeButton.TabIndex = 12;
            this.addModeButton.Text = "Add";
            this.addModeButton.Click += new System.EventHandler(this.addModeButton_Click);
            // 
            // CheckInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 349);
            this.Controls.Add(this.addModeButton);
            this.Controls.Add(this.addSortieButton);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.tailNumberEdit);
            this.Controls.Add(this.pilotEdit);
            this.Controls.Add(this.modeCombo);
            this.Controls.Add(this.modesLabel);
            this.Controls.Add(this.sortiesTree);
            this.Controls.Add(this.modesTree);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.checkInButton);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("CheckInForm.IconOptions.Icon")));
            this.Name = "CheckInForm";
            this.Text = "Check-in";
            ((System.ComponentModel.ISupportInitialize)(this.modesTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modeTreeModeRepository)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sortiesTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sortiesTreePilotRepository)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sortiesTreeTailNumberRepository)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modeCombo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pilotEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tailNumberEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton checkInButton;
        private DevExpress.XtraEditors.SimpleButton cancelButton;
        private DevExpress.XtraTreeList.TreeList modesTree;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn3;
        private DevExpress.XtraTreeList.TreeList sortiesTree;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.XtraEditors.LabelControl modesLabel;
        private DevExpress.XtraEditors.ComboBoxEdit modeCombo;
        private DevExpress.XtraEditors.TextEdit pilotEdit;
        private DevExpress.XtraEditors.TextEdit tailNumberEdit;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton addSortieButton;
        private DevExpress.XtraEditors.SimpleButton addModeButton;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit modeTreeModeRepository;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit sortiesTreePilotRepository;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit sortiesTreeTailNumberRepository;
    }
}