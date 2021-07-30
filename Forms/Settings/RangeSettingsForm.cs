using DevExpress.XtraEditors;
using System;
using System.IO;
using System.Windows.Forms;

namespace windows_theodolite.Forms.Settings
{
    public partial class RangeSettingsForm : DevExpress.XtraEditors.XtraForm
    {
        public RangeSettingsForm()
        {
            InitializeComponent();
        }

        public float PrimaryTowerTargetDistance { 
            get {
                return float.Parse(towerTargetDistanceEdit.EditValue.ToString());
            }
            set
            {
                towerTargetDistanceEdit.EditValue = value;
            }
        }

        public float SecondaryTowerTargetDistance
        {
            get
            {
                return float.Parse(secTowerTargetDistanceEdit.EditValue.ToString());
            }
            set
            {
                secTowerTargetDistanceEdit.EditValue = value;
            }
        }
        public float TowerTowerDistance
        {
            get
            {
                return float.Parse(towerTowerDistanceEdit.EditValue.ToString());
            }
            set
            {
                towerTowerDistanceEdit.EditValue = value;
            }
        }
        public int DefaultHeading
        {
            get
            {
                return int.Parse(defaultHeadingEdit.EditValue.ToString());
            }
            set
            {
                defaultHeadingEdit.EditValue = value;
            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory(Directories.UserDirectory + "Ranges");
            saveFileDialog.InitialDirectory = Directories.UserDirectory + "Ranges";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName,
                    string.Join(",", new string[] { nameof(PrimaryTowerTargetDistance), nameof(SecondaryTowerTargetDistance), nameof(TowerTowerDistance), nameof(DefaultHeading) }) + "\r\n" +
                    string.Join(",", new string[] { PrimaryTowerTargetDistance.ToString(), SecondaryTowerTargetDistance.ToString(), TowerTowerDistance.ToString(), DefaultHeading.ToString() }));
            }
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory(Directories.UserDirectory + "Ranges");
            openFileDialog.InitialDirectory = Directories.UserDirectory + "Ranges";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] lines = File.ReadAllLines(openFileDialog.FileName);
                if (lines.Length == 2 && 
                    lines[0] == string.Join(",", new string[] { nameof(PrimaryTowerTargetDistance), nameof(SecondaryTowerTargetDistance), nameof(TowerTowerDistance), nameof(DefaultHeading) }) &&
                    lines[1].Split(',').Length == 4 &&
                    float.TryParse(lines[1].Split(',')[0], out float priTowerTargetDistance) &&
                    float.TryParse(lines[1].Split(',')[1], out float secTowerTargetDistance) &&
                    float.TryParse(lines[1].Split(',')[2], out float towerTowerDistance) &&
                    int.TryParse(lines[1].Split(',')[3], out int defaultHeading))
                {
                    PrimaryTowerTargetDistance = priTowerTargetDistance;
                    SecondaryTowerTargetDistance = secTowerTargetDistance;
                    TowerTowerDistance = towerTowerDistance;
                    DefaultHeading = defaultHeading;
                } else
                {
                    XtraMessageBox.Show("Error: Wrong file format.");
                }
            }
        }
    }
}