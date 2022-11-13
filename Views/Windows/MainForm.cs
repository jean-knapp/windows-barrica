using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList.Nodes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using windows_theodolite.Controllers;
using windows_theodolite.Views.Windows.Export;
using windows_theodolite.Views.Windows.Settings;
using windows_theodolite.Views.Windows.Sorties;

namespace windows_theodolite.Views.Windows
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        Image qrCode = null;

        List<(string, string)> sorties = new List<(string, string)>();
        List<string> modes = new List<string>();

        static float priTowerTargetDistance = Properties.Settings.Default.PrimaryTowerTargetDistance;
        static float secTowerTargetDistance = Properties.Settings.Default.SecondaryTowerTargetDistance;
        static float towerTowerDistance = Properties.Settings.Default.TowerTowerDistance;
        static int defaultHeading = Properties.Settings.Default.DefaultHeading;

        public MainForm()
        {
            InitializeComponent();

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");

            passwordEdit.EditValue = Properties.Settings.Default.EncryptionWord;

            populateCombos();

            headingEdit.EditValue = defaultHeading;

            if (Properties.Settings.Default.AutosaveFile != "" && File.Exists(Properties.Settings.Default.AutosaveFile))
            {
                Load(Properties.Settings.Default.AutosaveFile);
                return;
            }


        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string pilot = pilotEdit.EditValue.ToString();

            if (pilot == "")
                return;

            string tailNumber = sorties[pilotEdit.Properties.Items.IndexOf(pilot)].Item2;
            int heading = int.Parse(headingEdit.EditValue.ToString());
            string mode = modeEdit.EditValue.ToString();
            bool validFlags = true;
            bool validHits = true;

            int primaryFlag = 0;
            int secondaryFlag = 0;
            int hits = 0;
            if (!int.TryParse(primaryFlagEdit.EditValue.ToString(), out primaryFlag))
            {
                validFlags = false;
            } 
            if (!int.TryParse(secondaryFlagEdit.EditValue.ToString(), out secondaryFlag))
            {
                validFlags = false;
            }
            if (!int.TryParse(hitsEdit.EditValue.ToString(), out hits))
            {
                validHits = false;
            }

            (float distance, float direction, float x, float y) = getDistanceAndPosition(primaryFlag, secondaryFlag);

            if (validFlags)
            {
                direction -= (heading - defaultHeading) / 30;
                if (direction >= 13)
                    direction -= 12;

                if (direction < 1)
                    direction += 12;
            }

            string comments = commentsEdit.EditValue.ToString();

            primaryFlagEdit.EditValue = "";
            secondaryFlagEdit.EditValue = "";
            hitsEdit.EditValue = "";
            pilotEdit.EditValue = "";
            commentsEdit.EditValue = "";
            TreeListNode node = employmentsTree.AppendNode(new object[] { DateTime.UtcNow, pilot, tailNumber, heading, mode, (validFlags ? primaryFlag.ToString() : ""), (validFlags ? secondaryFlag.ToString() : ""), (validFlags? distance.ToString() : ""), (validFlags? direction.ToString() : ""), (validHits ? hits.ToString() : ""), comments, (validFlags ? DX(x) : ""), (validFlags ? DY(y) : "") }, null);
            employmentsTree.FocusedNode = node;

            pilotEdit.Focus();

            Save();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            CheckInForm form = new CheckInForm()
            {
                Sorties = sorties,
                Modes = modes
            };

            if (form.ShowDialog() == DialogResult.OK)
            {
                sorties = form.Sorties.Distinct().Where(s => s.Item1 != "" && s.Item2 != "").ToList();
                modes = form.Modes.Distinct().Where(m => m != "").ToList();

                if (sorties.Count == 0)
                {
                    XtraMessageBox.Show("Could not check-in. There are no sorties available.");
                    sorties.Clear();
                    modes.Clear();
                } else if(modes.Count == 0)
                {
                    XtraMessageBox.Show("Could not check-in. There are no modes available.");
                    sorties.Clear();
                    modes.Clear();
                }

                sortiesCheckOutButton.Enabled = true;

                populateCombos();
            }
        }

        private void CheckOut()
        {
            sorties.Clear();
            modes.Clear();

            primaryFlagEdit.EditValue = "";
            secondaryFlagEdit.EditValue = "";
            modeEdit.EditValue = "";
            hitsEdit.EditValue = "";
            pilotEdit.EditValue = "";

            employmentsTree.Nodes.Clear();

            sortiesCheckOutButton.Enabled = false;

            populateCombos();

            Properties.Settings.Default.AutosaveFile = "";
            Properties.Settings.Default.Save();
        }

        private void sortiesCheckOutButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            List<string> lines = GetEmployments();
            if (lines.Count > 1)
            {
                ExportQRCodeForm form = new ExportQRCodeForm(lines, sorties, modes);
                form.ShowDialog();
            }

            CheckOut();
        }

        private bool CanCheckIn()
        {
            return IsModalitiesSet() && IsRangeSet();
        }

        private bool IsRangeSet()
        {
            return priTowerTargetDistance > 0 && secTowerTargetDistance > 0 && towerTowerDistance > 0;
        }

        private bool IsModalitiesSet()
        {
            return EmploymentModalitiesForm.GetModalities().Count > 0;
        }

        private void populateCombos()
        {
            alertRangePanel.Visible = !IsRangeSet();
            modeSettingsButton.Enabled = IsRangeSet();

            alertModalitiesPanel.Visible = IsRangeSet() && !IsModalitiesSet();

            sortiesCheckInButton.Enabled = CanCheckIn();

            

            bool valid = (sorties.Count > 0 && modes.Count > 0);

            headingEdit.Enabled = valid;
            modeEdit.Enabled = valid;
            pilotEdit.Enabled = valid;
            primaryFlagEdit.Enabled = valid;
            secondaryFlagEdit.Enabled = valid;
            hitsEdit.Enabled = valid;
            clearButton.Enabled = valid;
            commentsEdit.Enabled = valid;
            
            pilotEdit.Properties.Items.Clear();
            foreach ((string, string) sortie in sorties)
            {
                pilotEdit.Properties.Items.Add(sortie.Item1);
            }

            modeEdit.Properties.Items.Clear();
            foreach (string mode in modes)
            {
                modeEdit.Properties.Items.Add(mode);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="primaryFlag"></param>
        /// <param name="secondaryFlag"></param>
        /// <returns>(distance, position, x, y)</returns>
        public static (float, float, float, float) getDistanceAndPosition(int primaryFlag, int secondaryFlag)
        {
            // Angle at primary tower between target and secondary tower.
            double  priTowerTargetAngle = Math.Acos((Math.Pow(priTowerTargetDistance, 2) + Math.Pow(towerTowerDistance, 2) - Math.Pow(secTowerTargetDistance, 2)) / 2 / priTowerTargetDistance / towerTowerDistance);

            // Angle at secondary tower between target and primary tower.
            double secTowerTargetAngle = Math.Acos((Math.Pow(secTowerTargetDistance, 2) + Math.Pow(towerTowerDistance, 2) - Math.Pow(priTowerTargetDistance, 2)) / 2 / secTowerTargetDistance / towerTowerDistance);

            // Distance from target to tower-tower axis;
            double targetDistance = Math.Sin(priTowerTargetAngle) * priTowerTargetDistance;

            // Distance from target projection on tower-tower axis to secondary tower.
            double secTowerDistanceProjection = Math.Cos(secTowerTargetAngle) * secTowerTargetDistance;

            // Flag conversions.
            double secFlag = Math.PI * (double)secondaryFlag / 3200;
            double priFlag = Math.PI * (double)primaryFlag / 3200;

            // Dist impacto-BINGO no eixo longitudinal
            double x = (towerTowerDistance * Math.Tan(secTowerTargetAngle - secFlag) * Math.Tan(priTowerTargetAngle + priFlag))/ (Math.Tan(secTowerTargetAngle - secFlag) + Math.Tan(priTowerTargetAngle + priFlag)) - targetDistance;
            
            // Dist impacto-BINGO no eixo lateral
            double y = (towerTowerDistance * Math.Tan(secTowerTargetAngle - secFlag) * Math.Tan(priTowerTargetAngle + priFlag))/ (Math.Tan(secTowerTargetAngle - secFlag) + Math.Tan(priTowerTargetAngle + priFlag)) / Math.Tan(secTowerTargetAngle - secFlag) - secTowerDistanceProjection;

            // Distância em relação ao bingo
            double distance = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));

            // Ângulo em relação ao bingo, em radianos.
            double positionRadians = Math.Atan2(y, x);

            double positionHours = 6 * positionRadians / Math.PI;
            if (positionHours < 1)
                positionHours += 12;

            return ((float)Math.Round(distance, 3), (float)Math.Round(positionHours,1), (float)Math.Round(y), (float)Math.Round(x));
        }

        private void rangeSettingsButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            RangeSettingsForm form = new RangeSettingsForm()
            {
                PrimaryTowerTargetDistance = priTowerTargetDistance,
                SecondaryTowerTargetDistance = secTowerTargetDistance,
                TowerTowerDistance = towerTowerDistance,
                DefaultHeading = defaultHeading
            };
            if (form.ShowDialog() == DialogResult.OK)
            {
                priTowerTargetDistance = form.PrimaryTowerTargetDistance;
                secTowerTargetDistance = form.SecondaryTowerTargetDistance;
                towerTowerDistance = form.TowerTowerDistance;
                defaultHeading = form.DefaultHeading;

                Properties.Settings.Default.PrimaryTowerTargetDistance = priTowerTargetDistance;
                Properties.Settings.Default.SecondaryTowerTargetDistance = secTowerTargetDistance;
                Properties.Settings.Default.TowerTowerDistance = towerTowerDistance;
                Properties.Settings.Default.DefaultHeading = defaultHeading;
                Properties.Settings.Default.Save();

                populateCombos();
            }
        }

        private void modeSettingsButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            EmploymentModalitiesForm form = new EmploymentModalitiesForm();
            form.ShowDialog();

            populateCombos();
        }

        private void Save(string fileName)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fileName));
            File.WriteAllLines(fileName, GetEmployments());

            Properties.Settings.Default.AutosaveFile = fileName;
            Properties.Settings.Default.Save();
        }

        private void Save()
        {
            string fileName = GetFilename();
            Save(fileName);
        }

        private string GetFilename()
        {
            List<string> employments = GetEmployments();

            DateTime dateTime = DateTime.Parse(employments[1].Split(',')[4]);

            string fileName = dateTime.ToUniversalTime().ToString("yyyy-MM-dd HHmm'Z'");
            List<string> sortiesString = new List<string>();
            foreach ((string, string) sortie in sorties)
                sortiesString.Add(sortie.Item1 + sortie.Item2);

            fileName = Directories.UserDirectory + "Employments/" + fileName + " [" + string.Join("-", sortiesString) + "] [" + string.Join("-", modes) + "].csv";
            return fileName;
        }

        private void Load(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName);

            sorties.Clear();
            modes.Clear();
            employmentsTree.Nodes.Clear();

            try
            {

                string[] parts = fileName.Split('[');
                if (parts.Length == 3)
                    for (int i = 1; i <= 2; i++)
                    {
                        string part = parts[i];
                        part = part.Substring(0, part.IndexOf(']'));

                        string[] cells = part.Split('-');

                        if (i == 1)
                        {
                            // Sorties
                            foreach (string cell in cells)
                                sorties.Add((cell.Substring(0, 3), cell.Substring(3)));
                        }
                        else
                        {
                            // Modes
                            foreach (string cell in cells)
                                modes.Add(cell);
                        }
                    }
            } catch (ArgumentOutOfRangeException e)
            {
                XtraMessageBox.Show("Wrong file format.");

                sorties.Clear();
                modes.Clear();
                employmentsTree.Nodes.Clear();
                return;
            }

            SetEmployments(lines);

            if (employmentsTree.Nodes.Count == 0)
            {
                XtraMessageBox.Show("Could not load any data.");
                return;
            }

            populateCombos();
            sortiesCheckOutButton.Enabled = true;

            Save(fileName);
        }

        private List<string> GetEmployments()
        {
            List<string> lines = new List<string>();
            lines.Add("Pilot,Tail Number,Mode,Heading,Date/Time,Primary flag,Secondary flag,Distance,Position,Hits,Comments");
            foreach (TreeListNode employment in employmentsTree.Nodes)
            {
                DateTime dateTime = DateTime.Parse(employment["datetime"].ToString());
                string dateStr = dateTime.ToString("u");

                string[] cells = new string[] {
                    employment["pilot"]?.ToString().Replace(",", "."),
                    employment["tailNumber"]?.ToString().Replace(",", "."),
                    employment["mode"]?.ToString().Replace(",", "."),
                    employment["heading"]?.ToString().Replace(",", "."),
                    dateStr,
                    employment["primaryFlag"]?.ToString().Replace(",", "."),
                    employment["secondaryFlag"]?.ToString().Replace(",", "."),
                    employment["distance"]?.ToString().Replace(",", "."),
                    employment["direction"]?.ToString().Replace(",", "."),
                    employment["hits"]?.ToString().Replace(",", "."),
                    employment["comments"]?.ToString().Replace(",", ".")
                };

                lines.Add(string.Join(",", cells));
            }

            return lines;
        }

        private void SetEmployments(string[] lines)
        {
            employmentsTree.BeginUnboundLoad();
            bool first = true;
            foreach (string line in lines)
            {
                if (first)
                {
                    first = false;
                    continue;
                }

                string[] cells = line.Split(',');
                if (cells.Length != 11)
                    continue;

                if (!(sorties.Contains((cells[0], cells[1]))))
                    sorties.Add((cells[0], cells[1]));

                if (!modes.Contains(cells[2]))
                    modes.Add(cells[2]);

                float distance = 0;
                float direction = 0;
                float x = 0;
                float y = 0;

                if (cells[5] != "" && cells[6] != "")
                    (distance, direction, x, y) = getDistanceAndPosition(int.Parse(cells[5]), int.Parse(cells[6]));

                float heading = defaultHeading;
                if (cells[3] != "")
                    heading = int.Parse(cells[3]);

                direction -= (heading - defaultHeading) / 30;
                if (direction >= 13)
                    direction -= 12;

                if (direction < 1)
                    direction += 12;

                DateTime date = DateTime.Parse(cells[4]).ToUniversalTime();

                employmentsTree.AppendNode(new object[] { date, cells[0], cells[1], cells[3], cells[2], (cells[5] != "" ? cells[5] : ""), (cells[6] != "" ? cells[6] : ""), (cells[5] != "" && cells[6] != "" ? distance.ToString() : ""), (cells[5] != "" && cells[6] != "" ? direction.ToString() : ""), (cells[9] != "" ? cells[9] : ""), cells[10], (cells[5] != "" && cells[6] != "" ? DX(x) : ""), (cells[5] != "" && cells[6] != "" ? DY(y) : "") }, null);
            }
            employmentsTree.EndUnboundLoad();
        }

        public string DX(float x)
        {
            return Math.Abs(Math.Round(x)) + "" + (Math.Sign(x) >= 0 ? "RT" : "LF");
        }

        public string DY(float y)
        {
            return Math.Abs(Math.Round(y)) + "" + (Math.Sign(y) >= 0 ? "OV" : "UN");
        }

        private void employmentsTree_CellValueChanged(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            string primaryFlagStr = e.Node["primaryFlag"]?.ToString();
            string secondaryFlagStr = e.Node["secondaryFlag"]?.ToString();
            string headingStr = e.Node["heading"]?.ToString();

            //System.Diagnostics.Debugger.Break();

            if (primaryFlagStr != "" && secondaryFlagStr != "" && headingStr != "" && int.TryParse(primaryFlagStr, out int primaryflag) && int.TryParse(secondaryFlagStr, out int secondaryFlag) && int.TryParse(headingStr, out int heading))
            {
                (float distance, float direction, float x, float y) = getDistanceAndPosition(primaryflag, secondaryFlag);


                direction -= (heading - defaultHeading) / 30;
                if (direction >= 13)
                    direction -= 12;

                if (direction < 1)
                    direction += 12;

                e.Node["distance"] = distance.ToString();
                e.Node["direction"] = direction.ToString();
                e.Node["x"] = DX(x);
                e.Node["y"] = DY(y);
            } else
            {
                e.Node["distance"] = "";
                e.Node["direction"] = "";
                e.Node["x"] = "";
                e.Node["y"] = "";
            }

            Save();
        }

        private void backstageExitItem_ItemClick(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {
            Close();
        }

        private void backstage_ItemClick(object sender, DevExpress.XtraBars.Ribbon.RecentItemEventArgs e)
        {
            
            if (e.Item == openCSVButton)
            {
                XtraOpenFileDialog dialog = new XtraOpenFileDialog();
                dialog.InitialDirectory = Directories.UserDirectory + "Employments";
                dialog.Filter = "CSV files (*.csv)|*.csv";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    CheckOut();

                    Load(dialog.FileName);
                    backstage.Close();
                }
            }
             else if(e.Item == openQRCodeButton)
            {
                XtraOpenFileDialog dialog = new XtraOpenFileDialog();
                dialog.InitialDirectory = Directories.UserDirectory + "Employments";
                dialog.Filter = "Image files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Image qrCode = Bitmap.FromFile(dialog.FileName);

                    if (qrCode != null)
                    {
                        CheckOut();

                        string cipher = ExportQRCodeForm.readQRCode((Bitmap)qrCode);
                        string compressedData = "";

                        if (cipher != null)
                        {
                            compressedData = (Properties.Settings.Default.EncryptionWord != "" ? StringCipher.Decrypt(cipher, Properties.Settings.Default.EncryptionWord) : cipher);
                        }

                        if (compressedData == "")
                        {
                            XtraMessageBox.Show("The QR Code is invalid. The Encryption Word could be wrong or the data could not be valid.");
                            return;
                        }
                        //System.Diagnostics.Debugger.Break();
                        string[] lines = ExportQRCodeForm.UncompressData(compressedData).ToArray();
                        //System.Diagnostics.Debugger.Break();
                        SetEmployments(lines);
                        populateCombos();
                        backstage.Close();

                        sortiesCheckOutButton.Enabled = true;
  
                    }
                }
            }
            else if(e.Item == saveQRCodeButton)
            {
                if (employmentsTree.Nodes.Count > 0)
                {
                    var lines = GetEmployments();
                    if (lines.Count > 1)
                    {
                        ExportQRCodeForm form = new ExportQRCodeForm(lines, sorties, modes);
                        form.ShowDialog();
                        backstage.Close();
                    }
                }
                else
                {
                    XtraMessageBox.Show("There are no employments to save.");
                }
            }
            else if(e.Item == saveExcelButton)
            {
                if (employmentsTree.Nodes.Count > 0)
                {
                    XtraSaveFileDialog dialog = new XtraSaveFileDialog();
                    dialog.FileName = Path.GetFileName(GetFilename().Replace(".csv", ".xlsx"));
                    dialog.Filter = "Excel Spreadsheets (*.xlsx)|*.xlsx";
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        employmentsTree.ExportToXlsx(dialog.FileName);
                        Process.Start(Path.GetDirectoryName(dialog.FileName));
                        backstage.Close();
                    }
                }
                else
                {
                    XtraMessageBox.Show("There are no employments to save.");
                }
            }
            else if(e.Item == saveCSVButton)
            {
                if (employmentsTree.Nodes.Count > 0)
                {
                    XtraSaveFileDialog dialog = new XtraSaveFileDialog();
                    dialog.Filter = "CSV files (*.csv)|*.csv";
                    dialog.FileName = Path.GetFileName(GetFilename());
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        Save(dialog.FileName);
                        backstage.Close();
                    }
                } else
                {
                    XtraMessageBox.Show("There are no employments to save.");
                }
            }
        }

        private void LoadRecentFiles()
        {
            openRecentTab.Items.Clear();
            if (Directory.Exists(Directories.UserDirectory + "Employments/"))
            {
                int i = 0;
                foreach (string file in Directory.GetFiles(Directories.UserDirectory + "Employments/").OrderByDescending(f => f))
                {
                    RecentPinItem item = new RecentPinItem();
                    item.ImageOptions.ItemNormal.Image = Properties.Resources.csv;
                    item.Caption = Path.GetFileNameWithoutExtension(file);
                    item.Tag = file;
                    item.ItemClick += RecentItem_ItemClick;
                    item.PinButtonVisibility = RecentPinButtonVisibility.Never;

                    openRecentTab.Items.Add(item);

                    i++;

                    if (i > 30) // Limit 30 items.
                        break;
                }

            }
        }

        private void RecentItem_ItemClick(object sender, RecentItemEventArgs e)
        {
            Load(e.Item.Tag.ToString());
            backstage.Close();
        }
        private void backstage_Showing(object sender, EventArgs e)
        {
            LoadRecentFiles();
        }

        private void passwordEdit_EditValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.EncryptionWord = passwordEdit.EditValue.ToString();
            Properties.Settings.Default.Save();
        }

        private void inputEdit_EditValueChanged(object sender, EventArgs e)
        {
            saveButton.Enabled = (headingEdit.EditValue.ToString() != "" && modeEdit.EditValue.ToString() != "" && pilotEdit.EditValue.ToString() != "" && ((primaryFlagEdit.EditValue.ToString() != "" && secondaryFlagEdit.EditValue.ToString() != "") || (hitsEdit.EditValue.ToString() != "")));
        }

        private void alertButton_Click(object sender, EventArgs e)
        {
            if (sender == alertRangeButton)
            {
                rangeSettingsButton.PerformClick();
            }
            else if(sender == alertModalitiesButton)
            {
                modeSettingsButton.PerformClick();
            }
        }
    }
}