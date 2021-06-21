using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Custom_Map_Loader
{
    public partial class CML : Form
    {

        private OpenFileDialog ofd;
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
        public CML()
        {
            InitializeComponent();
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private void Form1_Load(object sender, EventArgs e)
        {
            ofd = new OpenFileDialog();
            ofd.Filter = "UPK files|*.upk";

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new CML2();
            form2.Closed += (s, args) => this.Close();
            form2.Show();

        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void panelDropdown_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
            }
        }

        private void guna2GradientButton1_Click_1(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                bool underpass = File.Exists(Properties.Settings.Default.under4 + @"\TAGame\CookedPCConsole\Labs_Underpass_P.upk");
                bool underpass2 = File.Exists(Properties.Settings.Default.under4 + @"\TAGame\CookedPCConsole\Labs_Underpass_P_BACKUP.upk");
                string sFileName = ofd.FileName;
                if (underpass)
                {
                    if (!underpass2)
                    {
                        File.Move(Properties.Settings.Default.under4 + @"\TAGame\CookedPCConsole\Labs_Underpass_P.upk", Properties.Settings.Default.under4 + @"\TAGame\CookedPCConsole\Labs_Underpass_P_BACKUP.upk");
                        File.Copy(sFileName, Properties.Settings.Default.under4 + @"\TAGame\CookedPCConsole\Labs_Underpass_P.upk");
                    } else
                    {
                        File.Delete(Properties.Settings.Default.under4 + @"\TAGame\CookedPCConsole\Labs_Underpass_P.upk");
                        File.Copy(sFileName, Properties.Settings.Default.under4 + @"\TAGame\CookedPCConsole\Labs_Underpass_P.upk");
                    }
                }
                else if (!underpass)
                {
                    if (underpass2)
                    {
                        File.Copy(sFileName, Properties.Settings.Default.under4 + @"\TAGame\CookedPCConsole\Labs_Underpass_P.upk");
                    } else
                    {
                        File.Copy(sFileName, Properties.Settings.Default.under4 + @"\TAGame\CookedPCConsole\Labs_Underpass_P.upk");
                    }
                }
            }
            
            label2.Text = "Current Map: " + Path.GetFileName(ofd.FileName);
        }

        private void guna2TileButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2TileButton2_Click(object sender, EventArgs e)
        {
            base.WindowState = FormWindowState.Minimized;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }
    }
}
