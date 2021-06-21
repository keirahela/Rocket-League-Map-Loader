using Custom_Map_Loader;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Auth.GG_Winform_Example
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 


        [STAThread]
        static void Main()
        {
            //Update this with your program information
            

            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (Custom_Map_Loader.Properties.Settings.Default.firstrun)
            {
                Application.Run(new CML2());
            } else
            {
                Application.Run(new CML());
            }
        }
    }
}
