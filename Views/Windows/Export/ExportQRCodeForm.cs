using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using windows_theodolite.Controllers;
using ZXing;

namespace windows_theodolite.Views.Windows.Export
{
    public partial class ExportQRCodeForm : DevExpress.XtraEditors.XtraForm
    {
        public ExportQRCodeForm(List<string> lines, List<(string, string)> sorties, List<string> modes)
        {
            InitializeComponent();

            GenerateQRCode(lines, sorties, modes);
        }

        private void GenerateQRCode(List<string> lines, List<(string, string)> sorties, List<string> modes)
        {
            if (lines.Count == 1)
            {
                Close();
                return;
            }
            DateTime dateTime = DateTime.Parse(lines[1].Split(',')[4]);

            string fileName = dateTime.ToUniversalTime().ToString("yyyy-MM-dd HHmm'Z'");
            List<string> sortiesString = new List<string>();
            foreach ((string, string) sortie in sorties)
                sortiesString.Add(sortie.Item1 + sortie.Item2);

            fileNameLabel.Text = fileName + " [" + string.Join("-", sortiesString) + "] [" + string.Join("-", modes) + "]";

            string text = CompressData(lines);

            string cipher = (Properties.Settings.Default.EncryptionWord != "" ? StringCipher.Encrypt(text, Properties.Settings.Default.EncryptionWord) : text);

            Bitmap qrCode = writeQRCode(cipher);

            if (qrCodeEdit.Image != null)
                qrCodeEdit.Image.Dispose();

            qrCodeEdit.Image = (Image) qrCode.Clone();

            qrCode.Dispose();
        }

        
        public static string CompressData(List<string> lines)
        {
            string date = "";

            lines.RemoveAt(0);

            string currentPilot = "";
            string currentTailNumber = "";
            string currentMode = "";
            string currentHeading = "";

            for (int i = 0; i < lines.Count; i++)
            {
                string line = lines[i];

                if (i == 0)
                {
                    date = line.Split(',')[4];
                    date = string.Concat(date[2], date[3], date[5], date[6], date[8], date[9], date[11], date[12], date[14], date[15], date[17], date[18]);
                }

                line = line.Replace(date + " ", "");

                string pilot = line.Split(',')[0];
                string tailNumber = line.Split(',')[1];

                if (pilot != currentPilot && tailNumber != currentTailNumber)
                {
                    lines.Insert(i, pilot + tailNumber);
                    i++;
                    currentPilot = pilot;
                    currentTailNumber = tailNumber;
                }

                string[] cells = line.Split(',');

                string mode = cells[2];
                string heading = cells[3];

                if (mode != currentMode && heading != currentHeading)
                {
                    lines.Insert(i, mode + "," + heading);
                    i++;
                    currentMode = mode;
                    currentHeading = heading;
                }

                line = string.Join(",", new string[] { cells[4], cells[5], cells[6], cells[9], cells[10] });

                lines[i] = line;
            }

            date = date.Replace("-", "");

            lines.Insert(0, date);
            return string.Join("\n", lines);
        }

        public static List<string> UncompressData(string data)
        {
            List<string> lines = data.Split('\n').ToList();

            string date = lines[0];
            lines.RemoveAt(0);

            if (date.Length == 12)
            {
                date = "20" + date.Substring(0, 2) + "-" + date.Substring(2, 2) + "-" + date.Substring(4, 2) + " " + date.Substring(6, 2) + ":" + date.Substring(8, 2) + ":" + date.Substring(10, 2) + "Z";
            }

            string currentPilot = "";
            string currentTailNumber = "";
            string currentMode = "";
            string currentHeading = "";
            for (int i = 0; i < lines.Count; i++)
            {
                string[] cells = lines[i].Split(',');
                if (cells.Length == 1)
                {
                    // Pilot/aircraft line
                    currentPilot = cells[0].Substring(0, 3);
                    currentTailNumber = cells[0].Substring(3);

                    lines.RemoveAt(i);
                    i--;
                } else if(cells.Length == 2)
                {
                    // Mode/heading line
                    currentMode = cells[0];
                    currentHeading = cells[1];

                    lines.RemoveAt(i);
                    i--;
                } else
                {
                    // Employment line
                    float distance = 0;
                    float direction = 0;
                    float x = 0;
                    float y = 0;
                    bool validFlags = false;

                    if (cells[1] != "" && cells[2] != "" && int.TryParse(cells[1], out int primaryFlag) && int.TryParse(cells[2], out int secondaryFlag))
                    {
                        (distance, direction, x, y) = MainForm.getDistanceAndPosition(primaryFlag, secondaryFlag);
                        validFlags = true;
                    }
                    lines[i] = string.Join(",", new string[] { currentPilot, currentTailNumber, currentMode, currentHeading, date, cells[1], cells[2], (validFlags ? distance.ToString() : ""), (validFlags ? direction.ToString() : ""), cells[3], cells[4] });
                }
            }

            lines.Insert(0,"Pilot,Tail Number,Mode,Heading,Date/Time,Primary flag,Secondary flag,Distance,Position,Hits,Comments");

            return lines;
        }

        public static Bitmap writeQRCode(string text)
        {
            var bw = new ZXing.BarcodeWriter();
            var encOptions = new ZXing.Common.EncodingOptions() { Width = 1024, Height = 1024, Margin = 0 };
            bw.Options = encOptions;
            bw.Format = ZXing.BarcodeFormat.QR_CODE;
            var result = new Bitmap(bw.Write(text));
            return result;
        }

        public static string readQRCode(Bitmap bitmap)
        {
            BarcodeReader barcode = new BarcodeReader();
            return barcode.Decode(bitmap)?.ToString();
        }

        private void qrCodeEdit_ImageChanged(object sender, System.EventArgs e)
        {
            if (qrCodeEdit.Image == null)
            {
                System.Diagnostics.Debugger.Break();
            }
            System.Diagnostics.Debugger.Break();
        }
    }
}