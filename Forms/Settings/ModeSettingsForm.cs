using DevExpress.XtraEditors;
using DevExpress.XtraTreeList.Nodes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace windows_theodolite.Forms.Settings
{
    public partial class ModeSettingsForm : DevExpress.XtraEditors.XtraForm
    {
        public ModeSettingsForm()
        {
            InitializeComponent();

            if (File.Exists(Directories.UserDirectory + "modes.csv"))
            {
                modesTree.BeginUnboundLoad();
                foreach (string mode in File.ReadAllLines(Directories.UserDirectory + "modes.csv"))
                {
                    modesTree.AppendNode(new object[] { mode }, null);
                }
                modesTree.EndUnboundLoad();
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            modesTree.BeginUnboundLoad();
            List<TreeListNode> nodes = new List<TreeListNode>();
            nodes.AddRange(modesTree.Selection);
            foreach(TreeListNode node in nodes)
            {
                modesTree.Nodes.Remove(node);
            }
            modesTree.EndUnboundLoad();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            modesTree.BeginUnboundLoad();
            modesTree.AppendNode(new object[] { modeEdit.EditValue.ToString() }, null);
            modesTree.EndUnboundLoad();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            List<string> modes = new List<string>();
            foreach(TreeListNode node in modesTree.Nodes)
            {
                if (node["mode"].ToString().Length > 0)
                    modes.Add(node["mode"].ToString());
            }

            File.WriteAllLines(Directories.UserDirectory + "modes.csv", modes.Distinct().ToArray());
        }
    }
}