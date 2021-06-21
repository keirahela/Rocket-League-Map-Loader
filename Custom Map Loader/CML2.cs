using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace Custom_Map_Loader
{
    public partial class CML2 : Form
    {
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (File.Exists(Properties.Settings.Default.under4 + @"\TAGame\CookedPCConsole\Labs_Underpass_P_BACKUP.upk"))
            {
                File.Delete(Properties.Settings.Default.under4 + @"\TAGame\CookedPCConsole\Labs_Underpass_P.upk");
                File.Move(Properties.Settings.Default.under4 + @"\TAGame\CookedPCConsole\Labs_Underpass_P_BACKUP.upk", Properties.Settings.Default.under4 + @"\TAGame\CookedPCConsole\Labs_Underpass_P.upk");
                bool backup = File.Exists(Properties.Settings.Default.under4 + @"\TAGame\CookedPCConsole\Labs_Underpass_P_BACKUP.upk");
                if (backup)
                {
                    File.Delete(Properties.Settings.Default.under4 + @"\TAGame\CookedPCConsole\Labs_Underpass_P_BACKUP.upk");
                }
            }
        }
        public CML2()
        {
            InitializeComponent();

        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private void Form2_Load(object sender, EventArgs e)
        {
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            var foldername = folderBrowserDialog1.SelectedPath;
            Properties.Settings.Default.under4 = foldername;
            Properties.Settings.Default.Save();
            bool rocketleague = File.Exists(foldername + @"\Binaries\Win64\RocketLeague.exe");
                if (!rocketleague)
                {
                    MessageBox.Show("Error! Rocket League not found.", "CML | Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (rocketleague)
                {
                MessageBox.Show("Success! Rocket league found", "CML | Success", MessageBoxButtons.OK);
                Properties.Settings.Default.firstrun = false;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Reload();
            }
            this.Hide();
            var form1 = new CML();
            form1.Closed += (s, args) => this.Close();
            form1.Show();

        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        private void guna2TileButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2TileButton2_Click(object sender, EventArgs e)
        {
            base.WindowState = FormWindowState.Minimized;
        }
    }
}
