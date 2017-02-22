using System;
using System.Windows.Forms;
using Microsoft.Win32;

namespace JimsBackgroundChanger
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SystemEvents.DisplaySettingsChanged += Wallpaper.SystemEvents_DisplaySettingsChanged;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form());
        }
    }
}
