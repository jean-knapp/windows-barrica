﻿
using DevExpress.XtraTreeList.Nodes;
using System;
using System.Collections.Generic;
using System.IO;

namespace windows_theodolite.Views.Windows.Sorties
{
    public partial class CheckInForm : DevExpress.XtraEditors.XtraForm
    {
        public CheckInForm()
        {
            InitializeComponent();

            if (File.Exists(Directories.UserDirectory + "modes.csv"))
            {
                modeCombo.Properties.Items.Clear();
                foreach (string mode in File.ReadAllLines(Directories.UserDirectory + "modes.csv"))
                {
                    modeCombo.Properties.Items.Add(mode);
                }
            }
        }

        public List<(string, string)> Sorties
        {
            get
            {
                List<(string, string)> result = new List<(string, string)>();
                foreach(TreeListNode node in sortiesTree.Nodes)
                {
                    result.Add((node["pilot"].ToString(), node["tailNumber"].ToString()));
                }
                return result;
            }
            set
            {
                sortiesTree.BeginUnboundLoad();
                foreach ((string,string) sortie in value)
                {
                    sortiesTree.AppendNode(new object[] { sortie.Item1, sortie.Item2 }, null);
                }
                sortiesTree.EndUnboundLoad();
            }
        }

        public List<string> Modes
        {
            get
            {
                List<string> result = new List<string>();
                foreach (TreeListNode node in modesTree.Nodes)
                {
                    result.Add(node["mode"].ToString());
                }
                return result;
            }
            set
            {
                modesTree.BeginUnboundLoad();
                foreach (string mode in value)
                {
                    modesTree.AppendNode(new object[] { mode }, null);
                }
                modesTree.EndUnboundLoad();
            }
        }

        private void addSortieButton_Click(object sender, EventArgs e)
        {
            if (pilotEdit.EditValue?.ToString() != null && pilotEdit.EditValue?.ToString() != "" && tailNumberEdit.EditValue?.ToString() != null && tailNumberEdit.EditValue?.ToString() != "")
            {
                sortiesTree.BeginUnboundLoad();
                sortiesTree.AppendNode(new object[] { pilotEdit.EditValue.ToString(), tailNumberEdit.EditValue.ToString() }, null);
                sortiesTree.EndUnboundLoad();
                pilotEdit.EditValue = "";
                tailNumberEdit.EditValue = "";
                pilotEdit.Focus();

                checkInButton.Enabled = (sortiesTree.Nodes.Count > 0 && modesTree.Nodes.Count > 0);
            }
        }

        private void addModeButton_Click(object sender, EventArgs e)
        {
            if (modeCombo.EditValue?.ToString() != null && modeCombo.EditValue?.ToString() != "")
            {
                modesTree.BeginUnboundLoad();
                modesTree.AppendNode(new object[] { modeCombo.EditValue?.ToString() }, null);
                modesTree.EndUnboundLoad();
                modeCombo.EditValue = "";
                modeCombo.Focus();

                checkInButton.Enabled = (sortiesTree.Nodes.Count > 0 && modesTree.Nodes.Count > 0);
            }
        }

        private void sortiesTree_CellValueChanged(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            if (e.Node["pilot"].ToString() == "" || e.Node["tailNumber"].ToString() == "")
                sortiesTree.Nodes.Remove(e.Node);

            checkInButton.Enabled = (sortiesTree.Nodes.Count > 0 && modesTree.Nodes.Count > 0);
        }

        private void modesTree_CellValueChanged(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            if (e.Node["mode"].ToString() == "")
                sortiesTree.Nodes.Remove(e.Node);

            checkInButton.Enabled = (sortiesTree.Nodes.Count > 0 && modesTree.Nodes.Count > 0);
        }
    }
}